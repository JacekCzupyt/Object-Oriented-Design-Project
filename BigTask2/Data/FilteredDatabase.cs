//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigTask2.Api;

namespace BigTask2.Data
{
    class FilteredDatabase : IGraphDatabase
    {
        IGraphDatabase database;
        Filter filter;

        public FilteredDatabase(IGraphDatabase d, Filter f) { database = d; filter = f; }

        public City GetByName(string cityName)
        {
            City city = database.GetByName(cityName);
            if(city==null || 
                city.Population<filter.MinPopulation || 
                (city.HasRestaurant==false && filter.RestaurantRequired==true))
            {
                return null;
            }
            return city;
        }

        public IDatabaseItterator GetRoutesFrom(City from)
        {
            return new FilteredItterator(database.GetRoutesFrom(from), filter);
        }
    }

    class FilteredItterator : IDatabaseItterator
    {
        IDatabaseItterator itterator;
        Filter filter;
        public FilteredItterator(IDatabaseItterator i, Filter f)
        {
            itterator = i;
            filter = f;
            if (itterator.Current != null && !isValid(itterator.Current))
                Next();
        }

        private bool isValid(Route route)
        {
            if (filter.AllowedVehicles.Contains(route.VehicleType) &&
                    filter.MinPopulation <= route.To.Population &&
                    filter.MinPopulation <= route.From.Population &&
                    (filter.RestaurantRequired == false || 
                    (route.To.HasRestaurant == true && route.From.HasRestaurant == true)))
                return true;
            return false;
        }

        public Route Current
        {
            get
            {
                return itterator.Current;
            }
        }

        public bool Next()
        {
            do
            {
                itterator.Next();
            } while (itterator.Current != null && !isValid(itterator.Current));
            return (itterator.Current == null);
        }
    }
}
