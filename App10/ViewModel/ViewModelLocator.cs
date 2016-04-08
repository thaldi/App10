using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App10.Model;
using GalaSoft.MvvmLight.Views;

namespace App10.ViewModel
{
    public class ViewModelLocator
    {
        public const string DetailPage = "DetailPage";


        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(DetailPage, typeof(View.DetailPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            SimpleIoc.Default.Register<IDialogService, DialogService>();


            SimpleIoc.Default.Register<IWeatherService, WeatherService>();


            SimpleIoc.Default.Register<BaseModel>();
            SimpleIoc.Default.Register<WeatherDetailViewModel>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public BaseModel Main => ServiceLocator.Current.GetInstance<BaseModel>();
        public WeatherDetailViewModel Detail => ServiceLocator.Current.GetInstance<WeatherDetailViewModel>();
    }
}
