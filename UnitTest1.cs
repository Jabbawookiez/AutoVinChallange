using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoVinCode;
using System.Collections.Generic;

namespace AutoVinTest
{
    [TestClass]
    public class UnitTest1
    {
        //Initializing a bank object and it's accounts to test on.
        Bank bank = new Bank("First Trust Bank", new List<Account>());
        Account testAccount1 = new Account("John", 600, "C");
        Account testAccount2 = new Account("Sam", 100, "II");
        Account testAccount3 = new Account("Joe", 18000, "IC");
        Account testAccount4 = new Account("David", 500, "C");



        [TestMethod]
        public void DepositTest()
        {
            bank.accounts.Add(testAccount1);
            int expected = 1200;
            int result = bank.accounts[0].deposit(600);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            bank.accounts.Add(testAccount3);
            int expected = 18000;
            int result = bank.accounts[0].withdraw(600);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TransferTest()
        {
            bank.accounts.Add(testAccount2);
            bank.accounts.Add(testAccount4);
            int expected = 400;
            int result = bank.accounts[1].transfer(bank.accounts[0], 300);
            Assert.AreEqual(expected, result);
        }
    }
}
