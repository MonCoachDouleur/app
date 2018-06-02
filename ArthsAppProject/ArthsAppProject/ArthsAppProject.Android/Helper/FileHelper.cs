using ArthsAppProject.Droid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ArthsAppProject.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String Applicationfolderpath = Path.Combine(path,"Database1");
            Directory.CreateDirectory(Applicationfolderpath);
            return Path.Combine(Applicationfolderpath, filename);
        }
    }
}
