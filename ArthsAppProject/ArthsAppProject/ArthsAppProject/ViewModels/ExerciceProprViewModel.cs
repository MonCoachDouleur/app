using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using ArthsAppProject.Behaviors;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ArthsAppProject.ViewModels
{
    class ExerciceProprViewModel : ObservedBase
    {

        public ExerciceProprViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetExercices();
        }
        private ObservableCollection<ExercisePrepro> _exercise;

        public ObservableCollection<ExercisePrepro> Exercises
        {
            get { return _exercise; }
            set
            {
                _exercise = value;
                RaisePropertyChanged<ObservableCollection<ExercisePrepro>>(() => Exercises);
            }
        }
        public async void GetExercices()
        {
            Exercises = new ObservableCollection<ExercisePrepro>(await App.Database.exercisePreproRepo.Get(null, (mycustomer => mycustomer.Type)));
        }

    }
}

