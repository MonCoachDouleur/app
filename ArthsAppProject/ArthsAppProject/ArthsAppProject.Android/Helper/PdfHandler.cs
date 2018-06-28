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
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;
using PdfSharp.Xamarin.Forms.Contracts;

[assembly: Xamarin.Forms.Dependency(typeof(PdfHandler))]
namespace ArthsAppProject.Droid.Helper
{
    class PdfHandler : IPDFHandler
    {
        public ImageSource GetImageSource()
        {
            return new AndroidImageSource();
        }
    }
}