using System;
using System.Windows.Input;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using Prism.Services;
using System.Threading.Tasks;

namespace ArthsAppProject.ViewModels
{
    public class LoginViewModel : AppMapViewModelBase
    {

        public ICommand LoginCommand { get; set; }
        private IPageDialogService _dialogService;

        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            LoginCommand = new DelegateCommand(LoginAsync);
        }

        private User GetUserByLogin()
        {
            return App.Database.GetUserByLogin("test").Result;
        }
        private void LoginAsync()
        {
            User user = GetUserByLogin();
            
            _dialogService.DisplayActionSheetAsync(user.Login, "Alert msg", "OK");
        }
    }
}
