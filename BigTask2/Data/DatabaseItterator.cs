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
    public interface IDatabaseItterator
    {
        bool Next();
        Route Current { get; }
    }
}
