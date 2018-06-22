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
    public class PainEvaluationViewModel : AppMapViewModelBase
    {
        public ICommand SubmitCommand => new Command(() => OnSubmit());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        private TypePainEnum levelPainSelected;
        private int painValueSelected;

        public int PainValue
        {
            get { return painValueSelected; }
            set
            {
                painValueSelected = value;
                RaisePropertyChanged(() => PainValue);
            }
        }

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
                RaisePropertyChanged(() => LevelPainSelected);
            }
        }

        public List<string> LevelPainName
        {
            get
            {
                return Enum.GetNames(typeof(TypePainEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        private DateTime datePain = DateTime.Today;
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

        private async void OnSubmit()
        {
            Pain pain = new Pain(datePain, painValueSelected);

            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            User user = await App.Database.userRepo.GetWithChild(idUser);

            App.Database.painRepo.Insert(pain);
            user.painList.Add(pain);

            App.Database.userRepo.UpdateWithChild(user);
            await _navigationService.NavigateAsync("PainEvolution");
        }
    }
}
