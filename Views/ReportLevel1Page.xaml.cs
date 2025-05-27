using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ReportName), "reportName")]
[QueryProperty(nameof(MovieId), "movie")]
[QueryProperty(nameof(DateFrom), "from")]
[QueryProperty(nameof(DateTo), "to")]
[QueryProperty(nameof(SelectedOption), "option")]
public partial class ReportLevel1Page : ContentPage
{
	string _reportName, _movieId, _dateFrom, _dateTo, _option;

    public string ReportName
    {
        get => _reportName;
        set
        {
            _reportName = value;
            Title = value; // Opcional: mostrar en la barra superior

            // Pásalo al ViewModel
            if (BindingContext is ReportLevel1ViewModel vm)
                vm.ReportName = value;
        }
    }
	public string MovieId { get => _movieId; set => _movieId = value; }
	public string DateFrom { get => _dateFrom; set => _dateFrom = value; }
	public string DateTo { get => _dateTo; set => _dateTo = value; }
	public string SelectedOption { get => _option; set => _option = value; }

    public ReportLevel1Page()
    {
        InitializeComponent();
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportLevel1ViewModel(filterService);
	}
}