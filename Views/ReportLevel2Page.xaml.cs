using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportLevel2Page : ContentPage
{
    public ReportLevel2Page()
    {
        InitializeComponent();
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        BindingContext = new ReportLevel2ViewModel(filterService);
    }
}