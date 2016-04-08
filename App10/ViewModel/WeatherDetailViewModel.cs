using App10.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App10.ViewModel
{
    public class WeatherDetailViewModel : ViewModelBase
    {
        private ObservableCollection<Model.ForecastModel.Hour> hourList;

        public ObservableCollection<Model.ForecastModel.Hour> HourList
        {
            get { return hourList; }
            set
            {
                Set(() => HourList, ref hourList, value);
            }
        }

        /// <summary>
        /// gerekli olursa model değiştirrlerek alınacak
        /// </summary>
        //private string date;
        //public string Date
        //{
        //    get { return date; }
        //    set { Set(() => Date, ref date, value); }
        //}

        public WeatherDetailViewModel()
        {
            HourList = new ObservableCollection<ForecastModel.Hour>();
        }

        private RelayCommand<ObservableCollection<ForecastModel.Hour>> detailCommand;

        public RelayCommand<ObservableCollection<ForecastModel.Hour>> DetailCommand
        {
            get
            {
                return detailCommand ??
                    (
                    detailCommand = new RelayCommand<ObservableCollection<ForecastModel.Hour>>(

                        detailItem =>
                        {
                            HourList = detailItem;
                        }));
            }
        }
    }
}
