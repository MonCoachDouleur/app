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
    public class UpdateDoctorViewModel : AppMapViewModelBase
    {
        public ICommand SubmitCommand => new Command(() => OnSubmit());

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidateLastnameCommand => new Command(() => ValidateLastname());

        public ICommand ValidateHospitalCommand => new Command(() => ValidateHospital());

        public ICommand ValidateSpecialityCommand => new Command(() => ValidateSpeciality());

        public ICommand ValidatePhoneNumberCommand => new Command(() => ValidatePhoneNumber());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public Doctor doctor { get; set; }
        private bool _isValid;
        int idUser;
        private bool isUpdate;
        public NotifyTaskCompletion<Doctor> DoctorTask { get; private set; }
        public UpdateDoctorViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _username = new ValidatableObject<string>();
            _lastname = new ValidatableObject<string>();
            _hospital = new ValidatableObject<string>();
            _speciality = new ValidatableObject<string>();
            _phoneNumber = new ValidatableObject<string>();
            idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
           
            loadData(idUser);
            AddValidations();
        }

        private async void loadData(int idUser)
        {
            doctor = await App.Database.doctorRepo.Get(idUser);
            if (doctor != null)
            {
                _username.Value = doctor.DocEmail;
                _lastname.Value = doctor.Name_doc;
                _hospital.Value = doctor.DocAdress;
                _speciality.Value = doctor.DocSpeciality;
                _phoneNumber.Value = doctor.DocPhone;
                isUpdate = true;
            }
            else
            {
                isUpdate = false;
            }
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
                if (isUpdate)
                {
                    doctor.DocEmail = _username.Value;
                    doctor.Name_doc = _lastname.Value;
                    doctor.DocAdress = _hospital.Value;
                    doctor.DocSpeciality = _speciality.Value;
                    doctor.DocPhone = _phoneNumber.Value;
                    App.Database.doctorRepo.UpdateWithChild(doctor);
                }
                else
                {
                    doctor = new Doctor(_lastname.Value, _hospital.Value, _speciality.Value, _username.Value, _phoneNumber.Value, 1);
                    App.Database.doctorRepo.Insert(doctor);

                }
                _dialogService.DisplayAlertAsync("Médecin traitant", "Vos onformations ont bien été enregistrées", "Ok");
                _navigationService.NavigateAsync("MyAccount");
            }
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName(); ;
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

            _phoneNumber.Validations.Add(new PhoneNumberRule<string>
            {
                ValidationMessage = "Veuillez saisir un numéro de téléphone."
            });

        }
    }
}
