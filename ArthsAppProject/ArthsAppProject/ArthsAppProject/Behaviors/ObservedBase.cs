using ArthsAppProject.Infrastructure;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace ArthsAppProject.Behaviors
{
    public class ObservedBase : AppMapViewModelBase,INotifyPropertyChanged

    {

        public ObservedBase(INavigationService navigationService) : base(navigationService) { }



        #region INotifyPropertyChanged Members



        public event PropertyChangedEventHandler PropertyChanged;



        protected void RaisePropertyChanged<T>(Expression<Func<T>> expression)

        {



            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)

            {

                string propertyName = memberExpression.Member.Name;

                RaisePropertyChanged(propertyName);

            }

        }



        private void RaisePropertyChanged(String propertyName)

        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)

                handler(this, new PropertyChangedEventArgs(propertyName));



        }



        #endregion

    }
}
