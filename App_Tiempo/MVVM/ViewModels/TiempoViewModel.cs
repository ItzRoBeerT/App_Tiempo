using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Tiempo.MVVM.ViewModels
{
    public class TiempoViewModel
    {

        private async Task<Location> GetCoordinatesAsync(string address)
        {
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();

            return location;
        }
    }
}
