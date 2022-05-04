using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Utilities
{
    public static class MathUtilities
    {
        public static dynamic AddFactors(dynamic factorsFirst, dynamic factorsSecond)
        {
            var index = 0;
            var result = factorsFirst;
            foreach (var factor in factorsSecond)
            {
                result[index] += factor;
                ++index;
            }

            return result;
        }
    }
}
