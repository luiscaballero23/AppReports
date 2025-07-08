using AppReports.Services;
using AppReports.Views;

namespace AppReports;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		_ = TryAutoLoginAsync();
	}

	private async Task TryAutoLoginAsync()
    {
        try
        {
            string username = await SecureStorage.GetAsync("user");
            string password = await SecureStorage.GetAsync("pass");

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var _apiService = new MockApiService(); // O tu servicio real
                var user = await _apiService.LoginAsync(username, password);

                if (user != null)
                {
                    MainPage = new AppShell(); // usuario válido
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            // Loguea, ignora errores de SecureStorage en simulador
            System.Diagnostics.Debug.WriteLine($"AutoLogin fail: {ex.Message}");
        }

        // Si falla, muestra login
        MainPage = new NavigationPage(new LoginPage());
    }

}