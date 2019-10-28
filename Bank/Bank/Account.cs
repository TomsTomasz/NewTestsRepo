using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Account // z obu klas przenioslem elementy wspolne
    {
        //public int Number { get; set; }
        public int Id { get; } //zmiany jak ponizej sprawiaja, ze setter skoro jest prywatny nie trzeba go deklarowac.
        public string AccountNumber { get; } //Dodatkowo dla kazdej wartosci można ją odczytać poza klasą (getter). 
        public decimal Balance { get; protected set; } //Jednocześnie każda modyfikacja jest możliwa tylko wewnątrz klasy
        public string FirstName { get; } //skoro getter jest publiczny to nalezy go zadeklarowac
        public string LastName { get; } // tak wiec zmienne sa prywatne ale mozna je wyciagac getterem za klasę
        public long Pesel { get; }

        public Account(int id, string firstName, string lastName, long pesel) //funkcja przrzuca wartosci z jednej zmiennej do drugiej
        {
            //Number = number;
            Id = id;
            AccountNumber = generateAccountNumber(id); //metoda ponizej zwroci format konta
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }   //zadeklarowano konstruktor. Konstruktor jest to taki specjalny rodzaj metody, przy której nie podajemy zwracanego typu i która ma taką samą nazwę jak nazwa klasy. 
            //Jest on używany właśnie podczas tworzenia/konstruowania obiektu, co sugeruje już sama nazwa.
            //po sformatowaniu zostaje tylko uzupełnienie wartości zmiennych poprzez konstruktor

        public abstract string TypeName();

        public string GetFullName() //nie przyjmuje zadnych parametrow bo korzysta sie z danych znajdujacych sie w obiekcie
        {
                string fullName = string.Format("{0} {1}", FirstName, LastName);

                return fullName;
        }

        public string GetBalance()
        {
            return string.Format("{0}zł", Balance);
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

        private string generateAccountNumber(int id)
        {
            var accountNumber = string.Format("94{0:D10}", id); 

            return accountNumber;
        }

        //public int GetNumber(int number)
        //{
        //    int number = number + 1;

        //    return number;
        //}
    }
}
