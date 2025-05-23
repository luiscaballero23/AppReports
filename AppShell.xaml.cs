using AppReports.Views;

namespace AppReports;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("ReportFilterPage", typeof(AppReports.Views.ReportFilterPage));
        Routing.RegisterRoute("ReportsPage", typeof(AppReports.Views.ReportsPage));
        Routing.RegisterRoute(nameof(MovieReportDetailPage), typeof(MovieReportDetailPage));
        Routing.RegisterRoute("TestView", typeof(AppReports.Views.TestView));
    }
}
