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
using ArthsAppProject.Helper;

namespace ArthsAppProject.ViewModels
{
    class UpdateAccountViewModel : AppMapViewModelBase
    {
        public ICommand SubmitCommand => new Command(() => OnSubmit());

        public object CommandParameter { get; set; }
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidateLastnameCommand => new Command(() => ValidateLastname());
        public ICommand ValidateFirstnameCommand => new Command(() => ValidateFirstname());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public User User { get; set; }
        private bool _isValid;

        public NotifyTaskCompletion<User> UserTask { get; private set; }


        public UpdateAccountViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _username = new ValidatableObject<string>();
            _lastname = new ValidatableObject<string>();
            _firstname = new ValidatableObject<string>();
            
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            loadData(idUser);
            AddValidations();
        }

        private async void loadData(int idUser)
        {
            User = await App.Database.userRepo.Get(idUser);
            _username.Value = User.Login_u;
            _lastname.Value = User.Lastname_u;
            _firstname.Value = User.Firstname_u;
            _birthDate = User.BirthDate_u;
            selectedPainArea = User.PainArea;
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

            _firstname.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir votre prénom."
            });

            _lastname.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir votre nom."
            });
        }

        private void OnSubmit()
        {
            IsValid = true;
            bool isValid = Validate();
            if (isValid)
            {
                User.Login_u = _username.Value;
                User.Firstname_u = _firstname.Value;
                User.PainArea = selectedPainArea;
                User.Lastname_u = _lastname.Value;
                User.BirthDate_u = _birthDate;
                App.Database.userRepo.UpdateWithChild(User);
                _dialogService.DisplayAlertAsync("Mon Compte", "Vos informations ont bien été enregistrées", "Ok");
                _navigationService.NavigateAsync("MyAccount");
            }
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidFirstname = ValidateFirstname();
            bool isValidLastname = ValidateLastname();
            return isValidUser && isValidFirstname && isValidLastname;
        }

        private bool ValidateUserName()
        {
            return _username.Validate();
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
