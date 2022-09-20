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
        private string? _selectedFile;

        public string? SelctedFile
        {
            get { return _selectedFile; }
            set { _selectedFile = value; 
            OnPropertyChanged(nameof(SelctedFile)); 
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name) { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
        
}
