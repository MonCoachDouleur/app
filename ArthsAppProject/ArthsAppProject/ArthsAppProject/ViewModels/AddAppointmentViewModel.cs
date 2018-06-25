using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ArthsAppProject.Infrastructure;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Services;
using ArthsAppProject.Helper;

namespace ArthsAppProject.ViewModels
{
    public class AddAppointmentViewModel : AppMapViewModelBase
    {
        public ICommand SubmitCommand => new Command(async () => await OnSubmitAsync());

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        public Doctor doctor { get; set; }
        public string PageName { get; set; }

        public NotifyTaskCompletion<Doctor> DoctorTask { get; private set; }


        int idUser;
        public AddAppointmentViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            DoctorTask = new NotifyTaskCompletion<Doctor>(App.Database.doctorRepo.Get(idUser));

            if (DoctorTask.Task.Id <= 1)
            {
                PageName = "AddDoctor";
            }

        }

        private DateTime _rdvDate;
        public DateTime RDVDate
        {
            get
            {
                return _rdvDate;
            }
            set
            {
                _rdvDate = value;
                RaisePropertyChanged(() => RDVDate);
            }
        }

        private DateTime _rdvHour;
        public DateTime RDVHour
        {
            get
            {
                return _rdvHour;
            }
            set
            {
                _rdvHour = value;
                RaisePropertyChanged(() => RDVHour);
            }
        }
        private async System.Threading.Tasks.Task OnSubmitAsync()
        {
            Appointment appointment = new Appointment(this._rdvDate, this._rdvHour, this.idUser);
            App.Database.appointmentRepo.Insert(appointment);
            await _dialogService.DisplayAlertAsync("Ajouter un Rendez-vous", "Votre rendez-vous a été bien enregistré.", "Ok");
            await _navigationService.NavigateAsync("ListAppointment");
        }
    }
}
