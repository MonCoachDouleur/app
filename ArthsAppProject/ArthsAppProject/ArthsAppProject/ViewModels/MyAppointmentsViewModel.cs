using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class MyAppointmentsViewModel : AppMapViewModelBase
    {


        public MyAppointmentsViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
