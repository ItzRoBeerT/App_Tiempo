using App_Tiempo.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App_Tiempo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TiempoViewModel
    {
        HttpClient client;
        public Tiempo TiempoData { get; set; }
        public ICommand buscarCommand { get; set; }
        public string NombreZona { get; set; }

        public TiempoViewModel()
        {
            client = new HttpClient();
            buscarCommand = new Command(async (e) =>
            {
                NombreZona = e.ToString();
                Location loc = await GetCoordinatesAsync(NombreZona);
                await GetWeather(loc);
            });
       
        }

        private async Task<Location> GetCoordinatesAsync(string address)
        {
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();

            return location;
        }

        private async Task GetWeather(Location location)
        {
            string longitud = (Math.Round(location.Longitude, 2).ToString().Replace(",", "."));
            string latitud = (Math.Round(location.Latitude, 2).ToString().Replace(",", "."));

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitud}&longitude={longitud}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=auto";
            var url2 = "https://api.open-meteo.com/v1/forecast?latitude=36.69&longitude=-6.14&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=auto";
            var respone = await client.GetAsync(url);

            if (respone.IsSuccessStatusCode)
            {
                using (var responseStream = await respone.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                        .DeserializeAsync<Tiempo> (responseStream);
                    TiempoData = data;
                }
            }
        }
    }

}
