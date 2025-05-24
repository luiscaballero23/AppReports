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
    
     [JsonPropertyName("nroPrints")]
    public int NroPrints { get; set; }

    [JsonPropertyName("distributor")]
    public string Distributor { get; set; }

    [JsonPropertyName("censorship")]
    public string Censorship { get; set; }
}

public class ColumnValue
{
    [JsonPropertyName("columnHeader")]  
    public string ColumnHeader { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class ReportDetail
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("columns")]
    public List<ColumnValue> Columns { get; set; }
}

public class ReportDetailsRoot
{
    [JsonPropertyName("reportDetails")]
    public List<ReportDetail> ReportDetails { get; set; }
}