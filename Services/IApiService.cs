using System;
using AppReports.Models;

namespace AppReports.Services;

public interface IApiService
{
    Task<User> LoginAsync(string username, string password);
    Task<List<Movie>> GetMoviesAsync();
    Task<ReportHeader> GetReportHeaderAsync();
    Task<ReportLevel1Root> GetReportDetailsRootAsync();
    Task<ReportLevel2Root> GetReportLevel2RootAsync(string exhibitorId);
    Task<ReportLevel3Root> GetReportLevel3RootAsync(string multiplexId);
}
