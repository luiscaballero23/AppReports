using System;

namespace AppReports.Models;

public class MovieReportDetail
{
    public int MovieId { get; set; }
    public string MovieName { get; set; }
    public string City { get; set; }
    public string Room { get; set; }
    public DateTime Date { get; set; }
    public string MovieGenre { get; set; }
    public string Distributor { get; set; }
    public string Director { get; set; }
    public string Projectionist { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int DurationMinutes { get; set; }
    public string Language { get; set; }
    public bool Subtitled { get; set; }
    public string ScreenType { get; set; }
    public string SoundType { get; set; }
    public string Format { get; set; }
    public int TicketsSold { get; set; }
    public decimal BoxOffice { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal NetIncome { get; set; }
    public int Occupancy { get; set; }
    public decimal PopcornSales { get; set; }
    public decimal DrinkSales { get; set; }
    public decimal FoodSales { get; set; }
    public string AgeRating { get; set; }
    public int Attendance { get; set; }
    public string Comments { get; set; }
    public string ReportStatus { get; set; }
    public DateTime LastUpdate { get; set; }
}

