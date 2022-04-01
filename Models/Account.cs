using bank.Models.enums;

namespace bank.Models
{
    public class Account
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Limit { get; set; }
        public double Balance { get; set;}
        public double Loan { get; set;}

        public TypeAccount Type { get; set;}

        public Account () 
        {

        }

        public Account (int number, string name, double limit, double balance, TypeAccount type) 
        {
            Number = number;
            Name = name;
            Limit = limit;
            Balance = balance;
            Type = type;

        }

        public void WithDram(double value){
            if(value > Balance)
            {
                System.Console.WriteLine("Balance exceded"); 
                return;
            }else if (value > Limit)
            {
                System.Console.WriteLine("Limit exceded"); 
                return;
            }else if (value < 0)
            {
                System.Console.WriteLine("Limit exceded"); 
                return;
            }
            Balance -= value;
        }

        public void Transfer(double value)
        {
            if(value > Balance)
            {
                System.Console.WriteLine("Valor maior que saldo");
                return;
            }else if(value < 0){
                System.Console.WriteLine("Valor invalido");
                return;
            }
            Balance -= value;
        }

        public void Deposit(double value)
        {
            Balance += value;
        }

        public void ALoan(double value){
            Loan = value;
            Balance += value;
        }

        public override string ToString()
        {         
            string loan;

            if(Loan  > 0 )
            {
                loan = $"Valuer of loan is open: {Loan}";
            }else{
                loan = "";
            }

            return 
            "\nNumber of account: " + Number
            + "\nAccount owner: " + Name
            + "\nBalance: " + Balance
            + "\nLimit available withdraw: " + Limit
            + "\nType account: " + Type
            + "\n"+loan;

                
        }

    }

    
}