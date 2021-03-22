//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigTask2.Api;

namespace BigTask2.Ui
{
    abstract class AbstractDisplay : IDisplay
    {
        public void Print(IEnumerable<Route> routes)
        {
            if(routes==null)
            {
                Console.WriteLine(DisplayType(""));
                return;
            }

            DisplayCity(routes.First().From);
            foreach(Route route in routes)
            {
                DisplayRoute(route);
                DisplayCity(route.To);
            }

            Console.WriteLine(DisplayArgument("totalTime", routes.Sum(v => v.TravelTime)));
            Console.WriteLine(DisplayArgument("totalCost", routes.Sum(v => v.Cost)));
            Console.WriteLine();
        }

        static string GetVehicleName(VehicleType vehicle)
        {
            switch(vehicle)
            {
                case VehicleType.Car:
                    return "Car";
                case VehicleType.Train:
                    return "Train";
                default:
                    throw new ArgumentException();
            }
        }

        void DisplayCity(City city)
        {
            Console.WriteLine(DisplayType("City"));
            Console.WriteLine(DisplayArgument("Name", city.Name));
            Console.WriteLine(DisplayArgument("Population", city.Population));
            Console.WriteLine(DisplayArgument("HasRestaurant", city.HasRestaurant));
            Console.WriteLine();
        }

        void DisplayRoute(Route route)
        {
            Console.WriteLine(DisplayType("Route"));
            Console.WriteLine(DisplayArgument("Vehicle", GetVehicleName(route.VehicleType)));
            Console.WriteLine(DisplayArgument("Cost", route.Cost));
            Console.WriteLine(DisplayArgument("TravelTime", route.TravelTime));
            Console.WriteLine();
        }

        protected abstract string DisplayType(string type);
        protected abstract string DisplayArgument(string argument, object value);
    }
}
