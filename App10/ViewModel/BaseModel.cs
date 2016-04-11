using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using App10.Model;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace App10.ViewModel
{
    public class BaseModel : ViewModelBase
    {
        private readonly IWeatherService dataService;
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;
        private ForecastModel.RootObject CurrentTemps;



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

        private ObservableCollection<City> cityList;

        public ObservableCollection<City> CityList
        {
            get { return cityList; }
            set { Set(() => CityList, ref cityList, value); }
        }

        private string btnContent;

        public string BtnContent
        {
            get { return btnContent; }
            set { Set(() => BtnContent, ref btnContent, value); }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                Set(() => Title, ref title, value);
            }
        }

        private string icon;
        public string Icon
        {
            get { return icon; }
            set { Set(() => Icon, ref icon, value); }
        }

        private string temp;
        public string Temp
        {
            get { return temp; }
            set { Set(() => Temp, ref temp, value); }
        }


        private bool progres;

        public bool Progress
        {
            get { return progres; }
            set { Set(() => Progress, ref progres, value, true); }
        }

        private bool corf;
        public bool CorF
        {
            get { return corf; }
            set { Set(() => CorF, ref corf, value); }
        }

        private RelayCommand<bool> ctoFCommand;

        public RelayCommand<bool> CtoFCommand
        {
            get
            {
                return ctoFCommand ?? (

                    ctoFCommand = new RelayCommand<bool>(
                        value =>
                        {
                            if (CorF)
                                CorF = false;
                            else
                                CorF = true;
                            SetFTemp(CorF);
                        }));
            }
        }


        private RelayCommand<string> cityWeatherCommand;

        public RelayCommand<string> CityWeatherCommand
        {
            get
            {
                return cityWeatherCommand ?? (

                    cityWeatherCommand = new RelayCommand<string>(
                        async value =>
                        {
                            await GetForecastWeather(value);
                        }));
            }
        }

        private RelayCommand<ForecastModel.Forecastday> detailCommand;
        public RelayCommand<ForecastModel.Forecastday> DetailCommand
        {
            get
            {
                return detailCommand ?? (

                    detailCommand = new RelayCommand<ForecastModel.Forecastday>(

                        forecastItem =>
                        {
                            navigationService.NavigateTo(ViewModelLocator.DetailPage, forecastItem);

                        }));
            }
        }

        private RelayCommand<string> searchCommand;

        public RelayCommand<string> SerachCommand
        {
            get
            {
                return searchCommand ?? (
                    searchCommand = new RelayCommand<string>(
                        async value =>
                        {
                            await GetSearchData(value);
                        }));
            }
        }


        public BaseModel(IWeatherService service, INavigationService navService, IDialogService DialogService)
        {
            Progress = true;
            corf = false;
            BtnContent = "C or F";

            this.dataService = service;
            this.navigationService = navService;
            this.dialogService = DialogService;

            CurrentTemps = new ForecastModel.RootObject();
            CityList = new ObservableCollection<City>();

            GetForecastWeather("istanbul");
        }

        private async Task GetForecastWeather(string value)
        {
            try
            {
                Progress = true;
                CurrentTemps = await dataService.GetForecast(value);
                Title = CurrentTemps.location.name;
                Icon = CurrentTemps.current.condition.icon;
                Temp = CurrentTemps.current.temp_c.ToString() + " °C";

                ForecastList = CurrentTemps.forecast.forecastday;
            }
            catch (Exception ex)
            {
                //await dialogService.ShowMessage(ex.Message, "Notice");
            }
            finally
            {
                Progress = false;
            }
        }

        private void SetFTemp(bool value)
        {
            Temp = value ? CurrentTemps.current.temp_f.ToString() + " K" : CurrentTemps.current.temp_c.ToString() + " °C";
        }


        private async Task GetSearchData(string value)
        {
            try
            {
                var data = await dataService.GetCities(value);
                if (CityList != null)
                    CityList.Clear();
                foreach (var item in data)
                    CityList.Add(item);
            }
            catch (Exception ex)
            {
                //await dialogService.ShowMessage(ex.Message, "Notice");
            }
        }
    }
}
