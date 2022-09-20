using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Data;
using System.ComponentModel;
using EXIF_Viewer;
using System.Windows.Input;

namespace EXIF_Viewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainModel Model = new MainModel();

        public ICommand FileSelectButtonCommand { get; set; }
        
        public MainViewModel()
        {
            Model.FileDataTable = null;
            Model.SelectedFile = null;
            FileSelectButtonCommand = new FileSelectButtonCommand(excuteMethod, canExcuteMethod);
        }

        private bool canExcuteMethod(object arg)
        {
            return true;
        }

        private void excuteMethod(object obj)
        {
            File_select_btn_click();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void File_select_btn_click()
        { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.JPG|*.jpeg";
            openFileDialog.Filter = "Images(.JPG)|*.jpg|Images(.jpeg)|*.jpeg";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            { 
                
                Model.FileDataTable = GetData(Model.SelectedFile);
                OnPropertyChanged("Model.SelectedFile");
                OnPropertyChanged("Model.FileDataTable");
                GetData(Model.SelectedFile);
            }
        }
        public DataTable GetData(FileInfo f)
        {
            using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                DataTable MetaDataTable = new DataTable();
                MetaDataTable.Columns.Add("attribute");
                MetaDataTable.Columns.Add("value");

                BitmapSource image = BitmapFrame.Create(fs);
                BitmapMetadata metaData = image.Metadata as BitmapMetadata;

                MetaDataTable.Rows.Add("ApplicaionName", metaData.ApplicationName);
                MetaDataTable.Rows.Add("Author", metaData.Author);
                MetaDataTable.Rows.Add("CameraManufacturer", metaData.CameraManufacturer);
                MetaDataTable.Rows.Add("CameraModel", metaData.CameraModel);
                MetaDataTable.Rows.Add("CanFreez", metaData.CanFreeze);
                MetaDataTable.Rows.Add("Comment", metaData.Comment);
                MetaDataTable.Rows.Add("CopyRight", metaData.Copyright);
                MetaDataTable.Rows.Add("DateTaken", metaData.DateTaken);
                MetaDataTable.Rows.Add("DependencyObjectType", metaData.DependencyObjectType);
                MetaDataTable.Rows.Add("Dispatcher", metaData.Dispatcher);
                MetaDataTable.Rows.Add("Format", metaData.Format);
                MetaDataTable.Rows.Add("IsFixedSize", metaData.IsFixedSize);
                MetaDataTable.Rows.Add("IsFrozen", metaData.IsFrozen);
                MetaDataTable.Rows.Add("IsReadOnly", metaData.IsReadOnly);
                MetaDataTable.Rows.Add("IsSealed", metaData.IsSealed);
                MetaDataTable.Rows.Add("Keywords", metaData.Keywords);
                MetaDataTable.Rows.Add("Location", metaData.Location);
                MetaDataTable.Rows.Add("Rating", metaData.Rating);
                MetaDataTable.Rows.Add("Subject", metaData.Subject);
                MetaDataTable.Rows.Add("Title", metaData.Title);

                return MetaDataTable;
            }
        }
    }
}
