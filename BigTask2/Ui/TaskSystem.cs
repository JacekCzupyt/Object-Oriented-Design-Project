//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigTask2.Ui
{
    class TaskSystem : ISystem
    {
        public IForm Form { get; private set; }

        public IDisplay Display { get; private set; }

        public TaskSystem(IForm form, IDisplay display)
        {
            Form = form;
            Display = display;
        }
    }
}
