using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.ComponentModel;

namespace ArthsAppProject.ViewModels
{
   

    class MenuViewModel : AppMapViewModelBase, INotifyPropertyChanged
    {
        ICommand tapCommand;
        private INavigationService _navigationService;
        public MenuViewModel(INavigationService navigationService) : base (navigationService)
        {
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
            _navigationService = navigationService;
        }
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        void OnTapped(object s)
        {
            _navigationService.NavigateAsync("Login");
        }
    }
}
