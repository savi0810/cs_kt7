using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cs_kt7
{
    internal class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine($"Собака {Name} говорит: Гав!");
        }
    }
}
