using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App10.Helper
{
    public class StaticHelper
    {
        public static ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;

        public StaticHelper()
        {
            if (container.Values["city"] == null)
                container.Values.Add("city", "istanbul");
        }

    }
}
