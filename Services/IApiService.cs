using System;
using AppReports.Models;

namespace AppReports.Services;

public interface IApiService
{
    Task<User> LoginAsync(string username, string password);
    Task<List<Movie>> GetMoviesAsync();
    Task<ReportHeader> GetReportHeaderAsync();
    Task<ReportDetailsRoot> GetReportDetailsRootAsync();
}
