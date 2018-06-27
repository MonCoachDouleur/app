using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Services;
using System.Collections.Generic;
using System.Linq;
using ArthsAppProject.ViewModels.Base;
using ArthsAppProject.ValidationRule;
using Xamarin.Forms;
using ArthsAppProject.Models;
using ArthsAppProject.Helper;

namespace ArthsAppProject.ViewModels
{
    public class ADDExerciceViewModel : AppMapViewModelBase, INotifyPropertyChanged
    {

        public ICommand SubmitCommand => new Command(() => OnSubmitAsync());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        private TypeExosEnum typeExoSelected;
        private string durationExo;

        public ADDExerciceViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public TypeExosEnum TypeExoSelected
        {
            get { return typeExoSelected; }
            set
            {
                typeExoSelected = value;
                RaisePropertyChanged(() => TypeExoSelected);
            }
        }

        public List<string> TypeExosNames
        {
            get
            {
                return Enum.GetNames(typeof(TypeExosEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
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

        private DateTime dayExo;
        public DateTime DayExo
        {
            get { return dayExo; }
            set
            {
                dayExo = value;
                RaisePropertyChanged(() => DayExo);
            }
        }

        private async void OnSubmitAsync()
        {
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            User user = await App.Database.userRepo.Get(idUser);
            DayExo = DateTime.Now;
            Exercise exercise = new Exercise(typeExoSelected.ToString(), DayExo,  durationExo, user.Id_u);
            App.Database.exerciseRepo.Insert(exercise);   
            await _navigationService.NavigateAsync("Exercises");
                
        }
    }
}
