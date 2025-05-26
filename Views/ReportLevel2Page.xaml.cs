using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ReportName), "reportName")]
public partial class ReportLevel2Page : ContentPage, IQueryAttributable
{
    string _reportName;

	public string ReportName
	{
		get => _reportName;
		set { _reportName = value; Title = value; }
	}

    public ReportLevel2Page()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("exhibitorName"))
        {
            string exhibitorName = query["exhibitorName"]?.ToString();
            BindingContext = new ReportLevel2ViewModel(exhibitorName);
        }
        else
        {
            BindingContext = new ReportLevel2ViewModel();
        }
    }
}