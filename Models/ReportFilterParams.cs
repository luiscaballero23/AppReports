using System;

namespace AppReports.Models;

public class ReportFilterParams
{
    public string ReportId { get; set; }
    public string ReportName { get; set; }
    public int? MovieId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string SelectedOption { get; set; }
    public string ExhibitorId { get; set; }
    public string ExhibitorName { get; set; }
    public string MultiplexId { get; set; }
    public string MultiplexName { get; set; }
}
