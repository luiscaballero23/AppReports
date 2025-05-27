using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel2ViewModel : INotifyPropertyChanged, IQueryAttributable
{
    private readonly IApiService _apiService;

    public string ReportName { get; set; }

    private ReportHeader _header;
    public ReportHeader Header
    {
        get => _header;
        set { _header = value; OnPropertyChanged(); }
    }

    private string _exhibitorName;
    public string ExhibitorName
    {
        get => _exhibitorName;
        set { _exhibitorName = value; OnPropertyChanged(); }
    }

    public ObservableCollection<ReportDetail> Multiplexes { get; set; } = new();
    public ObservableCollection<ColumnValue> Totals { get; set; } = new();

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public ICommand GoToLevel3Command { get; }

    public ReportLevel2ViewModel(string exhibitorName = null)
    {
        _apiService = new MockApiService();
        ExhibitorName = exhibitorName ?? "CINE COLOMBIA"; // Por defecto
        GoToLevel3Command = new Command<ReportDetail>(OnGoToLevel3);
        LoadDataAsync();
    }

    public ReportLevel2ViewModel()
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("exhibitorName"))
        {
            ExhibitorName = query["exhibitorName"]?.ToString();
            LoadDataAsync(); // Vuelve a cargar con el nuevo valor recibido
        }
    }

    private async void LoadDataAsync()
    {
        IsBusy = true;
        Header = await _apiService.GetReportHeaderAsync();
        var root = await _apiService.GetReportLevel2RootAsync(ExhibitorName);

        Multiplexes.Clear();
        foreach (var multiplex in root.Multiplexes)
            Multiplexes.Add(multiplex);

        Totals.Clear();
        foreach (var total in root.Totals)
            Totals.Add(total);

        IsBusy = false;
    }

    private async void OnGoToLevel3(ReportDetail exhibitor)
    {
        if (exhibitor == null) return;

        await Shell.Current.GoToAsync($"ReportLevel3Page");
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}