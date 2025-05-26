using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel2ViewModel : INotifyPropertyChanged, IQueryAttributable
{
    private readonly IApiService _apiService;

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
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public ReportLevel2ViewModel(string exhibitorName = null)
    {
        _apiService = new MockApiService();
        ExhibitorName = exhibitorName ?? "CINE COLOMBIA"; // Por defecto
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
        var root = await _apiService.GetReportLevel2RootAsync(ExhibitorName);

        Multiplexes.Clear();
        foreach (var multiplex in root.Multiplexes)
            Multiplexes.Add(multiplex);

        Totals.Clear();
        foreach (var total in root.Totals)
            Totals.Add(total);

        IsBusy = false;
    }
}