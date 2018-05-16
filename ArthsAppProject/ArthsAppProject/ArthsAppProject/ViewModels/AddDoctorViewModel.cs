using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class AddDoctorViewModel : AppMapViewModelBase
    {


        public AddDoctorViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
