using System;
using AppReports.Models;

namespace AppReports.Services;

public interface IFilterService
{
    ReportFilterParams Filters { get; set; }
    void Reset();
}
