using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class HelloViewModel : AppMapViewModelBase
    {


        public HelloViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
