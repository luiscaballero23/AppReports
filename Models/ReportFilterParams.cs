using System;

namespace AppReports.Models;

public class ReportFilterParams
{
    public string ReportName { get; set; }
    public int? MovieId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string SelectedOption { get; set; }
}
