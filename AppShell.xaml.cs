using AppReports.Views;

namespace AppReports;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("ReportFilterPage", typeof(AppReports.Views.ReportFilterPage));
        Routing.RegisterRoute("ReportLevel1Page", typeof(AppReports.Views.ReportLevel1Page));

 
        Routing.RegisterRoute(nameof(MovieReportDetailPage), typeof(MovieReportDetailPage));
        Routing.RegisterRoute("TestView", typeof(AppReports.Views.TestView));
    }
}
