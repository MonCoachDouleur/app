using System;
using Xamarin.Forms;

namespace ArthsAppProject.Views
{
    public partial class Questions : ContentPage
    {
        public Questions()
        {
            InitializeComponent();
        }
        public void OnXamlClicked(object sender, EventArgs args)
        {

            Navigation.PushAsync(new XamlExample());
        }
        public void OnCodeClicked(object sender, EventArgs args)
        {

            Navigation.PushAsync(new CodeEaxmple());
        }
    }
}