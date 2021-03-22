//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.Interfaces;
using BigTask2.Algorithms;

namespace BigTask2.RequestServerChain
{
    class BFSServer : AbstractServer
    {
        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (problem == null)
                return null;
            if(request.Solver=="BFS")
            {
                return problem.Solve(new BFS());
            }
            else
            {
                if (NextInChain == null)
                {
                    return null;
                }
                else
                {
                    return NextInChain.Solve(request, problem, database);
                }
            }
        }

        public BFSServer(IRequestServer s=null) : base(s) { }
    }

    class DFSServer : AbstractServer
    {
        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (problem == null)
                return null;
            if (request.Solver == "DFS")
            {
                return problem.Solve(new DFS());
            }
            else
            {
                if (NextInChain == null)
                {
                    return null;
                }
                else
                {
                    return NextInChain.Solve(request, problem, database);
                }
            }
        }

        public DFSServer(IRequestServer s=null) : base(s) { }
    }

    class DijkstraServer : AbstractServer
    {
        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (problem == null)
                return null;
            if (request.Solver == "Dijkstra")
            {
                if (request.Problem == "Cost")
                {
                    return problem.Solve(new DijkstraCost());
                }
                else
                    return problem.Solve(new DijkstraTime());
               
            }
            else
            {
                if (NextInChain == null)
                {
                    return null;
                }
                else
                {
                    return NextInChain.Solve(request, problem, database);
                }
            }
        }

        public DijkstraServer(IRequestServer s=null) : base(s) { }
    }
}
