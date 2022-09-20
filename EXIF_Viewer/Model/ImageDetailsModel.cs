using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXIF_Viewer.Model
{
    public class ImageDetailsModel : INotifyPropertyChanged
    {
        public string? Location { get; set; }
        public string? CameraModel { get; set; }
        public string? Comment { get; set; }
        public string? CopyRight { get; set; }
        public string? DateTaken { get; set; }
        public string? Format { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
/*private string _applicationName;

public string ApplicationName
{
    get { return _applicationName; }
    set
    {
        _applicationName = value;
        OnPropertyChanged(nameof(ApplicationName));
    }
}
private string _author;

public string Author
{
    get { return _author; }
    set
    {
        _author = value;
        OnPropertyChanged(nameof(_author));
    }
}
private string _cameraModel;

public string CameraModel
{
    get { return _cameraModel; }
    set
    {
        _cameraModel = value;
        OnPropertyChanged(nameof(_cameraModel));
    }
}*/