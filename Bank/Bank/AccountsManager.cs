using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class AccountsManager//manager kont zawiera funkcje dodawania kont i pobierania listy wszystkich dodanych
    {
        private IList<Account> _accounts; //prywatna lista kont w klasie AccountsManager

        public AccountsManager()
        {
            _accounts = new List<Account>(); // obiekt listy utworzony w konstruktorze
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accounts; //metoda która zwraca wszystkie dodane konta
        }

        private int generateId()
        {
            int id = 1; //zmienna liczbowa do której przypisane jest najniżśze możłiwe ID czyli 1

            if (_accounts.Any()) //Metoda zwraca informację czy w liście istnieje jakakolwiek wartość. W ten sposób można sprawdzić czy lista nie jest pusta. Jęzeli jest to zgodnie z warunkiem następnym zwróconym ID będzie =1.
            {                   // jezeli jakieś konto istnieje to trzeba wyciągnąć najwyżśze ID jakie jest dodane
                id = _accounts.Max(x => x.Id) + 1; //Max zwraca maksymalną wartość liczbową na liście. w nawiasach jest lambda
            }                   // po otrzymaniu wartości wszystkich kont to funkcja Max może na ich podstawie znaleźć wartość maksymalną. Po tym zwiększa się ono o 1 aby dostać kolejną WOLNĄ wartość.

            return id; // na końcu zwraca wygenerowane ID
        }

        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel) //dla każdego w liście sprawdzamy czy zapisane w niej dane wlasciciela pasuja do tych podanych jako parametry metody.
        {
            List<Account> customerAccounts = new List<Account>();

            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.Pesel == pesel)
                {
                    customerAccounts.Add(account);
                }
            }
            return customerAccounts;
        }


        //public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel) 
        //{
        //    return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        //} krotsza wersja powyzszego

        public Account GetAccount(string accountNo)
        {
            return _accounts.Single(x => x.AccountNumber == accountNo); //Single zwraca dokladnie jeden numer z listy _accounts. Sprawdcza czy numery konta się zgadzają
        }

        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        } //Bierzemy liste kont. Uzywamy funkcji Select. JAko parametr przekazujemy funkcje ktora zwraca wartosc na podstawie kazdego obiektu z listy kont. W tym przypadku funkcja zwraca nowy string.
          // Sformatowane jest tak, zeby zawieralo imie, nazwisko ,pesel. Distinct natomiast zwraca wszystkie powtórzenia. Metoda ta zwraca typ IEnumerable<string>

        public void CloseMonth() //metoda sprawdza czy konto pod klasą bazową account to BillingAccount czy SavingsAccount.
        {
            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }

            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }

        public void AddMoney(string accountNo, decimal value) //metoda dla wplaty 
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }

        public void AddAccountToList()
        {
            List<string> CommonList = new List<string>();

            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                CommonList.Add(account.ToString());
            }
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                CommonList.Add(account.ToString());
            }
        }

        public IEnumerable<Account> RemoveAllAccountsFor(string firstName, string lastName, long pesel) //dla każdego w liście sprawdzamy czy zapisane w niej dane wlasciciela pasuja do tych podanych jako parametry metody.
        {
            List<Account> customerAccounts = new List<Account>();

            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.Pesel == pesel)
                {
                    customerAccounts.Remove(account);
                }
            }

            return customerAccounts;

        }
    }
}
