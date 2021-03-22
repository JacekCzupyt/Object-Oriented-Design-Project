//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


//This file Can be modified

using System.Collections.Generic;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.Interfaces;
using BigTask2.Algorithms;

namespace BigTask2.Problems
{
	class CostProblem : IRouteProblem
	{
		public string From, To;
		public CostProblem(string from, string to)
		{
			From = from;
			To = to;
		}

        public IGraphDatabase Graph { get; set; }

        public IEnumerable<Route> Solve(IPathFinding algorithm)
        {
            return algorithm.Solve(Graph, Graph.GetByName(From), Graph.GetByName(To));
        }
    }
}
