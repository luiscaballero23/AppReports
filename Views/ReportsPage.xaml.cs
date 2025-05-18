using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ReportName), "reportName")]
[QueryProperty(nameof(City), "city")]
[QueryProperty(nameof(DateFrom), "from")]
[QueryProperty(nameof(DateTo), "to")]
public partial class ReportsPage : ContentPage
{
	private string _reportName;
    public string ReportName
    {
        get => _reportName;
        set
        {
            _reportName = value;
            Title = value ?? "Reportes";
            UpdateInfoLabel();
        }
    }

	private string _city;
    public string City
    {
        get => _city;
        set { _city = value; UpdateInfoLabel(); }
    }
    private string _dateFrom;
    public string DateFrom
    {
        get => _dateFrom;
        set { _dateFrom = value; UpdateInfoLabel(); }
    }
    private string _dateTo;
    public string DateTo
    {
        get => _dateTo;
        set { _dateTo = value; UpdateInfoLabel(); }
    }

	public ReportsPage()
	{
		InitializeComponent();
	}

	void UpdateInfoLabel()
    {
        if (InfoLabel != null)
            InfoLabel.Text = $"Reporte: {ReportName}\nCiudad: {City}\nFechas: {DateFrom} a {DateTo}";
    }
}