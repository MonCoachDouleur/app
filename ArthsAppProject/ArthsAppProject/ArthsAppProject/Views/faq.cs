using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ArthsAppProject.Views
{
    public class faq : ContentPage
    {
        public faq()
        {
            Title = "FAQ";
            var vAccordionSource = GetSampleData();
            var vAccordionControl = new Accordion(vAccordionSource);
            Content = vAccordionControl;
        }

        public List<AccordionSource> GetSampleData()
        {
            var vResult = new List<AccordionSource>();

    
            #region StackLayout
            var vViewLayout1 = new StackLayout()
            {
                Children = {
                 new Label { Text = "Le cartilage n'est pas innervé. Ce n'est donc pas lui qui fait mal. La douleur vient des tissus voisins qui eux sont innervés et qui sont également touchés par les lésions arthrosiques : la membrane synoviale, l'os sous-chondral, les ligaments et les tendons." },
                    new Label { Text = "L'information douloureuse démarre des terminaisons nerveuses présentes dans ces tissus." },
                    new Label
                    { Text = "Une fois le cartilage abimé, il peut se produire une « néo-neurogenèse ». C'est l'apparition, du fait de la maladie arthrosique, de terminaisons nerveuses au sein même du cartilage qui en est initialement dépourvu." }
                }
            };
            #endregion
            #region StackLayout
            var vViewLayout2 = new StackLayout()
            {
                Children = {
                    new Label { Text = "La douleur d’une articulation arthrosique est évaluée au mieux par une échelle visuelle analogique." },
                    new Label { Text = "L’échelle visuelle analogique est une règle dont un côté (celui du patient) est un ruban continu dont l’une des extrémités correspond à « pas de douleur » et dont l’extrémité opposée correspond à douleur maximale imaginable. Le côté de la règle visible par le médecin est gradué de 0 à 10" },
                    new Label
                    { Text = "De son côté, le médecin note la graduation correspondante (entre 0 et 10)" }
                }
            };
            #endregion
            #region StackLayout
            var vViewLayout3 = new StackLayout()
            {
                Children = {
                    new Label { Text = "Pour évaluer le risque d’arthrose lié à l’activité sportive, il convient de prendre en compte le type de sport et le niveau de pratique." },
                    new Label { Text = "Les sports collectifs comme le football ou le rugby sont de gros pourvoyeurs de traumatismes. Ces traumatismes (entorses, fractures articulaires) peuvent laisser des séquelles (instabilité, lésions cartilagineuses) qui, à la longue, favorisent le développement d’une arthrose." },
                    new Label
                    { Text = "Le sportif qui pratique un sport collectif en compétition (surtout en tant que professionnel) est plus exposé que le pratiquant d’un sport loisir car son activité sportive est plus intense, plus fréquente, plus prolongée." }
                }
            };
            #endregion
            #region StackLayout
            var vViewLayout4 = new StackLayout()
            {
                Children = {
                    new Label { Text = "Les applications locales d’anti-inflammatoires sont réservées aux articulations superficielles (doigts, genoux), ont une efficacité moindre et sont généralement bien tolérées." },
                    new Label { Text = "Les anti-inflammatoires appliqués localement sur la peau existent sous 2 formes : les gels et les pommades." },
                    new Label
                    { Text = "Leur efficacité est moindre que celle des anti-inflammatoires par voie orale, mais leur tolérance générale est bien meilleure. Sur le plan local, la tolérance n’est pas toujours parfaite et il convient de suspendre toute application en cas de réaction cutanée." }
                }
            };
            #endregion
            #region StackLayout
            var vViewLayout5 = new StackLayout()
            {
                Children = {
                    new Label { Text = "L’obésité est un facteur de risque d’arthrose au niveau des articulations qui supportent le poids du corps (genou, hanche). La surcharge mécanique n’est pas la seule en cause car l’obésité est aussi un facteur de risque de l’arthrose localisée aux doigts." },
                    new Label { Text = "La responsabilité de l’obésité dans la survenue et dans l’aggravation d’une arthrose est démontrée pour le genou." },
                    new Label
                    { Text = "L’obésité ne se limite pas à favoriser ou accélérer l’évolution d’une arthrose des articulations portantes. Par les troubles métaboliques qu’elle entraine, elle est un facteur de risque de toutes les localisations de l’arthrose (notamment l’arthrose des doigts)." }
                }
            };
            #endregion


            var vFirstAccord = new AccordionSource()
            {
                HeaderText = "Pourquoi l'arthrose fait-elle mal ?",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.FromHex("#5EA6C2"),
                ContentItems = vViewLayout1
            };
            vResult.Add(vFirstAccord);

            var vSecond = new AccordionSource()
            {
                HeaderText = "Comment évaluer la douleur de l’arthrose ? ",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.FromHex("#5EA6C2"),
                ContentItems = vViewLayout2
            };
            vResult.Add(vSecond);
            var vThird = new AccordionSource()
            {
                HeaderText = "La pratique du sport est-elle un facteur de risque d’arthrose ?",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.FromHex("#5EA6C2"),
                ContentItems = vViewLayout3
            };
            vResult.Add(vThird);

            var vFourth = new AccordionSource()
            {
                HeaderText = "Les applications locales d’anti-inflammatoires sont-elles efficaces ?",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.Purple,
                ContentItems = vViewLayout4
            };
            vResult.Add(vFourth);

            var vFifth = new AccordionSource()
            {
                HeaderText = "L’obésité est-elle un facteur de risque d’arthrose ?",
                HeaderTextColor = Color.White,
                HeaderBackGroundColor = Color.Purple,
                ContentItems = vViewLayout5
            };
            vResult.Add(vFifth);

            return vResult;
        }

        private void OnListItemClicked(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class ListDataViewCell : ViewCell
    {
        public ListDataViewCell()
        {
            var label = new Label()
            {
                Font = Font.SystemFontOfSize(NamedSize.Default),
                TextColor = Color.Blue
            };
            label.SetBinding(Label.TextProperty, new Binding("TextValue"));
            label.SetBinding(Label.ClassIdProperty, new Binding("DataValue"));
            View = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(12, 8),
                Children = { label }
            };
        }
    }


    public class SimpleObject
    {
        public string TextValue { get; set; }
        public string DataValue { get; set; }
    }
}