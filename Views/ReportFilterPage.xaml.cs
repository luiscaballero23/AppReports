using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportFilterPage : ContentPage
{
    public ReportFilterPage()
    {
        InitializeComponent();
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportFilterViewModel(filterService);
	}
}