using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using Microcharts;
using SkiaSharp;
using PdfSharp.Xamarin.Forms;
using Xamarin.Forms;
using PdfSharp.Xamarin.Forms.Contracts;

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
                new Microcharts.Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(400)
                {
                Label = "February",
                ValueLabel = "400",
                Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.Entry(-100)
                {
                Label = "March",
                ValueLabel = "-100",
                Color = SKColor.Parse("#90D585")
                }
            };

            Chart = new LineChart() { Entries = entries };
        }

    }
}
