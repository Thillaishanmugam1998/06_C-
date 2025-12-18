using System;
using System.Threading;

namespace ThreadDemo
{
    public class ATMOperations
    {
        #region THREAD-1 : Read Card (Fast)
        public void ReadCard()
        {
            Console.WriteLine("Card Read Successful");
            Thread.Sleep(1000);
        }
        #endregion

        #region THREAD-2 : Fetch Balance (SLOW & IMPORTANT)
        public void FetchBalance()
        {
            Console.WriteLine("Fetching Account Balance...");
            Thread.Sleep(5000); // Bank server delay

            BankData.AccountBalance = 5000;

            Console.WriteLine("Balance Fetched Successfully");
        }
        #endregion

        #region THREAD-3 : Print Receipt
        public void PrintReceipt()
        {
            Console.WriteLine("Printing Receipt...");
            Thread.Sleep(1000);
        }
        #endregion

        #region DEPENDENT WORK
        public void DispenseCash()
        {
            Console.WriteLine("Trying to Dispense Cash...");

            if (BankData.AccountBalance >= 2000)
                Console.WriteLine("Cash Dispensed ✅");
            else
                Console.WriteLine("Transaction Failed ❌ (Insufficient Balance)");
        }
        #endregion
    }
}
