using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    public class PainEvolutionViewModel : AppMapViewModelBase
    {


        public PainEvolutionViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
