using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Interfaces
{
    interface IBasicElement
    {
        int Priority { get; set; }
        Expression Compute();
    }
}
