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

namespace ArthsAppProject.ViewModels
{
    public class ADDExerciceViewModel : AppMapViewModelBase, INotifyPropertyChanged
    {

        public ICommand SubmitCommand => new Command(() => OnSubmit());

        public event PropertyChangedEventHandler PropertyChanged;
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
                PropertyChanged(this, new PropertyChangedEventArgs("TypeExoSelected"));
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
                PropertyChanged(this, new PropertyChangedEventArgs("DurationExo"));
            }
        }

        private void OnSubmit()
        {


                Exercise exercise = new Exercise(typeExoSelected, durationExo);
                    App.Database.SaveUserAsync(exercise);
                    _navigationService.NavigateAsync("ConfirmADD");
                
        }
    }
}
