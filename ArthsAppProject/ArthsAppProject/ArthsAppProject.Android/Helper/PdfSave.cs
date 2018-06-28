using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ArthsAppProject.Droid.Helper;
using PdfSharpCore.Pdf;

[assembly: Xamarin.Forms.Dependency(typeof(PdfSave))]
namespace ArthsAppProject.Droid.Helper
{
    public class PdfSave : IPdfSave
    {
        public void Save(PdfDocument doc, string fileName)
        {
            string path = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + fileName);

            doc.Save(path);
            doc.Close();

            global::Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                title: "Success",
                message: $"Your PDF generated and saved @ {path}",
                cancel: "OK");
        }
    }
}