using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFWordleCheats.ViewModel
{
    public interface IViewModelTitleProvider
    {
        public string ViewModelTitle { get; }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModelTitleProvider
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract string ViewModelTitle { get; }
    }
}
