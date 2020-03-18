using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppPrevisao.Model;

namespace AppPrevisao.TempoService
{
    class TempoService
    {
        public static async Task<Tempo> GetPrevisaoTempo(string cidade)
        {
            string appId = "suakey";
            string queryString = "https://api.openweathermap.org/data/2.5/weather?q="+cidade.Trim()+"&units=metric&appid="+appId.Trim();
            dynamic response = await getDataFromService(queryString).ConfigureAwait(false);

            if (response["weather"] != null)
            {
                Tempo temp = new Tempo();
                temp.title = (string)response["name"];
                temp.temperature = (string)response["main"]["temp"] + "C";
                temp.wind = (string)response["wind"]["speed"] + "mph";
                temp.humidity= (string)response["main"]["humidity"] + "%";
                temp.visibility = (string)response["weather"][0]["main"];
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)response["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)response["sys"]["sunset"]);
                temp.sunrise = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunrise);
                temp.sunset = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunset);

                return temp;
            }
            else
            {
                return null;
            }
        }
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }

    }
}
