//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


//This file contains fragments that You have to fulfill

using BigTask2.Api;
namespace BigTask2.Data
{
    public interface IGraphDatabase
    {
        //Fill the return type of the method below
        /*void*/ IDatabaseItterator GetRoutesFrom(City from);
        City GetByName(string cityName);
    }
}
