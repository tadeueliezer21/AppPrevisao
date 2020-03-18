using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrevisao.Model
{
    class Tempo
    {
        public string title { get; set; }
        public string temperature { get; set; }
        public string wind { get; set; }
        public string humidity { get; set; }
        public string visibility { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }

        public Tempo()
        {
            this.title = "";
            this.temperature = "";
            this.wind = "";
            this.humidity = "";
            this.visibility = "";
            this.sunrise = "";
            this.sunset = "";

        }
    }
}
