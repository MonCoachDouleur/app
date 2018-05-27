using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using ArthsAppProject.Infrastructure;

namespace ArthsAppProject.ViewModels
{
    class ConfirmADDViewModel : AppMapViewModelBase
    {

        public ConfirmADDViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
