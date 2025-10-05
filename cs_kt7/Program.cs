using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal class Program
    {
        private delegate U Convert<in T, out U>(T input);

        static U[] ConvertArray<T, U>(T[] array, Convert<T, U> converter)
        {
            U[] result = new U[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = converter(array[i]);
            }
            return result;
        }

        static void GoConverts()
        {
            Console.WriteLine("=== Демонстрация контрвариантности ===");

            ObjectToStringConverter objConverter = new ObjectToStringConverter();

            string[] stringArray = { "hello", "world", "test" };

            // Контрвариантность: Convert<object, string> присваивается Convert<string, string>
            Convert<string, string> stringConverter = objConverter.Convert;
            string[] result1 = ConvertArray(stringArray, stringConverter);

            Console.WriteLine("Конвертация string[] через ObjectToStringConverter:");
            foreach (var s in result1)
                Console.WriteLine($"'{s}'");

            Console.WriteLine("\n=== Демонстрация ковариантности ===");

            StringToIntConverter intConverter = new StringToIntConverter();

            string[] numberStrings = { "10", "20", "30" };

            // Ковариантность: Convert<string, int> присваивается Convert<string, object>
            Convert<string, object> objectConverter = s => intConverter.Convert(s);
            object[] result2 = ConvertArray(numberStrings, objectConverter);

            Console.WriteLine("Конвертация string[] в object[] через StringToIntConverter:");
            foreach (var obj in result2)
                Console.WriteLine($"{obj} (тип: {obj.GetType()})");

        }

        static void GoAnimals()
        {
            Console.WriteLine("\n=== Демонстрация с Animal ===\n");

            var animals = new List<Animal>
            {
                new Dog("Бобик"),
                new Cat("Мурка"),
                new Dog("Шарик")
            };

            Console.WriteLine("1. Прямой вызов SayHello:");
            AnimalDemo.ProcessAnimals(animals, a => a.SayHello());

            Console.WriteLine("\n2. Контрвариантность - Action<object>:");
            AnimalDemo.ProcessAnimals(animals, AnimalDemo.ProcessAsObject);

            Console.WriteLine("\n3. Контрвариантность - Action<Animal> с методом для object:");
            Action<object> objectAction = AnimalDemo.ProcessAsObject;
            Action<Animal> animalAction = objectAction; 
            AnimalDemo.ProcessAnimals(animals, animalAction);

            Console.WriteLine("\n4. Ковариантность");
            Func<Dog, Dog> cloneDog = (dog) => new Dog(dog.Name + " (клон)");

            Func<Dog, Animal> cloneDogAsAnimal = cloneDog;

            var dogs = new List<Dog> { new Dog("Рекс"), new Dog("Дружок") };

            foreach (var dog in dogs)
            {
                var cloned = cloneDogAsAnimal(dog);
                cloned.SayHello();
            }
        }

        static void GoCalculator()
        {
            Console.WriteLine("\n=== Демонстрация с Calculator ===\n");

            double a = 10.5, b = 2.5;

            Console.WriteLine($"1. Стандартное использование: {a} + {b} = " +
                             CalculatorDemo.Calculate(a, b, Calculator.Add));

            Console.WriteLine($"2. Контрвариантность - Func<string, string, double>:");
            Func<string, string, double> stringFunc = Calculator.AddStrings;
            Func<double, double, double> doubleFunc = (x, y) =>
               stringFunc(x.ToString(), y.ToString());

            Console.WriteLine($"{a} + {b} = {CalculatorDemo.Calculate(a, b, doubleFunc)}");

            Console.WriteLine($"3. Ковариантность - Func<double, double, object>:");
            Func<double, double, object> objectFunc = Calculator.MultiplyAsObject;
            Func<double, double, double> doubleFunc2 = (x, y) => (double)objectFunc(x, y);
            Console.WriteLine($"{a} * {b} = {CalculatorDemo.Calculate(a, b, doubleFunc2)}");
        }


        static void Main(string[] args)
        {
            GoConverts();
            GoAnimals();
            GoCalculator();
        }
    }
}
