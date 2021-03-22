//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


//This file contains fragments that You have to fulfill

using BigTask2.Api;
using System.Collections.Generic;
using System.Linq;

namespace BigTask2.Data
{
	class MatrixDatabase : IGraphDatabase
	{
		private Dictionary<City, int> cityIds = new Dictionary<City, int>();
		private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
		private List<List<Route>> routes = new List<List<Route>>();

		private void AddCity(City city)
		{
			if (!cityDictionary.ContainsKey(city.Name))
			{
				cityDictionary[city.Name] = city;
				cityIds[city] = cityIds.Count;
				foreach (var routes in routes)
				{
					routes.Add(null);
				}
				routes.Add(new List<Route>(Enumerable.Repeat<Route>(null, cityDictionary.Count)));
			}
		}
		public MatrixDatabase(IEnumerable<Route> routes)
		{
            foreach (var route in routes)
			{
				AddCity(route.From);
				AddCity(route.To);
			}
			foreach (var route in routes)
			{
				this.routes[cityIds[route.From]][cityIds[route.To]] = route;
			}
		}

		public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
		{
			AddCity(from);
			AddCity(to);
			routes[cityIds[from]][cityIds[to]] = new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle };
		}

		public /*void*/ IDatabaseItterator GetRoutesFrom(City from)
		{
            int id;
            if (cityIds.TryGetValue(from, out id))
                return new MatrixItterator(routes[id]);
            else
                return new MatrixItterator(new List<Route>());
			/*
			* Fill this fragment and return Type.
			* Modyfing existing code in this class is forbidden.
			* Adding new elements (fields, private classes) to this class is allowed.
			*/
		}

		public City GetByName(string cityName)
		{
			return cityDictionary[cityName];
		}
	}

    class MatrixItterator : IDatabaseItterator
    {
        List<Route> id;
        int i = 0;
        public MatrixItterator(List<Route> _id)
        {
            id = _id;
            if (id.Count > 0 && id[0] == null)
                Next();
        }

        public Route Current
        {
            get
            {
                if (i < id.Count)
                    return id[i];
                return null;
            }
        }

        public bool Next()
        {
            do
            {
                i++;
            } while (i < id.Count && id[i] == null);

            if (i < id.Count)
                return true;
            return false;
        }
    }
}
