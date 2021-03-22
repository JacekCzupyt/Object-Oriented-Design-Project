//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigTask2.Api;
using BigTask2.Interfaces;
using BigTask2.Data;

namespace BigTask2.RequestServerChain
{
    class RequestValidator : AbstractServer
    {
        public override IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database)
        {
            if (request.From == null || request.From == "" ||
                request.To == null || request.To == "" ||
                request.Filter.MinPopulation < 0 ||
                request.Filter.AllowedVehicles.Count == 0)
                return null;
            if (NextInChain != null)
            {
                return NextInChain.Solve(request, problem, database);
            }
            else
                return null;
        }

        public RequestValidator(IRequestServer s=null) : base(s) { }
    }
}
