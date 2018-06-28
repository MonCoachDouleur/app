using ArthsAppProject.Behaviors;
using ArthsAppProject.Helper;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ArthsAppProject.ViewModels
{


    class ListExercicesViewModel : ObservedBase
    {

        public ListExercicesViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetExercices();
        }
        private ObservableCollection<Exercise> _exercise;

        public ObservableCollection<Exercise> Exercises
        {
            get { return _exercise; }
            set
            {
                _exercise = value;
                RaisePropertyChanged<ObservableCollection<Exercise>>(() => Exercises);
            }
        }
        public async void GetExercices()
        {
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            String Query = "Select * from Exercise where Id_user =" + idUser;
            Exercises = new ObservableCollection<Exercise>(await App.Database.exerciseRepo.GetWithQuery(Query));
        }

        }

   
}
