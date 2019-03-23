using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public interface ICalculator
    {
        int Calculate(string expression);
    }
}
