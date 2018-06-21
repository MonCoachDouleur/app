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
using ArthsAppProject.Helper;

namespace ArthsAppProject.ViewModels
{
    class MyAccountViewModel : AppMapViewModelBase
    {
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public User User { get; set; }
        public Doctor Doctor { get; set; }

        public MyAccountViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            loadData(idUser);
        }
        
        private async void loadData(int idUser)
        {
            User = await App.Database.userRepo.Get(idUser);
            Doctor = await App.Database.doctorRepo.Get(User.Id_u);
        }  
    }
}
