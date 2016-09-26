﻿using Final_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWeatherDataService OpenWeatherMapInstance = OpenWeatherMap.Instance;
            IWeatherDataService service = WeatherDataServiceFactory.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            WeatherData Wd = new WeatherData();
            string CodeName;
            
            while (true)
            {
                Console.WriteLine("Please enter the city or Exit to exit...");
                CodeName = Console.ReadLine();
                if (CodeName.Equals("Exit"))
                    break;
                Location city = new Location(CodeName);
                /// Wd= OpenWeatherMapInstance.GetWeatherData(city);
                Wd = service.GetWeatherData(city);
                if (Wd == null) continue;
                Console.WriteLine("Hey Sir, You requested to see the weather in {0} in country {1}", Wd.cityName,Wd.country);
                Console.WriteLine("the last update i have is from {0} \nthe weather looks {1} ", Wd.lastupdate,Wd.weather);
                Console.WriteLine("cloud status is {0} \nthe wind speed is {1} \nthe pressure (hmm wtf is this..) is {2}", Wd.clouds,Wd.windSpeed,Wd.pressure);
                Console.WriteLine("the humidity is {0}% \n\n", Wd.humidity);
            }
            Console.WriteLine("bye bye and thank you for using Nir and Yogev code");
        }
    }
}
