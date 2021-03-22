//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


//This file contains fragments that You have to fulfill

using BigTask2.Api;
using System.Collections.Generic;

namespace BigTask2.Data
{
	class AdjacencyListDatabase : IGraphDatabase
    {
		private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
		private Dictionary<City, List<Route>> routes = new Dictionary<City, List<Route>>();
		
		private void AddCity(City city)
		{
			if (!cityDictionary.ContainsKey(city.Name))
				cityDictionary[city.Name] = city;
		}
		public AdjacencyListDatabase(IEnumerable<Route> routes)
		{
			foreach(Route route in routes)
			{
				AddCity(route.From);
				AddCity(route.To);
				if (!this.routes.ContainsKey(route.From))
				{
					this.routes[route.From] = new List<Route>();
				}
				this.routes[route.From].Add(route);
			}
		}
		public AdjacencyListDatabase()
		{
		}
		public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
		{
			AddCity(from);
			AddCity(to);
			if (!routes.ContainsKey(from))
			{
				routes[from] = new List<Route>();
			}
			routes[from].Add(new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle});
		}

		public /*void*/ IDatabaseItterator GetRoutesFrom(City from)
		{
            List<Route> list;
            if (routes.TryGetValue(from, out list))
                return new AdjacencyListItterator(list);
            else
                return new AdjacencyListItterator(new List<Route>());

			/*
			 * Fill this fragment and return Type.
			 * Modyfing existing code in this class is forbidden.
			 * Adding new elements (fields, private classes) to this class is allowed.
			 */
		}

		public City GetByName(string cityName)
		{
            //cityDictionary.GetValueOrDefault(cityName);

            //Dictionary class does not appear to have a GetValueOrDefault method .NET framework 4.7.1,
            //so I replaced it with an equivalent.

            City city;
            if (cityDictionary.TryGetValue(cityName, out city))
                return city;
            return new City();
		}
	}

    class AdjacencyListItterator : IDatabaseItterator
    {
        List<Route> list;
        int i = 0;
        public AdjacencyListItterator(List<Route> l) { list = l; }

        public Route Current
        {
            get
            {
                if (i < list.Count)
                    return list[i];
                return null;
            }
        }

        public bool Next()
        {
            i++;
            if (i < list.Count)
                return true;
            return false;
        }
    }
}
