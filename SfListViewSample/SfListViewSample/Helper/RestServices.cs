using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SfListViewSample
{
    /// <summary>
    /// Implementation of RestService to be displayed.
    /// </summary>
    public class RestService : IRestService
    {
        #region Fields 

        System.Net.Http.HttpClient client;

        #endregion

        #region Properties 

        public ObservableCollection<Order> Items
        {
            get; private set;
        }

        public string RestUrl
        {
            get; private set;
        }

        #endregion

        #region Constructor
        public RestService()
        {
            client = new System.Net.Http.HttpClient();
        }

        #endregion

        #region Methods
        public async System.Threading.Tasks.Task<ObservableCollection<Order>> RefreshDataAsync()
        {
            RestUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; // Set your REST API url here
            var uri = new Uri(RestUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<Order>>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        System.Threading.Tasks.Task<Order> IRestService.RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public interface IRestService
    {
        System.Threading.Tasks.Task<Order> RefreshDataAsync();
    }

}
