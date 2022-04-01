using bank.Models;
using bank.Interfaces;
using bank.Models.enums;
using System.Collections.Generic;


namespace bank.Controller
{
    public class AccountControllers : IRepositories<Account>
    {
        public Account _account;
        public List<Account> List = new List<Account>();
 
        public AccountControllers (Account account)
        {          
            _account = account;
           
        }

        public AccountControllers ()
        {
        }

        public void Insert (Account register){
            List.Add(register);
        }

        public string Remove (int number){
            var found = List.Find(x => x.Number == number);
            List.Remove(found);
            if(found == null)
            {
                return "\nAccount not found";
            }
            return "\nSuccess!";
        }

        public Account Find(int number){
            var retorno = List.Find(x => x.Number == number);   
            return retorno;
        }

        public void WithDram (double value, int number) {
            var transfer = List.Find(x => x.Number == number);
            transfer.WithDram(value);
        }

        public void Deposit (double value, int number) {
            var transfer = List.Find(x => x.Number == number);
            transfer.Deposit(value);
        }

        public void ALoan (double value, int number) {
            var transfer = List.Find(x => x.Number == number);
            transfer.ALoan(value);
        }

        public void SetType() {
            if(_account.Type == TypeAccount.Business)
            {
                _account.Limit = 5000;

            }else if(_account.Type == TypeAccount.University)
            {
                _account.Limit = 1200;

            }else
            {
                _account.Limit = 600;
            }
        }

        public void Transfer(double value, int number, int numberacc) 
        {
            var myacc = List.Find(x => x.Number == number);
            myacc.Transfer(value);
            var transfer = List.Find(x => x.Number == numberacc);
            transfer.Deposit(value);

        }


    }
}