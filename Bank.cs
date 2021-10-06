using System;
using System.Collections.Generic;
using System.Text;

namespace AutoVinCode
{
    public class Bank
    {
        public string name { get; set; }
        public List<Account> accounts { get; set; }

        public Bank(string _name, List<Account> _accounts)
        {
            name = _name;
            accounts = _accounts;
        }

        public static void Main(string[] args)
        {

        }
    }
}
