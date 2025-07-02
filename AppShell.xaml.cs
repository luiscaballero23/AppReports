using AppReports.Views;

namespace AppReports;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("ReportFilterPage", typeof(ReportFilterPage));
        Routing.RegisterRoute("ReportLevel1Page", typeof(ReportLevel1Page));
        Routing.RegisterRoute("ReportLevel2Page", typeof(ReportLevel2Page));
        Routing.RegisterRoute("ReportLevel3Page", typeof(ReportLevel3Page));
    }

    private async void OnSalirClicked(object sender, EventArgs e)
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Confirmación",
            "¿Deseas cerrar sesión?",
            "Sí",
            "No");

        if (confirm)
        {
            (Application.Current as App).MainPage = new NavigationPage(new LoginPage());
        }
    }
}
