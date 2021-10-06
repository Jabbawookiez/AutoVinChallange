using System;
using System.Collections.Generic;
using System.Text;

namespace AutoVinCode
{
    public class Account
    {
        public string owner { get; set; }
        public int balance { get; set; }
        //Would be better to make this an enum?
        public string accountType { get; set; } //C=Checking | II=Investment Individual | IC = Investment Corporate

        public Account(string _owner, int _balance, string _accountType)
        {
            owner = _owner;
            balance = _balance;
            accountType = _accountType;
        }

        /*
        * Method to withdraw money from an account
        */
        public int withdraw(int amount)
        {

            int currentBalance = this.balance;

            if (amount < 1)
            {
                Console.WriteLine("Please enter a withdrawl amount greather than 0");
                return currentBalance;
            }
            //We only want to withdraw if the amount is less than (or equal to) how much money is in this account
            if (amount <= currentBalance)
            {
                //If it is an individual investment account and they are trying to withdraw more than 500, just return the current balance
                if (this.accountType == "IC" && amount > 500)
                {
                    Console.WriteLine("Individual investments accounts have a max withdrawl of $500");
                    return currentBalance;
                }

                //Otherwise complete the withdraw as normal
                return currentBalance-500;
            }
            else
            {
                Console.WriteLine("Not enough money in account to make a withdraw of: " + amount);
                return currentBalance;
            }
        }

        /*
        * Method for depositing money into an account
        */
        public int deposit(int amount)
        {
            int currentBalance = this.balance;
            //Same check, could be pulled out into it's own method
            if (amount < 1)
            {
                Console.WriteLine("Please enter an amount greather than 0");
                return currentBalance;
            }
            return (currentBalance + amount);
        }

        /*
        * Method to handle transfer from one account to another account
        */
        public int transfer(Account toAccount, int amount)
        {
            //if the withdraw was completed without issue deposit that money into the other account.
            //This assumes a transfer treats the account the money coming out of the same way as a withdraw.
            if (this.withdraw(amount) < this.balance)
            {
                return toAccount.deposit(amount);
            }
            else
            {
                Console.WriteLine("Could not transfer as the transferer either does not have the funds or can not withdraw over $500");
                return toAccount.balance;
            }
        }
    }
}
