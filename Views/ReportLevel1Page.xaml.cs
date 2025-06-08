using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportLevel1Page : ContentPage
{
    public ReportLevel1Page()
    {
        InitializeComponent();
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportLevel1ViewModel(filterService);
	}
}