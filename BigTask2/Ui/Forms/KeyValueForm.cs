//I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//Jacek Czupyt


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigTask2.Ui
{
    class KeyValueForm : AbstractForm
    {
        static string pattern { get { return @"([^=]+)=(.+)"; } }

        public override void Insert(string command)
        {
            foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(command, pattern))
            {
                Values[m.Groups[1].Value] = m.Groups[2].Value;
            }
        }
    }
}
