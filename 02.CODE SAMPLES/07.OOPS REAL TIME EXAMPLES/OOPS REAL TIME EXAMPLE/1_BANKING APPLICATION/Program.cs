using System;

namespace _1_BANKING_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region EXPLANATION 
                /* 
                   Encapsulation means keeping the data (fields) private 
                   and exposing it to the outside world only through 
                   controlled methods or properties.

                   It protects the data, prevents direct modification, 
                   and allows validation before updating the values.
                */

                #endregion

                BankAccount thillai = new BankAccount(0);

               // thillai.balance = 1000000; // This would be an error, as the balance field is private and inaccessible directly.
                thillai.checkBalance();
                thillai.Deposit(1000);
                thillai.Withdraw(500);
                thillai.checkBalance();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
