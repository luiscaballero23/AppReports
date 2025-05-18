using System;

namespace AppReports.Models;

public class Report
{
    public string MovieName { get; set; }
    public string City { get; set; }
    public string Room { get; set; }
    public DateTime Date { get; set; }
    public decimal BoxOffice { get; set; }
    public string Status { get; set; } // "Pending" o "Completed"
}
