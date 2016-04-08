using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App10.Model
{
    public interface IWeatherService
    {
        Task<Weather.RootObject> Get(string value);
        Task<ForecastModel.RootObject> GetForecast(string value);
        Task<List<City>> GetCities(string value);
    }
}
