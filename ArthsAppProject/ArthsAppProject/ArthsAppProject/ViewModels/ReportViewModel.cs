using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using Microcharts;
using SkiaSharp;
using Microcharts.Forms;

namespace ArthsAppProject.ViewModels
{
    public class ReportViewModel : AppMapViewModelBase
    {
        private Chart chart;
        public Chart Chart
        {
            get { return chart; }
            set
            {
                chart = value;
                RaisePropertyChanged(() => Chart);
            }
        }

        public ReportViewModel(INavigationService navigationService) : base(navigationService)
        {
            var entries = new[]
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                Color = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                Label = "February",
                ValueLabel = "400",
                Color = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                Label = "March",
                ValueLabel = "-100",
                Color = SKColor.Parse("#90D585")
                }
            };

            Chart = new BarChart() { Entries = entries };
        }
    }
}
