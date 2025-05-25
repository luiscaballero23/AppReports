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
        await Task.Delay(300); // Simula la latencia de red

        return new List<Movie>
    {
        new Movie { Id = 1, Name = "CAPTAIN AMERICA: BRAVE NEW WORLD - 3D" },
        new Movie { Id = 2, Name = "GARFIELD: FUERA DE CASA - 2D" },
        new Movie { Id = 3, Name = "DEADPOOL & WOLVERINE - 3D" },
        new Movie { Id = 4, Name = "EL PLANETA DE LOS SIMIOS: NUEVO REINO - 2D" }
    };
    }

    public async Task<List<Movie>> GetMoviesAsyncJson()
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

        return new ReportHeader
        {
            OriginalTitle = "CAPTAIN AMERICA: BRAVE NEW WORLD",
            LocalTitle = "CAPITÁN AMÉRICA: UN NUEVO MUNDO",
            ReleaseDate = new DateTime(2025, 2, 13),
            NroPrints = 0,
            Distributor = "DISNEY",
            Censorship = "07 YEARS"
        };
    }

    public async Task<ReportHeader> GetReportHeaderAsyncJson()
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        using var streamHeader = assembly.GetManifestResourceStream("AppReports.Assets.report-header.json");
        using var readerHeader = new StreamReader(streamHeader);
        string jsonHeader = readerHeader.ReadToEnd();
        return JsonSerializer.Deserialize<ReportHeader>(jsonHeader);
    }

    public async Task<ReportDetailsRoot> GetReportDetailsRootAsync()
    {
        await Task.Delay(300); // Simula latencia de red

        return new ReportDetailsRoot
        {
            ReportDetails = new List<ReportDetail>
        {
            new ReportDetail
            {
                Name = "CINE COLOMBIA",
                Columns = new List<ColumnValue>
                {
                    new() { ColumnHeader = "Screen Index (SI)", Value = "135.429" },
                    new() { ColumnHeader = "Sat - 2025-02-22", Value = "507,876,000" },
                    new() { ColumnHeader = "Sun - 2025-02-23", Value = "441,342,200" },
                    new() { ColumnHeader = "Mon - 2025-02-24", Value = "66,675,900" },
                    new() { ColumnHeader = "Tue - 2025-02-25", Value = "87,172,300" },
                    new() { ColumnHeader = "Wed - 2025-02-26", Value = "131,249,000" },
                    new() { ColumnHeader = "Thu - 2025-02-27", Value = "70,394,300" },
                    new() { ColumnHeader = "Fri - 2025-02-28", Value = "142,624,100" },
                    new() { ColumnHeader = "Wknd", Value = "1,103,086,400" },
                    new() { ColumnHeader = "Wk GBO", Value = "1,447,333,800" },
                    new() { ColumnHeader = "Wk GBO/SI", Value = "10,687,030" },
                    new() { ColumnHeader = "Market Share Wk", Value = "42.51%" },
                    new() { ColumnHeader = "Cumulative", Value = "4,750,093,800" },
                    new() { ColumnHeader = "Market Share Cumulative", Value = "42.64%" }
                }
            },
            new ReportDetail
            {
                Name = "CINEMARK",
                Columns = new List<ColumnValue>
                {
                    new() { ColumnHeader = "Screen Index (SI)", Value = "101.144" },
                    new() { ColumnHeader = "Sat - 2025-02-22", Value = "218,291,407" },
                    new() { ColumnHeader = "Sun - 2025-02-23", Value = "188,714,666" },
                    new() { ColumnHeader = "Mon - 2025-02-24", Value = "24,119,500" },
                    new() { ColumnHeader = "Tue - 2025-02-25", Value = "28,873,000" },
                    new() { ColumnHeader = "Wed - 2025-02-26", Value = "41,042,000" },
                    new() { ColumnHeader = "Thu - 2025-02-27", Value = "20,302,000" },
                    new() { ColumnHeader = "Fri - 2025-02-28", Value = "39,138,000" },
                    new() { ColumnHeader = "Wknd", Value = "431,006,073" },
                    new() { ColumnHeader = "Wk GBO", Value = "560,280,573" },
                    new() { ColumnHeader = "Wk GBO/SI", Value = "5,539,882" },
                    new() { ColumnHeader = "Market Share Wk", Value = "19.61%" },
                    new() { ColumnHeader = "Cumulative", Value = "2,023,095,640" },
                    new() { ColumnHeader = "Market Share Cumulative", Value = "18.16%" }
                }
            }
            }
        };
    }

    public async Task<ReportDetailsRoot> GetReportDetailsRootAsyncJson()
    {
        await Task.Delay(300); // Simula la latencia de red

        var assembly = typeof(App).Assembly;
        using var streamDetails = assembly.GetManifestResourceStream("AppReports.Assets.report-details-exhibitors.json");
        using var readerDetails = new StreamReader(streamDetails);
        string jsonDetails = readerDetails.ReadToEnd();
        return JsonSerializer.Deserialize<ReportDetailsRoot>(jsonDetails);
    }

}
