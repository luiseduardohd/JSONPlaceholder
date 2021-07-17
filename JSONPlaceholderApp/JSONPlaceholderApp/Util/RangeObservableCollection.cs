using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;

namespace JSONPlaceholder.Util
{
    public class RangeObservableCollection<T> : ObservableCollection<T> 
    {
        private int NotifyFirstNElements { get; set; } = 8;

        public RangeObservableCollection()
        {
            base.CollectionChanged += CollectionChanged_Handler;
        }

        #region RangeObservableCollection

        private bool _suppressNotification = false;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
                base.OnCollectionChanged(e);
        }

        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            int count = 0;
            

            foreach (T item in list)
            {
                if (count >= NotifyFirstNElements)
                {
                    _suppressNotification = true;
                }
                Add(item);
                if( item is INotifyPropertyChanged )
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemChanged;
                }
                count++;
            }
            _suppressNotification = false;

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void ClearRange()
        {
            _suppressNotification = true;

            foreach (T item in Items)
            {
                if (item is INotifyPropertyChanged)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemChanged;
                }
            }                

            ClearItems();

            _suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        #endregion RangeObservableCollection

        #region ItemObservableCollection

        void CollectionChanged_Handler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (T x in e.OldItems)
                {
                    if (x is INotifyPropertyChanged)
                    {
                        ((INotifyPropertyChanged)x).PropertyChanged -= ItemChanged;
                    }
                }
            }

            if (e.NewItems != null)
            {
                foreach (T x in e.NewItems)
                {
                    if (x is INotifyPropertyChanged)
                    {
                        ((INotifyPropertyChanged)x).PropertyChanged += ItemChanged;
                    }
                }
            }
        }

        private void ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        #endregion ItemObservableCollection
    }
}

