using System;
using System.Collections.Generic;
using System.Text;

namespace _1_BANKING_APPLICATION
{
    public class BankAccount
    {
        // This private field is encapsulated and can't be directly accessed from outside the class.
        private decimal Balance;

        // Only provides a way to read the balance but not modify it directly.
        public decimal balance
        {
            get
            {
                return Balance;
            }
        }

        public BankAccount(decimal initialAmount)
        {
            if(initialAmount < 0)
            {
                throw new ArgumentException("Initial balance cannot be Negative");
            }

            Balance = initialAmount;
        }

        public void checkBalance()
        {
            Console.WriteLine("Balance: " + balance);
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount should be positive.");
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount should be positive.");
            }
            if (balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }
    }
}

