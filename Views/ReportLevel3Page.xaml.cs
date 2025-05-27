using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportLevel3Page : ContentPage
{
	public ReportLevel3Page()
	{
		InitializeComponent();
		var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportLevel3ViewModel(filterService);
	}
}