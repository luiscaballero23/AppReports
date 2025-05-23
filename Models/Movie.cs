using System;
using System.Text.Json.Serialization;

namespace AppReports.Models;

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class MoviesRoot
{
    [JsonPropertyName("movies")]
    public List<Movie> Movies { get; set; }
}