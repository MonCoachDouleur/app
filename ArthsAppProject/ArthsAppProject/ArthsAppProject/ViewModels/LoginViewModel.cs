using System;
using System.Windows.Input;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using Prism.Services;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ArthsAppProject.ViewModels
{
    public class LoginViewModel : AppMapViewModelBase, INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public ICommand SubmitCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private string username;
        public string Username {
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

        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            SubmitCommand = new DelegateCommand(OnSubmit);
        }

        private void OnSubmit()
        {
            User user = App.Database.GetUserByLogin(username);

            if (user == null)
            {
                _dialogService.DisplayAlertAsync("Error", "Invalid Login or password, try again", "OK");
            }
            else
            {
                if (user.Pass_u.Equals(Hash.HashSHA512(password)))
                {
                    _navigationService.NavigateAsync("/MasterDetail/NavigationPage/Menu");
                }
                else
                {
                    _dialogService.DisplayAlertAsync("Error", "Invalid Login or password, try again", "OK");
                }
                 
            }
            
        }
    }
}
