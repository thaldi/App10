using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace App10.Model
{
    public class WeatherService : IWeatherService
    {
        public async Task<Weather.RootObject> Get(string value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(Helper.ConstantHelper.SetUrl(true) + value);
                    var list = JsonConvert.DeserializeObject<Weather.RootObject>(data);
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<City>> GetCities(string value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(Helper.ConstantHelper.SetSearchUrl() + value);
                    var list = JsonConvert.DeserializeObject<List<City>>(data);
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ForecastModel.RootObject> GetForecast(string value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(Helper.ConstantHelper.SetUrl(false) + value + "&days=7");
                    var list = JsonConvert.DeserializeObject<ForecastModel.RootObject>(data);
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
