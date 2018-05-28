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

namespace ArthsAppProject.ViewModels
{
    public class NewUserViewModel : AppMapViewModelBase, INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public ICommand SubmitCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public DateTime birthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BirthDate"));
            }
        }
        private string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private PainAreaEnum selectedPainArea;

        public PainAreaEnum SelectedPainArea
        {
            get
            {
                return selectedPainArea;
            }
            set
            {
                selectedPainArea = value;   
            }
        }

        public List<string> PainAreaNames
        {
            get
            {
                return Enum.GetNames(typeof(PainAreaEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public NewUserViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            SubmitCommand = new DelegateCommand(OnSubmit);
        }

        private void OnSubmit()
        {
            User user = new User(username, password, birthDate, selectedPainArea);
            Console.WriteLine(selectedPainArea);
            App.Database.SaveUserAsync(user);
            _navigationService.NavigateAsync("ConfirmADD");

        }
    }
}
