using System;

namespace _3_CUSTOM_EXCEPTION
{
    public class InsufficientFundsException : Exception
    {
        #region --- 01. PROPERTIES ---

        public decimal CurrentBalance { get; }
        public decimal AttemptedWithdrawal { get; }

        #endregion

        #region --- 02. CONSTRUCTOR ---

        public InsufficientFundsException(decimal balance, decimal withdrawal)
        {
            CurrentBalance = balance;
            AttemptedWithdrawal = withdrawal;
        }

        #endregion

        #region --- 03. OVERRIDDEN PROPERTIES ---

        // Overriding the Message property
        //This is the shortest way to write a read-only property.
        public override string Message
            => $"Withdrawal failed. Balance: {CurrentBalance}, Attempted: {AttemptedWithdrawal}";

        // Overriding the HelpLink property
        public override string HelpLink
        {
            get
            {
                return "For more help, visit: https://yourbank.com/support/insufficient-funds";
            }
        }

        #endregion

        #region --- 04. OVERRIDDEN METHODS ---

        public override string ToString()
        {
            return $"[InsufficientFundsException] Balance={CurrentBalance}, Attempted={AttemptedWithdrawal}";
        }

        #endregion
    }
}
