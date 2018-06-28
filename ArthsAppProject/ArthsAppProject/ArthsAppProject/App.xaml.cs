using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArthsAppProject.Views;
using ArthsAppProject.ViewModels;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArthsAppProject
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        static ArthsDatabase database;
        
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        public static ArthsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ArthsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ArthsSQLite.db"));
                }
                return database;
            }
        }
        
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("Hello");
        }

		public async void OnHomeButtonPressed(object sender, EventArgs e)
        {
            await NavigationService.NavigateAsync("Menu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Hello, HelloViewModel>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewUser, NewUserViewModel>();
            containerRegistry.RegisterForNavigation<Home, HomeViewModel>();
            containerRegistry.RegisterForNavigation<Exercises, ExercisesViewModel>();
            containerRegistry.RegisterForNavigation<MyPain, MyPainViewModel>();
            containerRegistry.RegisterForNavigation<MyAppointments, MyAppointmentsViewModel>();
            containerRegistry.RegisterForNavigation<Report, ReportViewModel>();
            containerRegistry.RegisterForNavigation<Questions, QuestionsViewModel>();
            containerRegistry.RegisterForNavigation<PainEvolution, PainEvolutionViewModel>();
            containerRegistry.RegisterForNavigation<PainEvaluation, PainEvaluationViewModel>();
            containerRegistry.RegisterForNavigation<SimpleExForm, SimpleExFormViewModel>();
            containerRegistry.RegisterForNavigation<PainExForm, PainExFormViewModel>();
            containerRegistry.RegisterForNavigation<ConsultEx, ConsultExViewModel>();
            containerRegistry.RegisterForNavigation<AddAppointment, AddAppointmentViewModel>();
            containerRegistry.RegisterForNavigation<DoctorList, DoctorListViewModel>();
            containerRegistry.RegisterForNavigation<UpdateAppointment, UpdateAppointmentViewModel>();
            containerRegistry.RegisterForNavigation<AddDoctor, AddDoctorViewModel>();
            containerRegistry.RegisterForNavigation<UpdateDoctor, UpdateDoctorViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmADD, ConfirmADDViewModel>();
            containerRegistry.RegisterForNavigation<Views.Menu, MenuViewModel>();
            containerRegistry.RegisterForNavigation<ADDExercice, ADDExerciceViewModel>();
            containerRegistry.RegisterForNavigation<ListExercices, ListExercicesViewModel>();
            containerRegistry.RegisterForNavigation<MyAccount, MyAccountViewModel>();
            containerRegistry.RegisterForNavigation<UpdateAccount, UpdateAccountViewModel>();
            containerRegistry.RegisterForNavigation<ListAppointment, ListAppointmentViewModel>();
            containerRegistry.RegisterForNavigation<Faq, FaqViewModel>();
            containerRegistry.RegisterForNavigation<Contact, ContactViewModel>();
            containerRegistry.RegisterForNavigation<ExercicePropr, ExerciceProprViewModel>();
            containerRegistry.RegisterForNavigation<UpdateDoctorApp, UpdateDoctorAppViewModel>();



        }
    }
}
