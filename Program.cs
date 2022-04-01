using System;
using bank.Models.enums;
using bank.Models;
using bank.Controller;

AccountControllers ac = new AccountControllers();

int number;

var rdm = new Random();


Menu();


void Menu () {

    System.Console.WriteLine("\nWelcome to BankSky!");
    System.Console.WriteLine("------------------------------");
    System.Console.Write("What do you want?: ");
    System.Console.WriteLine("\n[0] Register");
    System.Console.WriteLine("[1] Login");
    System.Console.WriteLine("[2] Delete Account");
    System.Console.WriteLine("[3] Exit");

    int option = int.Parse(Console.ReadLine());

    if(option == 0)
    {
        SubMenuRegister();
    }else if(option == 1){
        SubMenuLogin();
    }else if(option == 2){
        SubMenuRemove();
    }else if(option == 3){
        System.Console.WriteLine("Thanks for prefer our bank!!");
        return;
    }else
    {
        System.Console.WriteLine("Invalid option");
        Menu();
    }

}

void SubMenuRegister()
{
    System.Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        System.Console.WriteLine("Enter the type of account you want: ");
        System.Console.WriteLine("[0] University: ");
        System.Console.WriteLine("[1] Business: ");
        System.Console.WriteLine("[2] Savings: ");
        int typeAccount = int.Parse(Console.ReadLine());
        
        TypeAccount type = new TypeAccount();
        if(typeAccount == 0){
            type = TypeAccount.University;
        }else if(typeAccount == 1){
            type = TypeAccount.Business;
        }else if(typeAccount == 2){
            type = TypeAccount.Saving;
        }
        number = rdm.Next(1000, 9999);
        Account acc = new Account(number, name, 0.0, 0.0, type);
        ac._account = acc;
        ac.SetType();
     
        ac.Insert(acc);
        
        System.Console.WriteLine("Registration created successfully!");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Your informations: ");
        System.Console.WriteLine("--------------------------------\n");
        System.Console.WriteLine(acc);
        System.Console.WriteLine("--------------------------------\n");
        System.Console.WriteLine("Do you want deposit initial? [Y/N] : ");
        char initial = char.Parse(Console.ReadLine().ToUpper());

        if(initial == 'Y'){
            System.Console.WriteLine("Enter value deposit:");
            acc.Deposit(double.Parse(Console.ReadLine()));
            System.Console.WriteLine(ac.Find(number)); 
            System.Console.WriteLine("Sucess! Redirection for initial menu..");
            Menu();
            
        }else
        {
            System.Console.WriteLine("Redirection for initial menu! ");
        }      
}

void SubMenuLogin()
{
    System.Console.WriteLine("Enter your number account: ");
    number = int.Parse(Console.ReadLine());
    var verify = ac.Find(number);
    System.Console.WriteLine(verify);
    Login(verify);

}

void Login(Account verify)
{
    if(verify is Account)
    {
        System.Console.WriteLine("\nWhat do you want?");
        System.Console.WriteLine("--------------------------------\n");
        System.Console.WriteLine("[0] Informations of account");
        System.Console.WriteLine("[1] Withdraw");
        System.Console.WriteLine("[2] Deposit");
        System.Console.WriteLine("[3] Loan");
        System.Console.WriteLine("[4] Transfer");
        System.Console.WriteLine("[5] Return menu");
        int optionUser = int.Parse(Console.ReadLine());
        
        if(optionUser == 0){
            System.Console.WriteLine(ac.Find(number));
            Login(verify);
        }else if(optionUser == 1){
            System.Console.Write("Enter value do you want withdraw: ");              
            ac.WithDram(double.Parse(Console.ReadLine()), number);
            System.Console.WriteLine("Success!");
            System.Console.WriteLine("--------------------------------\n");
            System.Console.WriteLine("Account update");
            System.Console.WriteLine(ac.Find(number)); 
            Login(verify);
        }else if(optionUser == 2){
            System.Console.Write("Enter value do you want deposit: ");
            ac.Deposit(double.Parse(Console.ReadLine()), number);
            System.Console.WriteLine("Success!");
            System.Console.WriteLine("--------------------------------\n");
            System.Console.WriteLine("Account update");   
            System.Console.WriteLine(ac.Find(number)); 
            Login(verify);
        }else if(optionUser == 3){
            System.Console.Write("Enter value do you want get loan: ");
            ac.ALoan(double.Parse(Console.ReadLine()), number);
            System.Console.WriteLine("Success!");
            System.Console.WriteLine("--------------------------------\n");
            System.Console.WriteLine("Account update");
            System.Console.WriteLine(ac.Find(number)); 
            Login(verify);
        }else if(optionUser == 4){
            System.Console.Write("Enter value do you want transfer: ");
            double val =  double.Parse(Console.ReadLine());
            System.Console.Write("Enter account do you want transfer: ");
            int numberacc =  int.Parse(Console.ReadLine());
            ac.Transfer(val, number, numberacc);
            System.Console.WriteLine("Success!");
            System.Console.WriteLine("--------------------------------\n");
            System.Console.WriteLine("Account update");
            System.Console.WriteLine(ac.Find(number));
            Login(verify);
        }else if(optionUser == 5)
        {
            Menu();
        }else
        {
            System.Console.WriteLine("Invalid option");
            Login(verify);
            
        }
    }else
    {
        System.Console.WriteLine("Account not found! ");
        Menu();
    }
}

void SubMenuRemove()
{
    System.Console.WriteLine("Enter your number account which you want remove: ");
    number = int.Parse(Console.ReadLine());
    System.Console.WriteLine(ac.Remove(number)); 
    Menu();
}

