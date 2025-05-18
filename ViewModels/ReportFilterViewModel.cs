using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppReports.ViewModels;

public class ReportType
{
    public string Name { get; set; }
}

public class ReportFilterViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ReportType> ReportTypes { get; set; }
    public ObservableCollection<string> Cities { get; set; }

    private ReportType _selectedReportType;
    public ReportType SelectedReportType
    {
        get => _selectedReportType;
        set { _selectedReportType = value; OnPropertyChanged(); }
    }

    private string _selectedCity;
    public string SelectedCity
    {
        get => _selectedCity;
        set { _selectedCity = value; OnPropertyChanged(); }
    }

    private DateTime _dateFrom = DateTime.Today.AddDays(-7);
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
        // Mock data
        ReportTypes = new ObservableCollection<ReportType>
            {
                new ReportType { Name = "Taquilla" },
                new ReportType { Name = "Por Salas" },
                new ReportType { Name = "General" }
            };
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
        if (SelectedReportType == null || string.IsNullOrWhiteSpace(SelectedCity))
            return;

        // Navega pasando los parámetros seleccionados        
        await Shell.Current.GoToAsync($"ReportsPage?reportName={SelectedReportType.Name}&city={SelectedCity}&from={DateFrom:yyyy-MM-dd}&to={DateTo:yyyy-MM-dd}");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}