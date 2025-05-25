using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel1ViewModel : INotifyPropertyChanged
{
    public ReportHeader Header { get; set; }
    public ObservableCollection<ReportDetail> Details { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;
    
    private readonly IApiService _apiService;
    
    public ReportLevel1ViewModel()
    {
        _apiService = new MockApiService();
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        Header = await _apiService.GetReportHeaderAsync();

        // Notifica el cambio (si lo usas en binding)
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Header)));

        var rootDetails = await _apiService.GetReportDetailsRootAsync();

        Details.Clear();
        foreach (var detail in rootDetails.ReportDetails)
            Details.Add(detail);
    }
}
