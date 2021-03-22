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
    class MergedDatabase : IGraphDatabase
    {
        List<IGraphDatabase> Databases = new List<IGraphDatabase>();

        public MergedDatabase(params IGraphDatabase[] _databases)
        {
            foreach(IGraphDatabase data in _databases)
                Databases.Add(data);
        }

        public void AddDatabase(IGraphDatabase database)
        {
            Databases.Add(database);
        }

        public City GetByName(string cityName)
        {
            foreach(IGraphDatabase data in Databases)
            {
                if (data.GetByName(cityName) != null)
                    return data.GetByName(cityName);
            }
            return null;
        }

        public IDatabaseItterator GetRoutesFrom(City from)
        {

            List<IDatabaseItterator> list = new List<IDatabaseItterator>();
            foreach(var db in Databases)
            {
                list.Add(db.GetRoutesFrom(from));
            }
            return new MergedItterator(list);
        }
    }

    class MergedItterator : IDatabaseItterator
    {
        List<IDatabaseItterator> list;
        int i = 0;
        public MergedItterator(List<IDatabaseItterator> l) { list = l; }

        public Route Current
        {
            get
            {
                if (i < list.Count)
                    return list[i].Current;
                return null;
            }
        }

        public bool Next()
        {
            if(i<list.Count)
            {
                if(!list[i].Next())
                {
                    do
                    {
                        i++;
                    } while (i < list.Count && Current == null);
                }
            }
            if (i < list.Count)
                return true;
            return false;
        }
    }
}
