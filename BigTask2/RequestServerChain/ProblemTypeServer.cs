//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigTask2.Api;
using BigTask2.Interfaces;
using BigTask2.Problems;
using BigTask2.Data;

namespace BigTask2.RequestServerChain
{
    class CostServer : AbstractServer
    {
        
        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (NextInChain == null)
                return null;
            if(request.Problem=="Cost")
            {
                IRouteProblem newproblem = new CostProblem(request.From, request.To);
                newproblem.Graph = database;
                return NextInChain.Solve(request, newproblem, database);
            }
            else
            {
                return NextInChain.Solve(request, problem, database);
            }
        }

        public CostServer(IRequestServer s=null) : base(s) { }
    }

    class TimeServer : AbstractServer
    {

        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (NextInChain == null)
                return null;
            if (request.Problem == "Time")
            {
                IRouteProblem newproblem = new TimeProblem(request.From, request.To);
                newproblem.Graph = database;
                return NextInChain.Solve(request, newproblem, database);
            }
            else
            {
                return NextInChain.Solve(request, problem, database);
            }
        }

        public TimeServer(IRequestServer s=null) : base(s) { }
    }
}
