//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigTask2.Ui
{
    abstract class AbstractForm : IForm
    {
        protected Dictionary<string, string> Values = new Dictionary<string, string>();

        public bool GetBoolValue(string name)
        {
            if (Values[name] == "True")
                return true;
            if (Values[name] == "False")
                return false;
            throw new ArgumentException();
        }

        public int GetNumericValue(string name)
        {
            int res;
            if (!Int32.TryParse(Values[name], out res))
                throw new ArgumentException();
            return res;
        }

        public string GetTextValue(string name)
        {
            return Values[name];
        }

        public abstract void Insert(string command);
    }
}
