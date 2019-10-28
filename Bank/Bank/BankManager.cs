using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OknaDoBanku;

namespace Bank
{
    class BankManager
    {
        private AccountsManager _accountsManager; //prywatne zmienne dla managera kont i drukarki
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }
        
        public void Run()
        {
            int action; //najpierw dodana zmienna która wykorzystywana jest do przechowywania wyboru użytkownika aplikacji bankowej
            do
            {
                PrintMainMenu(); // za kazdym razem wykonuje sie wyswietlenie menu
                action = SelectedAction(); // za każdym razem odczytuje wybór użytkownika


                switch (action) //dla kazdej dostepnej akcji robia sie trzy rzeczy: Czysci sie konsola, wyswietla sie informacja o akcji, czekamy az uzytkownik wcisnie klawisz
                { //wartosc dla akcji znajduje sie w zmiennej "action"
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        AddSavingsAccount();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        TakeMoney();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        ListOfAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    case 9:
                        RemoveAccountFor();
                        break;
                    case 10:
                        RemoveAccountFor();
                        break;
                }
            }
            while (action != 0); //sprawdza warunek. Jezeli jest prawdziwy to wraca do slowa do i znowy wykonuje blok kodu. W tym przypadku warunek to sprawdzenie czy wybrana przez usera akcja jest rozna od 0.
        }


        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("9 - Usun konto");
            Console.WriteLine("10 - Usun konto dla");
            Console.WriteLine("0 - Zakończ");
        }

        //public void Run()
        //{
        //    PrintMainMenu(); //printuje powyzsze menu
        //}

        private int SelectedAction() //prywatna metoda do odczytywania numeru akcji która będzie wybierana przez usera
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine(); //zwraca to co user wpisał
            if (string.IsNullOrEmpty(action)) //sprawdza czy wpisany przez uzytkownika tekst nie jest pusty. W takim wypadku zwróci się wartość -1 której nie ma w menu.
            {
                return -1;
            }
            return int.Parse(action); //jezeli cos wpisal- zamienia się tekst na wartość liczbową
        }
        
        private void ListOfAccounts()//wyswietla liste wszystkich kont danego klienta
        { //to co sie dzieje: pobiera dane o kliencie, wyciaga liste wszystkich kont na podstawie danych, drukuje dane każdego konta
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine($"Konta klienta {data.FirstName} {data.LastName} {data.Pesel}: ");

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        private void RemoveAccountFor()
        {
            Form1 oknoDoUsuwania = new Form1();

            Console.WriteLine("Czy chcesz usunac konto?");
            string x = Console.ReadLine();

            if (x == "Tak")
            {
                oknoDoUsuwania.ShowDialog();
            }
            else
            {
                PrintMainMenu();
            }
        }

        private void AddBillingAccount()
        {
            Console.Clear();
            Form1 okno = new Form1();
            Console.WriteLine("Czy chcesz zalozyc konto?");

            string x = Console.ReadLine();
            if (x == "Tak")
            {
                okno.ShowDialog();

            }
            else
            {
                PrintMainMenu();
            }


            //CustomerData data = ReadCustomerData();
            //Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);
            //var value = billingAccount;

            //Console.WriteLine("Utworzono konto rozliczeniowe");
            //_accountsManager.AddAccountToList();
            //_printer.Print(billingAccount);



            Console.ReadKey();

        }

        private void AddSavingsAccount()
        {
            Console.Clear();
            Form1 okno = new Form1();
            Console.WriteLine("Czy chcesz zalozyc konto?");

            string x = Console.ReadLine();
            if (x == "Tak")
            {
                okno.ShowDialog();

            }
            else
            {
                PrintMainMenu();
            }


            //CustomerData data = ReadCustomerData();
            //Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);

            //Console.WriteLine("Utworzono konto oszczednosciowe");
            ////_printer.Print(savingsAccount);
            //_accountsManager.AddAccountToList();
            //Console.ReadKey();
        }

        private void AddMoney() 
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Wplata pieniedzy");
            Console.Write("Numer konta: "); //pobranie numeru konta
            accountNo = Console.ReadLine();
            Console.Write("Kwota: "); //pobranie kwoty jaka ma byc wplacona
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value); //przekazanie podanej kwoty na konto

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);  // Pobieramy obiekt tego konta i wyświetlamy informacje o nim, aby być pewnym, że zmieniło się saldo na nim
            
            Console.ReadKey();
        }

        private void TakeMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Wyplata pieniedzy");
            Console.Write("Numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();

        }

        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów: ");
            foreach (string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();

        }

        private void ListOfAllAccounts() //zwraca wszystkie konta z managera kont
        {
            Form2 listaKont = new Form2();
            listaKont.ShowDialog();
        }

        private void CloseMonth() //zamyka miesiac. Wykonuje funkcje z managera kont i informuje o tym fakcie uzytkownika
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }


        private CustomerData ReadCustomerData() //zebranie danych o kliencie
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();


            return new CustomerData(firstName, lastName, pesel);
        }

    }



    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel); //zamiana tekstu na pesel zrobiona w konstruktorze
        }
    }
}
