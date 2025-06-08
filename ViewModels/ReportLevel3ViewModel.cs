using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel3ViewModel : INotifyPropertyChanged
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

    private string _exhibitorName;
    public string ExhibitorName
    {
        get => _exhibitorName;
        set { _exhibitorName = value; OnPropertyChanged(); }
    }

    private string _multiplexesName;
    public string MultiplexesName
    {
        get => _multiplexesName;
        set { _multiplexesName = value; OnPropertyChanged(); }
    }

    public ObservableCollection<ReportDetail> Rooms { get; set; } = new();
    public ObservableCollection<ColumnValue> Totals { get; set; } = new();

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    public ReportLevel3ViewModel(IFilterService filterService)
    {
        _apiService = new MockApiService();
        _filterService = filterService;

        ExhibitorName = _filterService.Filters.ExhibitorName;
        MultiplexesName = _filterService.Filters.MultiplexName;
        LoadDataAsync(_filterService.Filters.MultiplexId);
    }

    private async void LoadDataAsync(string multiplexId)
    {
        IsBusy = true;
        Header = await _apiService.GetReportHeaderAsync();
        var root = await _apiService.GetReportLevel3RootAsync(multiplexId);

        Rooms.Clear();
        foreach (var multiplex in root.Rooms)
        Rooms.Add(multiplex);

        Totals.Clear();
        foreach (var total in root.Totals)
        Totals.Add(total);

        IsBusy = false;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
