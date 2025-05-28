using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportLevel3ViewModel : INotifyPropertyChanged
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
         
        ReportName = _filterService.Filters.ReportName;
        ExhibitorName = _filterService.Filters.ExhibitorName;
        MultiplexesName = _filterService.Filters.MultiplexesName;
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        IsBusy = true;
        Header = await _apiService.GetReportHeaderAsync();
        //var root = await _apiService.GetReportLevel2RootAsync(ExhibitorName);

        //Multiplexes.Clear();
        //foreach (var multiplex in root.Multiplexes)
        //Multiplexes.Add(multiplex);

        //Totals.Clear();
        //foreach (var total in root.Totals)
        //Totals.Add(total);

        IsBusy = false;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
