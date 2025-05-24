using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using AppReports.Models;

namespace AppReports.ViewModels;

public class ReportLevel1ViewModel : INotifyPropertyChanged
{
    public ReportHeader Header { get; set; }
    public ObservableCollection<ReportDetail> Details { get; set; } = new();

    public event PropertyChangedEventHandler PropertyChanged;
    
    public ReportLevel1ViewModel()
    {
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        // Cargar encabezado
        var assembly = typeof(App).Assembly;
        using var streamHeader = assembly.GetManifestResourceStream("AppReports.Resources.report-header.json");
        using var readerHeader = new StreamReader(streamHeader);
        string jsonHeader = readerHeader.ReadToEnd();
        var header = JsonSerializer.Deserialize<ReportHeader>(jsonHeader);
        Header = header;

        // Notifica el cambio (si lo usas en binding)
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Header)));

        // Cargar detalles
        using var streamDetails = assembly.GetManifestResourceStream("AppReports.Resources.report-details-exhibitors.json");
        using var readerDetails = new StreamReader(streamDetails);
        string jsonDetails = readerDetails.ReadToEnd();
        var rootDetails = JsonSerializer.Deserialize<ReportDetailsRoot>(jsonDetails);

        Details.Clear();
        foreach (var detail in rootDetails.ReportDetails)
            Details.Add(detail);
    }
}
