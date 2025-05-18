using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AppReports.Models;

namespace AppReports.ViewModels;

public class ReportsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Report> Reports { get; set; } = new();

    public ReportsViewModel(string reportName, string city, DateTime dateFrom, DateTime dateTo)
    {
        // Mock data, filtra según parámetros recibidos (puedes mejorar lógica después)
        var allReports = new[]
        {
                new Report { MovieName = "Oppenheimer", City = "Bogotá", Room = "Sala 1", Date = new DateTime(2025,5,1), BoxOffice = 1000000, Status = "Completed" },
                new Report { MovieName = "Barbie", City = "Bogotá", Room = "Sala 3", Date = new DateTime(2025,5,1), BoxOffice = 750000, Status = "Pending" },
                new Report { MovieName = "Kung Fu Panda", City = "Bogotá", Room = "Sala 2", Date = new DateTime(2025,5,1), BoxOffice = 550000, Status = "Completed" },
                new Report { MovieName = "Oppenheimer", City = "Cali", Room = "Sala 1", Date = new DateTime(2025,5,1), BoxOffice = 1000000, Status = "Completed" },
                new Report { MovieName = "Barbie", City = "Cali", Room = "Sala 3", Date = new DateTime(2025,5,1), BoxOffice = 750000, Status = "Pending" },
                new Report { MovieName = "Kung Fu Panda", City = "Cali", Room = "Sala 2", Date = new DateTime(2025,5,1), BoxOffice = 550000, Status = "Completed" },
                new Report { MovieName = "Oppenheimer", City = "Medellín", Room = "Sala 1", Date = new DateTime(2025,5,1), BoxOffice = 1000000, Status = "Completed" },
                new Report { MovieName = "Barbie", City = "Medellín", Room = "Sala 3", Date = new DateTime(2025,5,1), BoxOffice = 750000, Status = "Pending" },
                new Report { MovieName = "Kung Fu Panda", City = "Medellín", Room = "Sala 2", Date = new DateTime(2025,5,1), BoxOffice = 550000, Status = "Completed" }
            };

        foreach (var report in allReports)
        {
            if ((string.IsNullOrEmpty(city) || report.City == city)
                && report.Date >= DateTime.Now.AddMonths(-1) && report.Date <= DateTime.Now)
            {
                Reports.Add(report);
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}