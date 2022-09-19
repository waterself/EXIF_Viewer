using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EXIF_Viewer
{
    public class FileSelectButtonCommand : ICommand
    {
        Action<object> excuteMethod;
        Func<object, bool> canExcuteMethod;

        public FileSelectButtonCommand(Action<object> excuteMethod, Func<object, bool> canExcuteMethod)
        {
            this.excuteMethod = excuteMethod;
            this.canExcuteMethod = canExcuteMethod;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            excuteMethod(parameter);
        }
    }
}
