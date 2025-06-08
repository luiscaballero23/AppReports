using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppReports.Models;
using AppReports.Services;

namespace AppReports.ViewModels;

public class ReportFilterViewModel : INotifyPropertyChanged
{
    private readonly IApiService _apiService;
    private readonly IFilterService _filterService;
    public ObservableCollection<Movie> Movies { get; set; } = new();
    public string ReportName
    {
        get => _filterService.Filters.ReportName;
        set { _filterService.Filters.ReportName = value; OnPropertyChanged(); }
    }

    public Movie SelectedMovie
    {
        get => Movies.FirstOrDefault(m => m.Id == _filterService.Filters.MovieId);
        set
        {
            if (value != null)
            {
                _filterService.Filters.MovieId = value.Id;
                OnPropertyChanged();
            }
        }
    }
    public DateTime DateFrom
    {
        get => _filterService.Filters.DateFrom ?? DateTime.Today.AddDays(-7);
        set { _filterService.Filters.DateFrom = value; OnPropertyChanged(); }
    }

    public DateTime DateTo
    {
        get => _filterService.Filters.DateTo ?? DateTime.Today;
        set { _filterService.Filters.DateTo = value; OnPropertyChanged(); }
    }

    public string SelectedOption
    {
        get => _filterService.Filters.SelectedOption;
        set { _filterService.Filters.SelectedOption = value; OnPropertyChanged(); }
    }

    public ICommand SearchCommand { get; }

    public ReportFilterViewModel(IFilterService filterService)
    {
        _apiService = new MockApiService();
        _filterService = filterService;
        LoadMoviesAsync();

        SearchCommand = new Command(OnSearch);
    }

    private async void LoadMoviesAsync()
    {
        var list = await _apiService.GetMoviesAsync();
        Movies.Clear();
        foreach (var movie in list)
            Movies.Add(movie);

        if (_filterService.Filters.MovieId.HasValue)
            OnPropertyChanged(nameof(SelectedMovie));
    }

    private async void OnSearch()
    {
        if (!_filterService.Filters.MovieId.HasValue || string.IsNullOrWhiteSpace(SelectedOption))
            return;

        await Shell.Current.GoToAsync($"ReportLevel1Page");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}