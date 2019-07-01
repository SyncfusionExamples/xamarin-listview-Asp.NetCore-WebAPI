using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SfListViewSample
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        #region Fields

        RestService restService;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Order> items;

        #endregion

        #region Properties
        public ObservableCollection<Order> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }
        #endregion

        #region Constructor
        public OrdersViewModel()
        {
            restService = new RestService();
            //Item source which needs to be displayed on the list view.
            items = new ObservableCollection<Order>();
            GetData();
        }
        #endregion

        #region Methods 
        async void GetData()
        {
            Items = await restService.RefreshDataAsync();
        }
        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
