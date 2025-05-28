using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppReports.Models;

namespace AppReports.ViewModels;

public class ReportTypeListViewModel
{
    public ObservableCollection<ReportType> ReportTypes { get; set; }
    public ICommand SelectReportTypeCommand { get; }

    public ReportTypeListViewModel()
    {
        ReportTypes = new ObservableCollection<ReportType>
        {
            new ReportType { Name = "Competetive Projected", Key = "competitive-projected",Icon = "ic_competitive.png" },
            new ReportType { Name = "Exhibitor Market Share", Key = "exhibitor-market-share",Icon = "ic_competitive.png" },
            new ReportType { Name = "Film Running", Key = "film-running",Icon = "ic_competitive.png" },
            new ReportType { Name = "FRWK/MDWK", Key = "frwk-mdwk",Icon = "ic_competitive.png" }
        };

        SelectReportTypeCommand = new Command<ReportType>(OnSelectReportType);
    }

    private async void OnSelectReportType(ReportType selectedType)
    {
        if (selectedType == null)
            return;

        await Shell.Current.GoToAsync($"ReportFilterPage?reportName={selectedType.Name}");
    }
}