using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App10.Model
{
    public class City : ViewModelBase
    {

        private int id;
        public int ID
        {
            get { return id; }
            set { Set(() => ID, ref id, value); }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
        }

        private string region;

        public string Region
        {
            get { return region; }
            set { Set(() => Region, ref region, value); }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { Set(() => Country, ref country, value); }
        }


        private double lat;
        public double Lat
        {
            get { return lat; }
            set { Set(() => Lat, ref lat, value); }
        }


        private double lon;
        public double Lon
        {
            get { return lon; }
            set { Set(() => Lon, ref lon, value); }
        }


        private string url;
        public string Url
        {
            get { return url; }
            set { Set(() => Url, ref url, value); }
        }

    }
}
