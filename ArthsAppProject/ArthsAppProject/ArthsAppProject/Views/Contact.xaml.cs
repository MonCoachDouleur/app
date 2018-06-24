using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArthsAppProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        public Contact()
        {
            InitializeComponent();
            MainOne.DataSource = GetSampleData();
            MainOne.DataBind();
        }

        public List<AccordionSource> GetSampleData()
        {
            var vResult = new List<AccordionSource>();
           
            #region StackLayout
            var vListViewOne = new StackLayout()
            {
                Children = {
                    new Label { Text = "Nous sommes 3 étudiantes de l'université d'Evry" },
                    new Label { Text = "Aya Maoui" },
                    new Label { Text = "Houda Lkhyari" },
                    new Label { Text = "Victoria Pereira" }
                }
            };
            #endregion

            #region StackLayout
            var vListViewtwo = new StackLayout()
            {
                Children = {
                    new Label { Text = "Contact par mail:" },
                    new Label { Text = "les_meilleures@arthsapp.com" },
                    new Label { Text = "Contact par tel:" },
                    new Label { Text = "Je n'ai pas de 06 " }
                }
            };
            #endregion

            #region StackLayout
            var vListViewThree = new StackLayout()
            {
                Children = {
                    new Label { Text = "Article1" },
                    new Label { Text = "Soignez vous bien" },
                    new Label { Text = "Article 2" },
                     new Label { Text = "Faites du sport" }
                }
            };
            #endregion

            var vFirstAccord = new AccordionSource()
            {
                HeaderText = "Qui sommes nous ?",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.FromHex("#5EA6C2"),
                ContentItems = vListViewOne
            };
            vResult.Add(vFirstAccord);
            var vSecond = new AccordionSource()
            {
                HeaderText = "Nous contacter",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.FromHex("#5EA6C2"),
                ContentItems = vListViewtwo
            };
            vResult.Add(vSecond);
            var vThird = new AccordionSource()
            {
                HeaderText = "Mentions légales",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.Purple,
                ContentItems = vListViewThree
            };
            vResult.Add(vThird);
            return vResult;
        }

        private void OnListItemClicked(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
