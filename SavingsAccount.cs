namespace WestcoastBank;

public class SavingsAccount (string accountNo, string fName, string lName): 
    Account (accountNo, fName, lName)
{
    /* Det gamla sättet att överföra information till basklassen(Account)...
    public SavingsAccount(string accountNo) : base(accountNo)
    {}*/

    const double INTEREST_RATE = 0.05;
    public override int Balance => 
        Convert.ToInt32(base.Balance * (1 + INTEREST_RATE));

    // public override int Balance
    // {
    //      get 
    //      {
    //          return base.Balance + 100;
    //      }

    // }

    // public double _interestRate;
    public double InterestRate { get; set; }

    // public void SetinterestRate(double value)
    // {
    //     _interestRate = value;
    // }

    // public double GetInterestRate()
    // {
    //     return _interestRate;
    // }

    public void CalculateInterest() {}

    public override void Deposit(int amount)
    {
        base.Balance += amount;
        AddTransaction(amount, TransactionTypeEnum.Insättning);
    }
}
