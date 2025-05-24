using System;
using System.Text.Json.Serialization;

namespace AppReports.Models;

public class ReportHeader
{
    [JsonPropertyName("originalTitle")]
    public string OriginalTitle { get; set; }

    [JsonPropertyName("localTitle")]
    public string LocalTitle { get; set; }

    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("distributor")]
    public string Distributor { get; set; }

    [JsonPropertyName("censorship")]
    public string Censorship { get; set; }
}

public class ColumnValue
{
    public string ColumnHeader { get; set; }
    public string Value { get; set; }
}

public class ReportDetail
{
    public string Name { get; set; }
    public List<ColumnValue> Columns { get; set; }
}

public class ReportDetailsRoot
{
    [JsonPropertyName("reportDetails")]
    public List<ReportDetail> ReportDetails { get; set; }
}

public class ReportHeaderRoot
{
    [JsonPropertyName("originalTitle")]
    public string OriginalTitle { get; set; }

    [JsonPropertyName("localTitle")]
    public string LocalTitle { get; set; }

    [JsonPropertyName("releaseDate")]
    public string ReleaseDate { get; set; }

    [JsonPropertyName("distributor")]
    public string Distributor { get; set; }
    
    [JsonPropertyName("censorship")]
    public string Censorship { get; set; }
}