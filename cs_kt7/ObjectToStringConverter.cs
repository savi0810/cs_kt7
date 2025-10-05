using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal class ObjectToStringConverter : IConverter<object, string>
    {
        public string Convert(object value)
        {
            return value?.ToString() ?? "null";
        }
    }
}
