using AppReports.Models;

namespace AppReports.Views;

[QueryProperty(nameof(ReportDetail), "ReportDetail")]
public partial class MovieReportDetailPage : ContentPage
{
	private MovieReportDetail _reportDetail;
    public MovieReportDetail ReportDetail
    {
        get => _reportDetail;
        set
        {
            _reportDetail = value;
            BindingContext = value;
        }
    }
	public MovieReportDetailPage()
	{
		InitializeComponent();
	}
}