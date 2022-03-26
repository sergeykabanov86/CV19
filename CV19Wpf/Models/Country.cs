using System.Collections.Generic;
using System.Windows;

namespace CV19Wpf.Models
{

    internal class PlaceInfo
    {
        public string Name { get; set; }

        public Point Location { get; set; }
        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }


    internal class Country :PlaceInfo
    {
        public IEnumerable<Province> ProvinceCounts { get; set; }
    }



    internal class Province : PlaceInfo
    {

    }

}
