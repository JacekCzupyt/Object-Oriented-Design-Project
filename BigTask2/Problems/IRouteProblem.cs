//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


//This file Can be modified

using BigTask2.Data;
using System.Collections.Generic;
using BigTask2.Api;
using BigTask2.Algorithms;

namespace BigTask2.Interfaces
{
    interface IRouteProblem
	{
        IGraphDatabase Graph { get; set; }
        IEnumerable<Route> Solve(IPathFinding algorithm);
	}
}
