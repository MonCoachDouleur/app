using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArthsAppProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListExercices : ContentPage
	{
		public ListExercices ()
		{
			InitializeComponent ();
            ListExos.ItemsSource = new Exercise().GetListAsync();
        }
	}
}