using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ReportName), "reportName")]
[QueryProperty(nameof(City), "city")]
[QueryProperty(nameof(DateFrom), "from")]
[QueryProperty(nameof(DateTo), "to")]
public partial class ReportsPage : ContentPage
{
	string _reportName, _city, _dateFrom, _dateTo;

	public string ReportName
	{
		get => _reportName;
		set { _reportName = value; Title = value; }
	}
	public string City { get => _city; set => _city = value; }
	public string DateFrom { get => _dateFrom; set => _dateFrom = value; }
	public string DateTo { get => _dateTo; set => _dateTo = value; }

	public ReportsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Crea el ViewModel solo cuando los parámetros están listos
		if (!string.IsNullOrEmpty(ReportName) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(DateFrom) && !string.IsNullOrEmpty(DateTo))
		{
			DateTime dateFrom = DateTime.Parse(DateFrom);
			DateTime dateTo = DateTime.Parse(DateTo);
			BindingContext = new ReportsViewModel(ReportName, City, dateFrom, dateTo);
		}
	}
}