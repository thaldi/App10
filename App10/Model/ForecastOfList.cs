using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App10.Model
{
    public class ForecastOfList : ViewModelBase
    {
        ObservableCollection<ForecastModel.Forecastday> forecastList;
        public ObservableCollection<ForecastModel.Forecastday> ForecastList
        {
            get
            {
                return forecastList;
            }
            set
            {
                Set(() => ForecastList, ref forecastList, value);
            }
        }
    }
}
