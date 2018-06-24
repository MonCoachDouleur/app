using ArthsAppProject.Behaviors;
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
            Exercises = new ObservableCollection<Exercise>(await App.Database.exerciseRepo.GetAll());         
        }



    }

   
}
