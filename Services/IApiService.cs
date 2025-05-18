using System;
using AppReports.Models;

namespace AppReports.Services;

public interface IApiService
{
    Task<User> LoginAsync(string username, string password);
}
