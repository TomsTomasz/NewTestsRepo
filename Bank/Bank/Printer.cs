using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Printer : IPrinter
    {
        public void Print(Account account) //w nawiasie parametry funkcji. Po wywolaniu tej funckji dojdzie do wyprintowania 
        {
            Console.WriteLine("Dane konta: {0}", account.AccountNumber);
            Console.WriteLine("Typ: {0}", account.TypeName());
            Console.WriteLine("Saldo: {0}zł", account.Balance);
            Console.WriteLine("Imię właścicela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine("PESEL właściciela: {0}", account.Pesel);
            Console.WriteLine("Identyfikator konta to: {0}", account.Id);
            Console.WriteLine();
        }
    }
}
