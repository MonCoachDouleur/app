using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ArthsAppProject.Views
{
    public class AccordionButton : Button
    {
        bool mExpand = false;
        public AccordionButton()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            BorderColor = Color.Black;
            BorderRadius = 5;
            BorderWidth = 0;
        }
        #region Properties
        public bool Expand
        {
            get { return mExpand; }
            set { mExpand = value; }
        }
        public ContentView AssosiatedContent
        { get; set; }
        #endregion
    }
}