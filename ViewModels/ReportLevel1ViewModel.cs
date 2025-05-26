using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel1ViewModel : INotifyPropertyChanged
{
    private readonly IApiService _apiService;

    private ReportHeader _header;
    public ReportHeader Header
    {
        get => _header;
        set { _header = value; OnPropertyChanged(); }
    }
public ObservableCollection<ReportDetail> Details { get; set; } = new();

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand GoToLevel2Command { get; }
    
    public ReportLevel1ViewModel()
    {
        _apiService = new MockApiService();
         GoToLevel2Command = new Command<ReportDetail>(OnGoToLevel2);
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        IsBusy = true;

        Header = await _apiService.GetReportHeaderAsync();

        var rootDetails = await _apiService.GetReportDetailsRootAsync();

        Details.Clear();
        foreach (var detail in rootDetails.ReportDetails)
            Details.Add(detail);

        IsBusy = false;
    }

    private async void OnGoToLevel2(ReportDetail exhibitor)
    {
        if (exhibitor == null) return;
        // Navegación Shell pasando el nombre del exhibidor como query parameter
        await Shell.Current.GoToAsync($"ReportLevel2Page?exhibitorName={Uri.EscapeDataString(exhibitor.Name)}");
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
