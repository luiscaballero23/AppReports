using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AppReports.Models;
using AppReports.Views;

namespace AppReports.ViewModels;

public class ReportsViewModel 
{
    public ObservableCollection<MovieReportDetail> Reports { get; set; }
    public ICommand ShowDetailCommand { get; }

    public ReportsViewModel()
    {
        // Datos mock
        Reports = new ObservableCollection<MovieReportDetail>
        {
            new MovieReportDetail
            {
                MovieId = 1,
                MovieName = "Inside Out 2",
                City = "Bogotá",
                Room = "Sala 1",
                Date = new DateTime(2025, 5, 19),
                MovieGenre = "Animation",
                Distributor = "Disney",
                Director = "Juan Pérez",
                Projectionist = "Carlos Gómez",
                StartTime = "16:00",
                EndTime = "18:00",
                DurationMinutes = 120,
                Language = "Spanish",
                Subtitled = true,
                ScreenType = "IMAX",
                SoundType = "Dolby Atmos",
                Format = "2D",
                TicketsSold = 350,
                BoxOffice = 2100000,
                Tax = 320000,
                Discount = 50000,
                NetIncome = 1730000,
                Occupancy = 75,
                PopcornSales = 500000,
                DrinkSales = 200000,
                FoodSales = 100000,
                AgeRating = "PG",
                Attendance = 345,
                Comments = "Successful screening",
                ReportStatus = "Completed",
                LastUpdate = new DateTime(2025, 5, 19, 21, 0, 0)
            },
            new MovieReportDetail
            {
                MovieId = 2,
                MovieName = "Godzilla vs Kong",
                City = "Medellín",
                Room = "Sala 3",
                Date = new DateTime(2025, 5, 18),
                MovieGenre = "Action",
                Distributor = "Warner Bros",
                Director = "Ana García",
                Projectionist = "Pedro Ruiz",
                StartTime = "18:30",
                EndTime = "20:45",
                DurationMinutes = 135,
                Language = "English",
                Subtitled = false,
                ScreenType = "3D",
                SoundType = "Dolby Digital",
                Format = "3D",
                TicketsSold = 420,
                BoxOffice = 3500000,
                Tax = 500000,
                Discount = 75000,
                NetIncome = 2925000,
                Occupancy = 92,
                PopcornSales = 600000,
                DrinkSales = 250000,
                FoodSales = 130000,
                AgeRating = "PG-13",
                Attendance = 415,
                Comments = "Full house",
                ReportStatus = "Completed",
                LastUpdate = new DateTime(2025, 5, 18, 22, 10, 0)
            }
            // Agrega más registros si quieres
        };

        ShowDetailCommand = new Command<MovieReportDetail>(async (selectedReport) =>
        {
            if (selectedReport != null)
            {
                await Shell.Current.GoToAsync(nameof(MovieReportDetailPage),
                    new Dictionary<string, object> { ["ReportDetail"] = selectedReport });
            }
        });
    }
}