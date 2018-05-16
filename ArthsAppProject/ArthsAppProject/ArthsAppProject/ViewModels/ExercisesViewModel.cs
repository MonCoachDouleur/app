using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class ExercisesViewModel : AppMapViewModelBase
    {


        public ExercisesViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
