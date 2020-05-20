using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using JSONPlaceholder.Models;
using JSONPlaceholder.Services;

namespace JSONPlaceholder.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class BaseViewModel<T2> : BaseViewModel
    {
        T2 item;
        public T2 Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }

        public BaseViewModel(T2 item)
        {
            this.Item = item;
        }
        public BaseViewModel()
        {
        }

    }
    public class BaseViewModel<T2,I> : BaseViewModel
    {
        public BaseViewModel(T2 item) 
        {
        }
        public BaseViewModel() : base()
        {
        }

        public IDataStore<T2,I> DataStore => DependencyService.Get<IDataStore<T2,I>>();

    }
}
