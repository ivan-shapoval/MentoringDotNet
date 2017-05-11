using System;
using System.Collections.Generic;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void Test1()
        {
            var hashTable = new HashTable();
            var transaction = new Transaction
            {
                Who = "John Doe",
                Date = "24/03/1998",
                Amount = 1000
            };
            hashTable.Add(transaction, transaction);

            Assert.AreEqual(transaction, hashTable[transaction]);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test2()
        {
            var hashTable = new HashTable();
            var transaction = new Transaction
            {
                Who = "John Doe",
                Date = "24/03/1998",
                Amount = 1000
            };
            hashTable.Add(transaction, transaction);
            hashTable[transaction] = null;
            var value = hashTable[transaction];
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test3()
        {
            var hashTable = new HashTable();
            var transaction = new Transaction
            {
                Who = "John Doe",
                Date = "24/03/1998",
                Amount = 1000
            };
            hashTable.Add(transaction, transaction);
            hashTable.Add(transaction, transaction);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test4()
        {
            var hashTable = new HashTable();
            var transaction1 = new Transaction
            {
                Who = "John Doe",
                Date = "24/03/1998",
                Amount = 1000
            };
            var transaction2 = new Transaction
            {
                Who = "John Do",
                Date = "24/03/1998",
                Amount = 1000
            };
            hashTable.Add(transaction1, transaction1);
            var value = hashTable[transaction2];
        }


        [TestMethod]
        public void Test5()
        {
            var hashTable = new HashTable();
            var transactions = new List<Transaction>();

            for (int i = 0; i < 10; i++)
            {
                transactions.Add(new Transaction
                {
                    Who = "John Doe" + i,
                    Date = i + "/03/1998",
                    Amount = 1000 + i
                });
                hashTable.Add(transactions[i], transactions[i]);                
            }

            foreach (var transaction in transactions)
            {
                Assert.AreEqual(transaction, hashTable[transaction]);
            }
        }


    }
}
