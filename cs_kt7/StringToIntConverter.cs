using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal class StringToIntConverter : IConverter<string, int>
    {
        public int Convert(string value)
        {
            if (int.TryParse(value, out int result))
                return result;
            throw new FormatException($"Невозможно преобразовать '{value}' в число.");
        }
    }
}
