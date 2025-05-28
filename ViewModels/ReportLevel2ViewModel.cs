using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel2ViewModel : INotifyPropertyChanged
{
    private readonly IApiService _apiService;
    private readonly IFilterService _filterService;

    private string _reportName;
    public string ReportName
    {
        get => _reportName;
        set { _reportName = value; OnPropertyChanged(); }
    }

    private ReportHeader _header;
    public ReportHeader Header
    {
        get => _header;
        set { _header = value; OnPropertyChanged(); }
    }

    private string _exhibitorId;
    public string ExhibitorId
    {
        get => _exhibitorId;
        set { _exhibitorId = value; OnPropertyChanged(); }
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

    public ReportLevel2ViewModel(IFilterService filterService)
    {
        _apiService = new MockApiService();
        _filterService = filterService;
        
        ReportName = _filterService.Filters.ReportName;
        ExhibitorId = _filterService.Filters.ExhibitorId;
        ExhibitorName = _filterService.Filters.ExhibitorName;
        GoToLevel3Command = new Command<ReportDetail>(OnGoToLevel3);
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        IsBusy = true;
        Header = await _apiService.GetReportHeaderAsync();
        var root = await _apiService.GetReportLevel2RootAsync(ExhibitorId);

        Multiplexes.Clear();
        foreach (var multiplex in root.Multiplexes)
            Multiplexes.Add(multiplex);

        Totals.Clear();
        foreach (var total in root.Totals)
            Totals.Add(total);

        IsBusy = false;
    }

    private async void OnGoToLevel3(ReportDetail multiplexes)
    {
        if (multiplexes == null) return;

        var filterService = MauiProgram.Services.GetService<IFilterService>();
        filterService.Filters.MultiplexId = multiplexes.Id;
        filterService.Filters.MultiplexName = multiplexes.Name;

        await Shell.Current.GoToAsync($"ReportLevel3Page");
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}