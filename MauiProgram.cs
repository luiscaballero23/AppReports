using AppReports.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace AppReports;

public static class MauiProgram
{
	public static MauiApp App { get; private set; }
	public static IServiceProvider Services => App.Services;
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IFilterService, FilterService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		App = builder.Build();
        return App;
	}
}
