using System;
using System.Collections.Generic;
using System.Text;

namespace _3_CUSTOM_EXCEPTION
{
    public class BankAccount
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string holder, decimal startingBalance)
        {
            AccountHolder = holder;
            Balance = startingBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException(Balance, amount);
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. New Balance: {Balance}");
        }
    }
}