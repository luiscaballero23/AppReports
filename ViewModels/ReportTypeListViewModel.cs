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
        // Puedes ajustar y traducir los nombres/descripciones según tu negocio
        ReportTypes = new ObservableCollection<ReportType>
            {
                new ReportType { Name = "Taquilla", Description = "La taquilla o boletería es el sitio donde se venden las entradas para acceder a un evento público." },
                new ReportType { Name = "Por Salas", Description = "Reporte de ventas por sala de cine." },
                new ReportType { Name = "General", Description = "Reporte general de todas las películas." }
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