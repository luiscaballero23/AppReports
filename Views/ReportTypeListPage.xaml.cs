using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportTypeListPage : ContentPage
{
	public ReportTypeListPage()
	{
		InitializeComponent();
		var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportTypeListViewModel(filterService);
	}
}