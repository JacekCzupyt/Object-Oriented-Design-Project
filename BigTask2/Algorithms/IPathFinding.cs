//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using BigTask2.Api;
using BigTask2.Data;
using System;
using System.Collections.Generic;

namespace BigTask2.Algorithms
{
    interface IPathFinding
    {
        IEnumerable<Route> Solve(IGraphDatabase graph, City from, City to);
    }
}
