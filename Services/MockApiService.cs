using System;
using AppReports.Models;

namespace AppReports.Services;

public class MockApiService : IApiService
{
    public async Task<User> LoginAsync(string username, string password)
    {
        await Task.Delay(500); // Simula una llamada de red

        if (username == "Admin" && password == "1234")
        {
            return new User { Username = "admin", Token = "fake-token-123" };
        }
        return null;
    }
}
