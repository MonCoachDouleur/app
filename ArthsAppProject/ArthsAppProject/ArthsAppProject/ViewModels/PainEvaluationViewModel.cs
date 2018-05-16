using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class PainEvaluationViewModel : AppMapViewModelBase
    {


        public PainEvaluationViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
