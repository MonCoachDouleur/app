using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using Microcharts;
using SkiaSharp;
using ArthsAppProject.Helper;
using System.Collections.Generic;

namespace ArthsAppProject.ViewModels
{
    public class PainEvolutionViewModel : AppMapViewModelBase
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


        public PainEvolutionViewModel(INavigationService navigationService) : base(navigationService)
        {
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            loadDataInChart(idUser);
            
        }

        private async void loadDataInChart(int idUser)
        {
            User User = await App.Database.userRepo.GetWithChild(idUser);
            User.painList.Sort((pain1, pain2) => DateTime.Compare(pain1.date, pain2.date));
            List<Entry> entryList = new List<Entry>();

            foreach (var pain in User.painList)
            {
                entryList.Add(new Entry(pain.painLevel)
                {
                    Label = pain.date.ToString("dd/MM/yyyy"),
                    ValueLabel = pain.painLevel.ToString(),
                    Color = SKColor.Parse("#266489")
                });

            }

            Chart = new LineChart() { Entries = entryList.ToArray() };
        }
    }
}
