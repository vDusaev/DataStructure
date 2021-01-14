using System;
using Structure;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linked dictionary:");

            var dictionary = new LinkedDictionary<int, string>();
            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");
            dictionary.Add(101, "One hundred one");

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nRemove 1, 101, 5: ");
            dictionary.Remove(1);
            dictionary.Remove(101);
            dictionary.Remove(5);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nSearch 2: {dictionary.Search(2)}");
        }
    }
}
