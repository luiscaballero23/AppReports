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
        using Stream stream = assembly.GetManifestResourceStream("AppReports.Resources.movies.json");
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
}
