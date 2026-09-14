using WestcoastBank;

using System.Net;

namespace ATM;

class Program
{
    //static Account account = new Account("1234-5678");
    //static List<Transaction> transactions = [];

    //static Account account = new() {accountNumber = "1234-5678"};
    //static Account account = new("1234-5678", "Eva", "Nilsson") {};
    static Account account_1 = new("1111-5678", "Eva", "Nilsson") {};
    static SavingsAccount account_2 = new("1111-5678", "Eva", "Nilsson") {};
    static List<Account> accounts = [];

    //static SavingsAccount account = new("1111-5678") {};

    static void Main()
    {
        /*we cannot set readonly field value here in main as below
         string accountNumber = "1111";
         string accountNo = account.accountNumber; //but this is possible */

        //account.FirstName = "Michael";
        accounts.Add(account_1);
        accounts.Add(account_2);

        // Här är vår enkla meny...
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("För att sätta in tryck på tangenten 'd'");
        Console.WriteLine("För att ta ut tryck på tangenten 'w'");
        Console.WriteLine("För att se saldo tryck på tangenten 'b'");
        Console.WriteLine("För att se transaktionerna tryck på tangenten 't'");
        Console.WriteLine("För att se kontouppgifter tryck på tangenten 'k'");
        Console.WriteLine("För att avsluta tryck på tangenten 'x'");
        Console.WriteLine("--------------------------------------------------");

        App();
    }

    static void App()
    {
        try
        {
            while (true)
            {
                var key = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(key) || key == "x")
                {
                    Environment.Exit(0);
                }

                switch (key)
                {
                    case "b":
                        DisplayBalance();
                        break;
                    case "t":
                        DisplayTransactions();
                        break;
                    case "k":
                        DisplayAccounts();
                        break;
                    case "d":
                        Console.WriteLine("Hur mycket vill du sätta in?");
                        var amount = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(amount))
                        {
                            throw new Exception("Du måste ange ett heltalsvärde");
                        }

                        if (!int.TryParse(amount, out int result))
                        {
                            throw new Exception("Du måste ange ett heltalsvärde för att jag ska kunna förstå!");
                        }
                        Deposit(result);
                        break;
                    case "w":
                        Console.WriteLine("Hur mycket vill du ta ut?");
                        amount = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(amount))
                        {
                            throw new Exception("Du måste ange ett heltalsvärde");
                        }

                        if (!int.TryParse(amount, out int value))
                        {
                            throw new Exception("Du måste ange ett heltalsvärde för att jag ska kunna förstå!");
                        }
                        WithDraw(value);
                        break;
                    case "x":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ditt val finns inte i menyn");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            App();
        }
        finally
        {
            Console.WriteLine("Klar för idag, nu är det fredag!");
        }
    }

    static void Deposit(int amount) // Header - Definition
    { // Body...
        account_1.Deposit(amount); //accounts reference
        account_2.Deposit(amount); //savings account reference
        //AddTransaction(amount, "Insättning");
    }

    static void WithDraw(int amount)
    {
        account_1.WithDraw(amount);
        //AddTransaction(amount, "Uttag");
        //throw new Exception($"Du har endast {account.balance} - räcker inte för att ta ut {amount}");
    }
    static void DisplayBalance()
    {
        var b = account_1.Balance;
        //Console.WriteLine($"Ditt nuvarande saldo: {account.GetBalance()}");
        Console.WriteLine($"Ditt nuvarande saldo: {account_1.Balance}");
    }

    static void DisplayTransactions()
    {
        foreach (var tran in account_1.Transactions)
        {
            //Console.WriteLine(tran.GetTransactionInfo());
            Console.WriteLine(tran.ToString());
        }
        foreach (var tran in account_2.Transactions)
        {
            Console.WriteLine(tran.ToString());
        }
    }

    static void DisplayAccounts()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach(var account in accounts)
        {
            Console.WriteLine(account.Balance);
        }
        Console.ResetColor();
    }
    /* static void AddTransaction(int amount, string trxType)
    {
        var tran = new Transaction();
        tran.transactionDate = DateTime.Now;
        tran.transactionType = trxType;
        tran.transactionAmount = amount;
        transactions.Add(tran);
    } */
}