namespace WestcoastBank;

public class Customer
{
    public required string FirstName {get; set;}
    public required string LastName {get; set;} 

    public string? Email {get; set;}
    public string? Phone {get; set;}

    //Address? PermanentAddress; 
    //Address? CommunicationAddress;
    List<Address>? Addresses {get; set;}
}
