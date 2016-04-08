using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace App10.Model
{
    public class WeatherOfList : ViewModelBase
    {

        private ObservableCollection<Weather.RootObject> weatherList;

        public ObservableCollection<Weather.RootObject> WeatherList
        {
            get { return weatherList; }
            set { Set(() => WeatherList, ref weatherList, value); }
        }




        private async Task GetForecastWeather(string value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(Helper.ConstantHelper.SetUrl(false) + value);



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
