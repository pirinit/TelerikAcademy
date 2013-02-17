using System;

class CompanyInfo
{
    static void Main()
    {
        Console.Write("Enter Company's name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter Company's address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter Company's phone number: ");
        string companyPhoneNumber = Console.ReadLine();
        Console.Write("Enter Company's fax number: ");
        string companyFaxNumber = Console.ReadLine();
        Console.Write("Enter Company's web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter Manager's first name : ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter Manager's last name : ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter Manager's age : ");
        string input = Console.ReadLine();
        byte managerAge = Byte.Parse(input);
        Console.Write("Enter Manager's phone number : ");
        string managerPhoneNumber = Console.ReadLine();

        Console.WriteLine("Company name: {0}.", companyName);
        Console.WriteLine("{0}'s address: {1}.", companyName, companyAddress);
        Console.WriteLine("{0}'s phone number: {1}.", companyName, companyPhoneNumber);
        Console.WriteLine("{0}'s fax number: {1}.", companyName, companyFaxNumber);
        Console.WriteLine("{0}'s web site: {1}.", companyName, companyWebSite);
        Console.WriteLine("The manager of {0}: {1} {2}.", companyName, managerFirstName, managerLastName);
        Console.WriteLine("{0} {1} is {2} years old.", managerFirstName, managerLastName, managerAge);
        Console.WriteLine("{0} {1}'s phone number: {2}", managerFirstName, managerLastName, managerPhoneNumber);

    }
}