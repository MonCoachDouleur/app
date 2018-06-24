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
using System.Threading.Tasks;

namespace ArthsAppProject.ViewModels
{
    class MyAccountViewModel : AppMapViewModelBase
    {
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public NotifyTaskCompletion<User> UserTask { get; private set; }
        public NotifyTaskCompletion<Doctor> DoctorTask { get; private set; }

        public MyAccountViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            UserTask = new NotifyTaskCompletion<User>(App.Database.userRepo.Get(idUser));
            DoctorTask = new NotifyTaskCompletion<Doctor>(App.Database.doctorRepo.Get(idUser));
        }

    }
}
