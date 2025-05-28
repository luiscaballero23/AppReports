using AppReports.Services;
using AppReports.ViewModels;

namespace AppReports.Views;

[QueryProperty(nameof(ExhibitorId), "exhibitorId")]
[QueryProperty(nameof(ExhibitorName), "exhibitorName")]
public partial class ReportLevel2Page : ContentPage, IQueryAttributable
{
    public string ExhibitorId { get; set; }
    public string ExhibitorName { get; set; }

    public ReportLevel2Page()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("exhibitorId", out var exhibitorIdObj) && exhibitorIdObj is string exhibitorId)
            ExhibitorId = exhibitorId;
        if (query.TryGetValue("exhibitorName", out var exhibitorNameObj) && exhibitorNameObj is string exhibitorName)
            ExhibitorName = exhibitorName;
        
        var filterService = MauiProgram.Services.GetService<IFilterService>();
        filterService.Filters.ExhibitorId = ExhibitorId;
        filterService.Filters.ExhibitorName = ExhibitorName;
        
        BindingContext = new ReportLevel2ViewModel(filterService);
    }
}