﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}