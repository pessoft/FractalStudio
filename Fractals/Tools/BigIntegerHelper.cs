using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Fractals.Tools
{
    public static class BigIntegerHelper
    {
        public static BigInteger Factorial(this BigInteger sourse)
        {
            BigInteger fc = 1;
            for (int i = 2; i <= sourse; ++i)
            {
                fc *= i;
            }
            return fc;
        }
    }
}
