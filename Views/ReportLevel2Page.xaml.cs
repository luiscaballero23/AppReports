using AppReports.ViewModels;

namespace AppReports.Views;

public partial class ReportLevel2Page : ContentPage, IQueryAttributable
{
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