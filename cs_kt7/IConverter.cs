using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal interface IConverter<in T, out U>
    {
        U Convert(T input);
    }
}
