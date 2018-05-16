using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class ReportViewModel : AppMapViewModelBase
    {


        public ReportViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
