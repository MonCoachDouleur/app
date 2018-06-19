using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.ComponentModel;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArthsAppProject.ViewModels
{
    class MyAccountViewModel : AppMapViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public User User { get; set; }
        public Doctor Doctor { get; set; }

        public MyAccountViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            var login = App.Current.Properties["login"] as string;
            User = App.Database.GetUserByLogin(login);
            Doctor = App.Database.GetDoctorByUserId(User.Id_u);
        }    

    }
}
