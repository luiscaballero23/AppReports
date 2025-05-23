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
    public string ReportName { get; set; }
    public ObservableCollection<Movie> Movies { get; set; } = new();

    private Movie _selectedMovie;
    public Movie SelectedMovie
    {
        get => _selectedMovie;
        set { _selectedMovie = value; OnPropertyChanged(); }
    }

    private DateTime _dateFrom = DateTime.Parse("2025-05-01");
    public DateTime DateFrom
    {
        get => _dateFrom;
        set { _dateFrom = value; OnPropertyChanged(); }
    }

    private DateTime _dateTo = DateTime.Today;
    public DateTime DateTo
    {
        get => _dateTo;
        set { _dateTo = value; OnPropertyChanged(); }
    }

    private string _selectedOption;
    public string SelectedOption
    {
        get => _selectedOption;
        set { _selectedOption = value; OnPropertyChanged(); }
    }

    public ICommand SearchCommand { get; }

    private readonly IApiService _apiService;

    public ReportFilterViewModel()
    {        
        _apiService = new MockApiService();
        LoadMoviesAsync();

        SearchCommand = new Command(OnSearch);
    }
    
    private async void LoadMoviesAsync()
    {
        var list = await _apiService.GetMoviesAsync();
        Movies.Clear();
        foreach (var movie in list)
            Movies.Add(movie);
    }

    private async void OnSearch()
    {
        if (SelectedMovie == null || string.IsNullOrWhiteSpace(SelectedOption))
            return;

        await Shell.Current.GoToAsync($"ReportsPage?reportName={ReportName}&movie={SelectedMovie.Id}&from={DateFrom:yyyy-MM-dd}&to={DateTo:yyyy-MM-dd}&option={SelectedOption}");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}