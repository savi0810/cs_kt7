using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_kt7
{
    internal static class AnimalDemo
    {
        public static void ProcessAnimals(List<Animal> animals, Action<Animal> action)
        {
            foreach (var animal in animals)
            {
                action(animal);
            }
        }

        // Контрвариантный метод - принимает базовый тип
        public static void ProcessAsObject(object obj)
        {
            if (obj is Animal animal)
                Console.WriteLine($"Обработка объекта: {animal.Name}");
        }

        // Ковариантный метод - возвращает производный тип
        public static Animal GetCloneWithSuffix(Animal animal, string suffix)
        {
            if (animal is Dog dog)
                return new Dog(dog.Name + suffix);
            else if (animal is Cat cat)
                return new Cat(cat.Name + suffix);
            else
                return null;
        }
    }
}
