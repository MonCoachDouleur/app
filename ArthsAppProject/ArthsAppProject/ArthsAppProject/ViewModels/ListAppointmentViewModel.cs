using ArthsAppProject.Behaviors;
using ArthsAppProject.Helper;
using ArthsAppProject.Infrastructure;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ArthsAppProject.ViewModels
{
    class ListAppointmentViewModel : ObservedBase
    {
        public Doctor Doctor { get; set; }
        public ListAppointmentViewModel(INavigationService navigationService) : base(navigationService)
        {
            int idUser = Convert.ToInt32(App.Current.Properties[PropertiesHelper.Id_User_Key]);
            loadData(idUser);
            GetAppointment();
        }
        private ObservableCollection<Appointment> _appointment;

        public ObservableCollection<Appointment> Appointments
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                RaisePropertyChanged<ObservableCollection<Appointment>>(() => Appointments);
            }
        }
        public async void GetAppointment()
        {
            Appointments = new ObservableCollection<Appointment>(await App.Database.appointmentRepo.GetAll());
        }

        private async void loadData(int idUser)
        {
            Doctor = await App.Database.doctorRepo.Get(idUser);
        }

    }


}