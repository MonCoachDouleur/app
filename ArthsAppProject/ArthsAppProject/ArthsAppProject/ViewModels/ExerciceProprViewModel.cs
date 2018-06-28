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
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Services;
using ArthsAppProject.Helper;
using ArthsAppProject.Models;

namespace ArthsAppProject.ViewModels
{
    class ExerciceProprViewModel : ObservedBase
    {
        public ICommand SubmitCommand => new Command(() => OnSubmitAsync());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private string durationExo;

        public ExerciceProprViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
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
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            User user = await App.Database.userRepo.Get(idUser);
            String Query = "Select * from ExercisePrepro where ZonePain = '" + user.PainArea.ToString() + "'";
            Exercises = new ObservableCollection<ExercisePrepro>(await App.Database.exercisePreproRepo.GetWithQuery(Query));
        }

        public string DurationExo
        {
            get { return durationExo; }
            set
            {
                durationExo = value;
                RaisePropertyChanged(() => DurationExo);
            }
        }

        private async void OnSubmitAsync()
        {
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            User user = await App.Database.userRepo.Get(idUser);
            DateTime DayExo = DateTime.Now;
            Exercise exercise = new Exercise("Proprioception", DayExo, durationExo, user.Id_u);
            App.Database.exerciseRepo.Insert(exercise);
            await _navigationService.NavigateAsync("Exercises");

        }

    }
}

