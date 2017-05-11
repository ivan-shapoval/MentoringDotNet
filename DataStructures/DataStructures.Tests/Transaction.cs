using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class Transaction
    {
        public string Who { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            if (transaction == null)
                return false;

            return transaction.Who == Who
                   && transaction.Date == Date
                   && transaction.Amount == Amount;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 31 * hash + Who.GetHashCode();
            hash = 31 * hash + Date.GetHashCode();
            hash = 31 * hash + Amount.GetHashCode();
            return hash;
        }
    }
}
