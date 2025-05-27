using System;
using AppReports.Models;

namespace AppReports.Services;

public class FilterService : IFilterService
{
    public ReportFilterParams Filters { get; set; } = new();

    public void Reset()
    {
        Filters = new ReportFilterParams();
    }
}
