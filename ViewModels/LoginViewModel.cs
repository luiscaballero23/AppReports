using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppReports.Services;

namespace AppReports.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly IApiService _apiService;

    private string _username;
    private string _password;
    private string _message;
    private bool _showMessage;

    public string Username
    {
        get => _username;
        set { _username = value; OnPropertyChanged(); }
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(); }
    }

    public string Message
    {
        get => _message;
        set { _message = value; OnPropertyChanged(); }
    }

    public bool ShowMessage
    {
        get => _showMessage;
        set { _showMessage = value; OnPropertyChanged(); }
    }

    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        _apiService = new MockApiService();
        LoginCommand = new Command(OnLogin);
    }

    private async void OnLogin()
    {
        ShowMessage = false;
        var user = await _apiService.LoginAsync(Username, Password);
        if (user != null)
        {
            await Shell.Current.GoToAsync("///ReportFilterPage");
        }
        else
        {
            Message = "Incorrect username or password";
            ShowMessage = true;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
