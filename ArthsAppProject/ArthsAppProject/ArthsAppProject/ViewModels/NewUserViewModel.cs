using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Services;
using System.Collections.Generic;
using System.Linq;
using ArthsAppProject.ViewModels.Base;
using ArthsAppProject.ValidationRule;
using Xamarin.Forms;

namespace ArthsAppProject.ViewModels
{
    public class NewUserViewModel : AppMapViewModelBase
    {
        public Action DisplayInvalidLoginPrompt;
        public ICommand SubmitCommand { get; set; }
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private ValidatableObject<string> _username;
        private bool _isValid;
        public ValidatableObject<string> Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;

                RaisePropertyChanged(() => Username);
            }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }
        private void AddValidations()
        {
            _username.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "The username must be an email."
            });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A password is required."
            });
        }

        private PainAreaEnum selectedPainArea;

        public PainAreaEnum SelectedPainArea
        {
            get
            {
                return selectedPainArea;
            }
            set
            {
                selectedPainArea = value;   
            }
        }

        public List<string> PainAreaNames
        {
            get
            {
                return Enum.GetNames(typeof(PainAreaEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public NewUserViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            SubmitCommand = new DelegateCommand(OnSubmit);
            _username = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        private void OnSubmit()
        {
            IsValid = true;
            bool isValid = Validate();

            if (isValid)
            {
                User user = new User(_username.Value, _password.Value, selectedPainArea);
                App.Database.SaveUserAsync(user);
                _navigationService.NavigateAsync("Login");
            }


        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _username.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }


    }
}
