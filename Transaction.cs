namespace WestcoastBank;

public class Transaction
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
