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
    public class AddDoctorViewModel : AppMapViewModelBase
    {

        public ICommand SubmitCommand => new Command(() => OnSubmit());

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidateLastnameCommand => new Command(() => ValidateLastname());
        
        public ICommand ValidateHospitalCommand => new Command(() => ValidateHospital());

        public ICommand ValidateSpecialityCommand => new Command(() => ValidateSpeciality());

        public ICommand ValidatePhoneNumberCommand => new Command(() => ValidatePhoneNumber());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private bool _isValid;

        public AddDoctorViewModel(INavigationService navigationService, IPageDialogService dialogService) : base (navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _username = new ValidatableObject<string>();
            _lastname = new ValidatableObject<string>();
            _hospital = new ValidatableObject<string>();
            _speciality = new ValidatableObject<string>();
            _phoneNumber = new ValidatableObject<string>();

            AddValidations();
        }

        private ValidatableObject<string> _phoneNumber;
        public ValidatableObject<string> PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged(() => PhoneNumber);
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

        private ValidatableObject<string> _speciality;
        public ValidatableObject<string> Speciality
        {
            get
            {
                return _speciality;
            }
            set
            {
                _speciality = value;
                RaisePropertyChanged(() => Speciality);
            }
        }
        private ValidatableObject<string> _hospital;
        public ValidatableObject<string> Hospital
        {
            get
            {
                return _hospital;
            }
            set
            {
                _hospital = value;
                RaisePropertyChanged(() => Hospital);
            }
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

        private void OnSubmit()
        {
            IsValid = true;
            bool isValid = Validate();
            if (isValid)
            {
                var login = App.Current.Properties["login"] as string;
                User user = App.Database.GetUserByLogin(login);
                Doctor doctor = new Doctor(this._lastname.Value, this._hospital.Value, this._speciality.Value, this._username.Value, this._phoneNumber.Value, user.Id_u);
                App.Database.SaveAsync(doctor);
                _dialogService.DisplayAlertAsync("Ajouter un Médecin", "Le médecin a été bien ajouté.", "Ok");
                _navigationService.NavigateAsync("ConfirmADD");
            }
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();;
            bool isValidLastname = ValidateLastname();
            bool isValidHospital = ValidateHospital();
            bool isValidSpeciality = ValidateSpeciality(); 
            bool isValidPhoneNumber = ValidatePhoneNumber();
            return isValidUser && isValidLastname && isValidHospital && isValidSpeciality && isValidPhoneNumber;
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

        private bool ValidateUserName()
        {
            return _username.Validate();
        }

        private bool ValidatePhoneNumber()
        {
            return _phoneNumber.Validate();
        }
        
        private bool ValidateSpeciality()
        {
            return _speciality.Validate();
        }

        private bool ValidateHospital()
        {
            return _hospital.Validate();
        }
        private bool ValidateLastname()
        {
            return _lastname.Validate();
        }

        private void AddValidations()
        {
            _username.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "Votre identifiant doit être une adresse email."
            });

            _lastname.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir votre nom."
            });

            _hospital.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir la clinique."
            });

            _speciality.Validations.Add(new NameRule<string>
            {
               ValidationMessage = "Veuillez saisir votre spécialité."
            });

            _phoneNumber.Validations.Add(new NameRule<string>
            {
                ValidationMessage = "Veuillez saisir un numéro de téléphone."
            });
            
        }
    }
}
