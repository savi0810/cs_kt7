using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine($"Кошка {Name} говорит: Мяу!");
        }
    }
}
