using AppReports.Views;

namespace AppReports;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("ReportFilterPage", typeof(ReportFilterPage));
        Routing.RegisterRoute("ReportLevel1Page", typeof(ReportLevel1Page));
        Routing.RegisterRoute("ReportLevel2Page", typeof(ReportLevel2Page));
        Routing.RegisterRoute("ReportLevel3Page", typeof(ReportLevel3Page));

 
        Routing.RegisterRoute(nameof(MovieReportDetailPage), typeof(MovieReportDetailPage));
        Routing.RegisterRoute("TestView", typeof(AppReports.Views.TestView));
    }
}
