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
    private readonly IFilterService _filterService;
    public string ReportName
    {
        get => _filterService.Filters.ReportName;
        set { _filterService.Filters.ReportName = value; OnPropertyChanged(); }
    }

    private ReportHeader _header;
    public ReportHeader Header
    {
        get => _header;
        set { _header = value; OnPropertyChanged(); }
    }

    public ObservableCollection<ReportDetail> Exhibitors { get; set; } = new();
    public ObservableCollection<ColumnValue> Totals { get; set; } = new();

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand GoToLevel2Command { get; }

    public ReportLevel1ViewModel(IFilterService filterService)
    {
        _filterService = filterService;
        _apiService = new MockApiService();
        GoToLevel2Command = new Command<ReportDetail>(OnGoToLevel2);
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        IsBusy = true;
        Header = await _apiService.GetReportHeaderAsync();
        var root = await _apiService.GetReportDetailsRootAsync();

        Exhibitors.Clear();
        foreach (var multiplex in root.Exhibitors)
            Exhibitors.Add(multiplex);

        Totals.Clear();
        foreach (var total in root.Totals)
            Totals.Add(total);

        IsBusy = false;
    }

    private async void OnGoToLevel2(ReportDetail exhibitor)
    {
        if (exhibitor == null) return;
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        filterService.Filters.ExhibitorId = exhibitor.Id;
        filterService.Filters.ExhibitorName = exhibitor.Name;

        await Shell.Current.GoToAsync($"ReportLevel2Page");
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
