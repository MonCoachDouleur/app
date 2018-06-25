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
        public ICommand SubmitCommand => new Command(() => OnSubmit());
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand ValidateLastnameCommand => new Command(() => ValidateLastname());
        public ICommand ValidateFirstnameCommand => new Command(() => ValidateFirstname());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private bool _isValid;

        public NewUserViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _username = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _lastname = new ValidatableObject<string>();
            _firstname = new ValidatableObject<string>();

            AddValidations();
        }

        private ValidatableObject<string> _username;
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
        private ValidatableObject<string> _firstname;
        public ValidatableObject<string> Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                RaisePropertyChanged(() => Firstname);
            }
        }
        private ValidatableObject<string> _lastname;
        public ValidatableObject<string> Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                RaisePropertyChanged(() => Lastname);
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                RaisePropertyChanged(() => BirthDate);
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
                RaisePropertyChanged(() => SelectedPainArea);

            }
        }

        public List<string> PainAreaNames
        {
            get
            {
                return Enum.GetNames(typeof(PainAreaEnum)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        private void AddValidations()
        {
            _username.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "Votre identifiant doit être une adresse email."
            });

            _password.Validations.Add(new AtLeast6CharacterRule<string>
            {
                ValidationMessage = "Votre mot de passe doit faire au moins 6 caractères."
            });

            _firstname.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir votre prénom."
            });

            _lastname.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir votre nom."
            });
        }

        private async void OnSubmit()
        {
            IsValid = true;
            bool isValid = Validate();

            if (isValid)
            {
                User user = await App.Database.userRepo.Get(predicate: x => x.Login_u.Equals(_username.Value));
                if(user == null)
                {
                    user = new User(_username.Value, _password.Value, _lastname.Value, _firstname.Value, _birthDate, selectedPainArea);
                    App.Database.userRepo.Insert(user);
                    await _navigationService.NavigateAsync("ConfirmADD");
                }
                else
                {
                    await _dialogService.DisplayAlertAsync("Erreur", "Cet email est déjà associé à un compte.", "Ok");
                }
            }
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            bool isValidFirstname = ValidateFirstname();
            bool isValidLastname = ValidateLastname();
            return isValidUser && isValidPassword && isValidFirstname && isValidLastname;
        }

        private bool ValidateUserName()
        {
            return _username.Validate();
        }
        private bool ValidatePassword()
        {
            return _password.Validate();
        }
        private bool ValidateFirstname()
        {
            return _firstname.Validate();
        }
        private bool ValidateLastname()
        {
            return _lastname.Validate();
        }


    }
}
