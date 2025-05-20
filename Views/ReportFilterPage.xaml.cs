using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ReportName), "reportName")]
public partial class ReportFilterPage : ContentPage
{
	private string _reportName;
    public string ReportName
    {
        get => _reportName;
        set
        {
            _reportName = value;
            Title = value; // Opcional: mostrar en la barra superior

            // Pásalo al ViewModel
            if (BindingContext is ReportFilterViewModel vm)
                vm.ReportName = value;
        }
    }

	public ReportFilterPage()
	{
		InitializeComponent();
	}
}