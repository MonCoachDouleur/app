using PdfSharp.Xamarin.Forms;
using System;
using Xamarin.Forms;

namespace ArthsAppProject.Views
{
    public partial class Report : ContentPage
    {
        public Report()
        {
            InitializeComponent();
        }

        private void GeneratePDF(object sender, EventArgs e)
        {
            var pdf = PDFManager.GeneratePDFFromView(chart);

            DependencyService.Get<IPdfSave>().Save(pdf, "reportArthApp.pdf");
        }
    }
}