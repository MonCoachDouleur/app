using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Services;

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

        public NewUserViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            SubmitCommand = new DelegateCommand(OnSubmit);
        }

        private void OnSubmit()
        {
            User user = new User(username, password);
            App.Database.SaveUserAsync(user);
            _navigationService.NavigateAsync("Login");

        }
    }
}
