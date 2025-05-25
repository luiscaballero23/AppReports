using System;
using AppReports.Models;

namespace AppReports.Services;

public interface IApiService
{
    Task<User> LoginAsync(string username, string password);
    Task<List<Movie>> GetMoviesAsync();
    Task<List<Movie>> GetMoviesAsyncJson();
    Task<ReportHeader> GetReportHeaderAsync();
    Task<ReportHeader> GetReportHeaderAsyncJson();
    Task<ReportDetailsRoot> GetReportDetailsRootAsync();
    Task<ReportDetailsRoot> GetReportDetailsRootAsyncJson();
}
