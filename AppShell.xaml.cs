namespace AppReports;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("ReportsPage", typeof(AppReports.Views.ReportsPage));
    }
}
