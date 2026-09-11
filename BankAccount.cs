namespace WestcoastBank;
enum TransactionTypeEnum
{
    Insättning,
    Uttag
}
class Account(string accountNo)
{
    //const string DEPOSIT = "Insättning";
    //const string WITHDRAW = "Uttag";

    //Autoimplemented properties

    /*
    public int BalancewithInterest
    {
        get {return Balance + (int)(100*0.25); }
    }
    */

    public int Balance {get;private set;}
    public string AccountNumber {get;} = accountNo;
    public string FirstName {get; set;} = "";
    public string? LastTime {get; set;} 
    public List<Transaction> Transactions {get;} = [];

/*
    private int balance;
    //private int _balance;

    private readonly string accountNumber; //= ""; to avoid non Null error
    private string? firstName; //public string firstName = ""; //public required string firstName; 
    private string? lastName;
    private List<Transaction> transactions = [];

   public string AccountNumber
    {
        get { return accountNumber; }
    }

   public int Balance
    {
        get { return balance; }
    }

    public string FirstName
    {
        get { return firstName ?? ""; }
        set { firstName = value; }
    }

    public string LastName
    {
       get { return lastName ?? ""; }
       set { lastName = value; }
    }

    public List<Transaction> Transactions
    {
        get { return transactions; }
    }

    // public Account()
    // {   accountNumber = "";
    //     firstName = "";
    //     lastName = "";
    // }

*/

    //when we set something as Readonly then we can initialize its value only by this constructor
    //public Account(string accountNo)
    //{
    //    AccountNumber = accountNo;
    //}

    // public Account(string accountNo, string firstName, string lastName)
    // {
    //     accountNumber = accountNo;
    //     this.firstName = firstName;
    //     this.lastName = lastName;
    // }

    public void Deposit(int amount)
    {
        Balance += amount;
        //AddTransaction(amount, DEPOSIT);
        AddTransaction(amount, TransactionTypeEnum.Insättning);
    }

    public void WithDraw(int amount)
    {
        if (Balance < amount)
        {
            throw new Exception($"Du har inte tillräckligt på kontot. Balance: {Balance}");
        }
        Balance -= amount;

        //AddTransaction(amount, WITHDRAW);
        AddTransaction(amount, TransactionTypeEnum.Uttag);
    }

    //public int GetBalance()
    //{
    //    return balance;
    //}

    // void AddTransaction(int amount, TransactionTypeEnum type)
    // {
    //     var tran = new Transaction();
    //     tran.transactionDate = DateTime.Now;
    //     tran.transactionType = type;
    //     tran.transactionAmount = amount;
    //     transactions.Add(tran);
    // }
    private void AddTransaction(int amount, TransactionTypeEnum type)
    {
        // Object initiering version 1
        Transaction tran = new()
        {
            //transactionDate = DateTime.Now,
            TransactionType = type,
            TransactionAmount = amount
        };

        // Object initiering version 2
        // var tran = new Transaction
        // {
        //     transactionDate = DateTime.Now.AddDays(20),
        //     transactionType = type,
        //     transactionAmount = amount
        // };
        Transactions.Add(tran);
    }

}
class Transaction
{
    public DateTime TransactionDate {get;} = DateTime.Now;
    public TransactionTypeEnum TransactionType {get; set;}
    public int TransactionAmount {get; set;}

    /*
    public DateTime transactionDate;
    public TransactionTypeEnum transactionType;
    public int transactionAmount;
    */

    public override string ToString()
    {
        return $"Transaktionsdatum: {TransactionDate} Transaktionstyp: {TransactionType} Belopp: {TransactionAmount}";
    }
    //public string GetTransactionInfo()
    //{
    //    return $"Transaktionsdatum: {TransactionDate} Transaktionstyp: {TransactionType} Belopp: {TransactionAmount}";
    //}
}
