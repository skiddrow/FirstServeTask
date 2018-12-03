using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Context
    {
        Dictionary<string, double> Vars;

        public Context()
        {
            Vars = new Dictionary<string, double>();
        }

        public double GetVar(string name)
        {
            return Vars[name];
        }

        public void AddVar(string name, double value)
        {
            if (Vars.ContainsKey(name))
            {
                Vars[name] = value;
            }
            else
            {
                Vars.Add(name, value);
            }
        }
    }
}
