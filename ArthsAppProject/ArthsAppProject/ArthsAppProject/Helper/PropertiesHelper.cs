using System;
using System.Collections.Generic;
using System.Text;

namespace ArthsAppProject.Helper
{
    public static class PropertiesHelper
    {
        public const string Id_User_Key = "idUser";

        public static void SetUser(this User user)
        {
            if (App.Current.Properties.ContainsKey(Id_User_Key))
            {
                App.Current.Properties[Id_User_Key] = user.Id_u;
            }
            else
            {
                App.Current.Properties.Add(Id_User_Key, user.Id_u);
            }
        }

        public static string GetUser()
        {
            return App.Current.Properties[Id_User_Key] as string;
        }
    }
}
