using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Parser
    {
        //Context context;
        delegate double Calculate();

        public void ParseStringAndCompute(string parsingString)
        {
            ArrayList values = new ArrayList();
            ArrayList sings = new ArrayList();
            char symbol;
            string currentValue = "";

            //parsingString.Replace(" ", "");

            for (int i = 0; i < parsingString.Length; i++)
            {
                symbol = parsingString[i];

                if (symbol != '+' && symbol != '-' && symbol != '*' && symbol != '/')
                {
                    currentValue += symbol;
                }
                else
                {
                    values.Add(currentValue);
                    currentValue = "";
                    sings.Add(symbol);
                }

                symbol = parsingString[i];
            }

            values.Add(currentValue);

            for (int i = 0; i < sings.Count; i++)
            {
                if (sings[i] == "*")
                {
                    
                }

                if (sings[i] == "/")
                {
                    
                }
            }
        }
    }
}
