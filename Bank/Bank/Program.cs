using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Drawing;


namespace Bank
{
    class Program
    {


        static void Main(string[] args)
        {


                //AccountsManager manager = new AccountsManager(); // stworozny obiekt managera. Dzieki niemu mozna dodawac nowe konta w programie

                //manager.CreateBillingAccount("Marek", "Zajac", 1234567890);
                //manager.CreateSavingsAccount("Marek", "Zajac", 1234567890);
                //manager.CreateSavingsAccount("Aaaaa", "Bbbbb", 0987654321);

                //IEnumerable<Account> accounts = manager.GetAllAccounts();

                //IEnumerable<string> users = manager.ListOfCustomers();

                //foreach (string user in users)
                //{
                //    Console.WriteLine(user);
                //}

            BankManager bankManager = new BankManager();
            bankManager.Run(); //wlaczajac aplikacje zobaczymy menu. 


            //List<Account> accounts = new List<Account>(); //lista przechowujaca konta. Oba typy kont dziedzica po klasie Account

            //accounts.Add(new SavingsAccount(1, "940000000001", 0.0M, "Marek", "Zajac", 1234567890));
            //accounts.Add(new SavingsAccount(2, "950000000001", 0.0M, "Tomasz", "Ostrowski", 123456789));
            //accounts.Add(new SavingsAccount(3, "960000000001", 0.0M, "Zzzz", "Bbb", 0987654321));
            //accounts.Add(new BillingAccount(4, "970000000001", 0.0M, "Marek", "Zajac", 1234567890));
            //accounts.Add(new BillingAccount(5, "980000000001", 0.0M, "Marek", "Aaaa", 1234554321));

            //SavingsAccount savingsAccount = new SavingsAccount(3, "940000000001", 0.0M, "Marek", "Zajac", 92010133333);   //tworzy nowe konto, Definiujemy zmienną o nazwie savingsAccount, która jest typu SavingsAccount, co oznacza, że będzie mogła przechowywać obiekty tego typu.
            //SavingsAccount savingsAccount1 = new SavingsAccount(4, "950000000001", 0.0M, "Tomasz", "Ostrowski", 92032610377);  //Tworzymy nowy obiekt klasy SavingsAccount.To jest nowość, o której za moment.
            //BillingAccount billingAccount = new BillingAccount(5, "960000000001", 0.0M, "Martyna", "Klis", 93030499881);   //Przypisujemy utworzony obiekt do naszej zmiennej, a więc chowamy go od pudełka podpisanego jako savingsAccount.

            //account = new SavingsAccount(2, "940000000001", 0.0M, "Marek", "Zajac", 92010133333);
            //Console.WriteLine(account.TypeName());
            //account = new BillingAccount(1,"960000000001", 0.0M, "Martyna", "Klis", 93030499881);
            //Console.WriteLine(account.TypeName());

            //IList<int> lista = new List<int>();
            //IEnumerable<int> lista2 = new List<int>(); //przypisanie listy do interfejsów

            //savingsAccount.Init("940000000001", 0.0M, "Marek", "Zajac", 92010133333); //pierwsze konto wypelnione danymi. Dostaje sie tam przez savingsAccount.Nazwa zmiennej
            // savingsAccount1.Init("950000000001", 0.0M, "Tomasz", "Ostrowski", 92032610377);
            //billingAccount.Init("960000000001", 0.0M, "Martyna", "Klis", 93030499881)

            //IPrinter printer = new Printer(); interfejs <
            //printer.Print(savingsAccount); //najpierw nazwa zmiennej w jakiej znajduje sie obiekt, potem kropke i na koncu nazwe funkcji
            //printer.Print(savingsAccount1);

            //printer.Print(billingAccount);

            Printer printer = new Printer();

            //SmallerPrinter smallerPrinter = new SmallerPrinter();
            //smallerPrinter.Print(billingAccount);
            //smallerPrinter.Print(savingsAccount);

            //string fullName = savingsAccount.GetFullName(); //odwolanie do savingsaccount.getfullname
            //string balance = savingsAccount.GetBalance();
            //Console.WriteLine("Pierwsze konto w systemie dostał: {0}", fullName); //odowłanie do fullname
            //Console.WriteLine("Balans konta tej osoby to {0}", balance);
            //string fullName2 = billingAccount.GetFullName();
            //string balance2 = billingAccount.GetBalance();
            //Console.WriteLine("Drugie konto w systmie dostał: {0}", fullName2);
            //Console.WriteLine("Balans konta tej osoby to: {0}", balance);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
