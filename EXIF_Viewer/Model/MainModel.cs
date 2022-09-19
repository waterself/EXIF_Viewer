using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace EXIF_Viewer
{
    public class MainModel : INotifyPropertyChanged
    {
        public FileInfo? SelectedFile;
        public DataTable? FileDataTable;
        public MainModel()
        {
            SelectedFile = null;
            FileDataTable = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
        
}
