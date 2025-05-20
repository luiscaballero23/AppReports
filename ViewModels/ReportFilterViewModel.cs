using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppReports.Models;

namespace AppReports.ViewModels;

public class ReportFilterViewModel : INotifyPropertyChanged
{   
    public string ReportName { get; set; }
    public ObservableCollection<string> Cities { get; set; }
    
    private string _selectedCity;
    public string SelectedCity
    {
        get => _selectedCity;
        set { _selectedCity = value; OnPropertyChanged(); }
    }

    private DateTime _dateFrom = DateTime.Parse("2025-05-01");
    public DateTime DateFrom
    {
        get => _dateFrom;
        set { _dateFrom = value; OnPropertyChanged(); }
    }

    private DateTime _dateTo = DateTime.Today;
    public DateTime DateTo
    {
        get => _dateTo;
        set { _dateTo = value; OnPropertyChanged(); }
    }

    public ICommand SearchCommand { get; }

    public ReportFilterViewModel()
    {        
        Cities = new ObservableCollection<string>
            {
                "Bogotá",
                "Medellín",
                "Cali",
                "Barranquilla"
            };

        SearchCommand = new Command(OnSearch);
    }

    private async void OnSearch()
    {
        // Valida que todos los campos estén llenos si quieres
        if (string.IsNullOrWhiteSpace(SelectedCity))
            return;
        
        // Navega pasando los parámetros seleccionados        
        await Shell.Current.GoToAsync($"ReportsPage?reportName={ReportName}&city={SelectedCity}&from={DateFrom:yyyy-MM-dd}&to={DateTo:yyyy-MM-dd}");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}