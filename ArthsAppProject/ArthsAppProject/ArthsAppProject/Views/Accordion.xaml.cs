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
	public partial class Accordion : ContentView
    {
        List<AccordionSource> mDataSource;
        bool mFirstExpaned = false;
        StackLayout mMainLayout;


        public Accordion()
        {
            var mMainLayout = new StackLayout();
            Content = mMainLayout;
        }
        public Accordion(List<AccordionSource> aSource)
        {
            mDataSource = aSource;
            DataBind();
        }
        #region Properties
        public List<AccordionSource> DataSource
        {
            get { return mDataSource; }
            set { mDataSource = value; }
        }
        public bool FirstExpaned
        {
            get { return mFirstExpaned; }
            set { mFirstExpaned = value; }
        }
        #endregion

        public void DataBind()
        {
            var vMainLayout = new StackLayout();
            var vFirst = true;
            if (mDataSource != null)
            {
                foreach (var vSingleItem in mDataSource)
                {

                    var vHeaderButton = new AccordionButton()
                    {
                        Text = vSingleItem.HeaderText,
                        TextColor = vSingleItem.HeaderTextColor,
                        BackgroundColor = vSingleItem.HeaderBackGroundColor
                    };

                    var vAccordionContent = new ContentView()
                    {
                        Content = vSingleItem.ContentItems,
                        IsVisible = false
                    };
                    if (vFirst)
                    {
                        vHeaderButton.Expand = mFirstExpaned;
                        vAccordionContent.IsVisible = mFirstExpaned;
                        vFirst = false;
                    }
                    vHeaderButton.AssosiatedContent = vAccordionContent;
                    vHeaderButton.Clicked += OnAccordionButtonClicked;
                    vMainLayout.Children.Add(vHeaderButton);
                    vMainLayout.Children.Add(vAccordionContent);
                }
            }
            mMainLayout = vMainLayout;
            Content = mMainLayout;
        }

        void OnAccordionButtonClicked(object sender, EventArgs args)
        {
            foreach (var vChildItem in mMainLayout.Children)
            {
                if (vChildItem.GetType() == typeof(ContentView))
                    vChildItem.IsVisible = false;
                if (vChildItem.GetType() == typeof(AccordionButton))
                {
                    var vButton = (AccordionButton)vChildItem;
                    vButton.Expand = false;
                }
            }
            var vSenderButton = (AccordionButton)sender;

            if (vSenderButton.Expand)
            {
                vSenderButton.Expand = false;
            }
            else vSenderButton.Expand = true;
            vSenderButton.AssosiatedContent.IsVisible = vSenderButton.Expand;
        }
    }
}