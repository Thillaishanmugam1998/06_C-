using System;

namespace _4_DIGITAL_WALLET
{
        //Testing Encapsulation Principle
        public class Program
        {
            static void Main(string[] args)
            {
                DigitalWallet myWallet = new DigitalWallet("securePass123");
                myWallet.Deposit(200m);
                bool isWithdrawn = myWallet.Withdraw(50m, "securePass123"); // Outputs: true
                decimal currentBalance = myWallet.CheckBalance("securePass123"); // Outputs: 150

                Console.Read();
            }
        }
 }