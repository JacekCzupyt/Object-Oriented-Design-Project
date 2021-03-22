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
    interface IRequestServer
    {
        IEnumerable<Route> Solve(Request request, Interfaces.IRouteProblem problem, IGraphDatabase database);
        void SetNextInChain(IRequestServer server);
    }

    abstract class AbstractServer : IRequestServer
    {
        protected IRequestServer NextInChain = null;

        public abstract IEnumerable<Route> Solve(Request request, IRouteProblem problem, IGraphDatabase database);

        public void SetNextInChain(IRequestServer server)
        {
            if (NextInChain == null)
                NextInChain = server;
            else
                NextInChain.SetNextInChain(server);
        }

        public AbstractServer(IRequestServer server=null)
        {
            SetNextInChain(server);
        }
    }
}
