using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] testArray = { "4", "10", "15", "18", "25", "35","42", "43", "138", "107","111", "122", "123", "124", "127","132" };

            List<string> myList = new List<string>();

            Random random = new Random();
            int index = random.Next(testArray.Length);

            Metody methods = new Metody();

            methods.Run();
            Console.WriteLine($"Liczba pod ktora kryje sie cos co bede robil to: {testArray[index]}");

            Console.ReadKey();

        }


        
    }
}
