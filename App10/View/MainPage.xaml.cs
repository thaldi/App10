using App10.Model;
using App10.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace App10.View
{

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<City> cities = new ObservableCollection<City>();
        private bool value = true;       

        public MainPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            cities = (DataContext as BaseModel).CityList;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void auotComplateBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (!string.IsNullOrEmpty(sender.Text))
                {
                    (DataContext as BaseModel).SerachCommand.Execute(sender.Text);
                }
                else
                    sender.ItemsSource = cities;
            }
        }

        private void auotComplateBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                var selected = args.ChosenSuggestion as City;
                auotComplateBox.Text = selected.Name;

                var vm = (BaseModel)DataContext;
                vm.CityWeatherCommand.Execute(selected.Region);
            }
        }


        private void CtoFBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = (BaseModel)DataContext;
            vm.CtoFCommand.Execute(value);
            if (value)
                value = false;
            else
                value = true;
        }

        private void weatherList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = e.ClickedItem as ForecastModel.Forecastday;
            (DataContext as BaseModel).DetailCommand.Execute(data);
        }
    }
}
