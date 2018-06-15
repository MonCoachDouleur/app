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
    public class PainEvaluationViewModel : AppMapViewModelBase
    {
        public ICommand SubmitCommand => new Command(() => OnSubmit());

        public event PropertyChangedEventHandler PropertyChanged;
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        private TypePainEnum levelPainSelected;

        public PainEvaluationViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public TypePainEnum LevelPainSelected
        {
            get { return levelPainSelected; }
            set
            {
                levelPainSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LevelPainSelected"));
            }
        }

        public List<string> LevelPainName
        {
            get
            {
                return Enum.GetNames(typeof(TypePainEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        private DateTime datePain;
        public DateTime DatePain
        {
            get
            {
                return datePain;
            }
            set
            {
                datePain = value;
                RaisePropertyChanged(() => DatePain);
            }
        }
        private string textCirconstance;
        public string TextCirconstance
        {
            get
            {
                return textCirconstance;
            }
            set
            {
                textCirconstance = value;
                RaisePropertyChanged(() => TextCirconstance);
            }
        }

        private void OnSubmit()
        {
               _navigationService.NavigateAsync("PainEvolution");

        }
    }
}
