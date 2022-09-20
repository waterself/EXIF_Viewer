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
using System.Net.WebSockets;
using EXIF_Viewer.Model;
using System.Collections.ObjectModel;

namespace EXIF_Viewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //바인딩 컨텍스트에서 모델을 찾을 수 없음
        public MainModel Model = new();
        
        private ImageDetailsModel _imageDetailModel;

        public ImageDetailsModel _imageDetailsModel
        {
            get { return _imageDetailModel; }
            set {
                _imageDetailModel = value;
                OnPropertyChanged(nameof(_imageDetailsModel)); 
            }
        }

        public ICommand FileSelectButtonCommand { get; set; }
        
        public MainViewModel()
        {
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void File_select_btn_click()
        { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.JPG|*.jpeg";
            openFileDialog.Filter = "Images(.JPG)|*.jpg|Images(.jpeg)|*.jpeg";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                Model.SelctedFile = openFileDialog.SafeFileName;
                OnPropertyChanged(nameof(Model.SelctedFile));
                FileInfo SelectedFile = new FileInfo(openFileDialog.FileName);
                GetData(SelectedFile);
            }
        }
        private ObservableCollection<ImageDetailsModel> _imageDetails = new();

        public ObservableCollection<ImageDetailsModel> ImageDetails
        {
            get { return _imageDetails; }
            set { _imageDetails = value; }
        }

        public void GetData(FileInfo f)
        {   
            //객체 리소스를 사용 후 자동 정리
            using FileStream fs = new(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

/*            DataTable MetaDataTable = new();
            MetaDataTable.Columns.Add("attribute");
            MetaDataTable.Columns.Add("value");*/

            BitmapSource image = BitmapFrame.Create(fs);
            BitmapMetadata metaData = image.Metadata as BitmapMetadata;

            ImageDetailsModel imageDetails = new();
            imageDetails.CameraModel = metaData.CameraModel;
            imageDetails.Comment = metaData.Comment;
            imageDetails.CopyRight = metaData.Copyright;
            imageDetails.DateTaken = metaData.DateTaken;
            imageDetails.Location = metaData.Location;
            imageDetails.Format = metaData.Format;
      
            ImageDetails.Add(imageDetails);


            /*MetaDataTable.Columns.Add("ApplicaionName", metaData.ApplicationName);
            MetaDataTable.Columns.Add("Author", metaData.Author);
            MetaDataTable.Columns.Add("CameraManufacturer", metaData.CameraManufacturer);
            MetaDataTable.Columns.Add("CameraModel", metaData.CameraModel);
            MetaDataTable.Columns.Add("CanFreez", metaData.CanFreeze);
            MetaDataTable.Columns.Add("Comment", metaData.Comment);
            MetaDataTable.Columns.Add("CopyRight", metaData.Copyright);
            MetaDataTable.Columns.Add("DateTaken", metaData.DateTaken);
            MetaDataTable.Columns.Add("DependencyObjectType", metaData.DependencyObjectType);
            MetaDataTable.Columns.Add("Dispatcher", metaData.Dispatcher);
            MetaDataTable.Columns.Add("Format", metaData.Format);
            MetaDataTable.Columns.Add("IsFixedSize", metaData.IsFixedSize);
            MetaDataTable.Columns.Add("IsFrozen", metaData.IsFrozen);
            MetaDataTable.Columns.Add("IsReadOnly", metaData.IsReadOnly);
            MetaDataTable.Columns.Add("IsSealed", metaData.IsSealed);
            MetaDataTable.Columns.Add("Keywords", metaData.Keywords);
            MetaDataTable.Columns.Add("Location", metaData.Location);
            MetaDataTable.Columns.Add("Rating", metaData.Rating);
            MetaDataTable.Columns.Add("Subject", metaData.Subject);
            MetaDataTable.Columns.Add("Title", metaData.Title);
            return MetaDataTabel;
             */

        }
    }
}
