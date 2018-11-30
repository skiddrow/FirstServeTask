using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Context
    {
        Dictionary<string, double> vars;

        public Context()
        {
            vars = new Dictionary<string, double>();
        }

        public double GetVar(string name)
        {
            return vars[name];
        }

        public void AddVar(string name, double value)
        {
            if (vars.ContainsKey(name))
            {
                vars[name] = value;
            }
            else
            {
                vars.Add(name, value);
            }
        }
    }
}
