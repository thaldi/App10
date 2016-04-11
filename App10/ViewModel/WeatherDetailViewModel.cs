using App10.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
        private readonly INavigationService navigationService;

        private ObservableCollection<Model.ForecastModel.Hour> hourList;

        public ObservableCollection<Model.ForecastModel.Hour> HourList
        {
            get { return hourList; }
            set
            {
                Set(() => HourList, ref hourList, value);
            }
        }

        public WeatherDetailViewModel(INavigationService nService)
        {
            navigationService = nService;
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


        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ?? (

                    backCommand = new RelayCommand(
                        () =>
                        {
                            navigationService.GoBack();
                        }));
            }
        }

    }
}
