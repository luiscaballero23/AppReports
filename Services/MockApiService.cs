using System;
using System.Reflection;
using System.Text.Json;
using AppReports.Models;

namespace AppReports.Services;

public class MockApiService : IApiService
{
    public async Task<User> LoginAsync(string username, string password)
    {
        await Task.Delay(500); // Simula una llamada de red

        if (username == "Admin" && password == "1234")
        {
            return new User { Username = "admin", Token = "fake-token-123" };
        }
        return null;
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var assembly = typeof(App).Assembly;
        using Stream stream = assembly.GetManifestResourceStream("AppReports.Assets.movies.json");
        using StreamReader reader = new(stream);
        string json = reader.ReadToEnd();

        try
        {
            var result = JsonSerializer.Deserialize<MoviesRoot>(json);
            Console.WriteLine(result?.Movies?.Count);
            return result?.Movies ?? new List<Movie>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return new List<Movie>();
        }
    }

    public async Task<ReportHeader> GetReportHeaderAsync()
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        using var streamHeader = assembly.GetManifestResourceStream("AppReports.Assets.report-header.json");
        using var readerHeader = new StreamReader(streamHeader);
        string jsonHeader = readerHeader.ReadToEnd();
        return JsonSerializer.Deserialize<ReportHeader>(jsonHeader);
    }

    public async Task<ReportLevel1Root> GetReportDetailsRootAsync()
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        using var streamDetails = assembly.GetManifestResourceStream("AppReports.Assets.report-details-exhibitors.json");
        using var readerDetails = new StreamReader(streamDetails);
        string jsonDetails = readerDetails.ReadToEnd();
        return JsonSerializer.Deserialize<ReportLevel1Root>(jsonDetails);
    }

    public async Task<ReportLevel2Root> GetReportLevel2RootAsync(string exhibitorId)
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        // Puedes ajustar el nombre del archivo según el exhibidor si quieres diferenciar por exhibidor
        using var stream = assembly.GetManifestResourceStream("AppReports.Assets.report-details-multiplexes.json");
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<ReportLevel2Root>(json);
    }

    public async Task<ReportLevel3Root> GetReportLevel3RootAsync(string multiplexId)
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        // Puedes ajustar el nombre del archivo según el exhibidor si quieres diferenciar por exhibidor
        using var stream = assembly.GetManifestResourceStream("AppReports.Assets.report-details-rooms.json");
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<ReportLevel3Root>(json);
    }

}
