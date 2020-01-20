using ConsoleAppDoubleHash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppDoubleHash.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        [TestMethod()]
        public void RetrieveTest()
        {
            // Arrange
            HashTable hashTable = new HashTable();
            var data1 = new HashTable.HashNode(5, "Андрей");
            var data2 = new HashTable.HashNode(5, "Олег");

            // Act
            hashTable.DoubleHashInsert(data1.Key, data1.Data);
            hashTable.DoubleHashInsert(data2.Key, data2.Data);

            // Assert
            Assert.AreEqual(data1.Data, hashTable.Retrieve(data1.Key).Data);
            Assert.AreEqual(data2.Data, hashTable.Retrieve(data2.Key).Next.Data);
        }

        [TestMethod()]
        public void RetrieveTest1()
        {
            // Arrange
            HashTable hashTable = new HashTable();
            var data1 = new HashTable.HashNode(5, null);
            var data2 = new HashTable.HashNode(25, "Олег");

            // Act
            hashTable.DoubleHashInsert(data1.Key, data1.Data);
            hashTable.DoubleHashInsert(data2.Key, data2.Data);

            // Assert
            Assert.IsNull(data1.Data, hashTable.Retrieve(data1.Key).Data);
            Assert.AreEqual(data2.Data, hashTable.Retrieve(data2.Key).Data);
        }


        [TestMethod()]
        public void RetrieveTest2()
        {
            // Arrange
            HashTable hashTable = new HashTable();
            var data1 = new HashTable.HashNode(5, "Андрей");
            var data2 = new HashTable.HashNode(25, "Сергей");
            var data3 = new HashTable.HashNode(5, "Олег");

            int count = 2;

            // Act
            hashTable.DoubleHashInsert(data1.Key, data1.Data);
            hashTable.DoubleHashInsert(data2.Key, data2.Data);
            hashTable.DoubleHashInsert(data3.Key, data3.Data);

            // Assert
            Assert.AreEqual(data1.Data, hashTable.Retrieve(data1.Key).Data);
            Assert.AreEqual(count, hashTable.Retrieve(data1.Key).count);
        }

        [TestMethod()]
        public void RetrieveTest3()
        {
            // Arrange
            string[] str = { "Привет ", "мир!"};
            Program.Main(str);
            HashTable hashTable = new HashTable();
            var data1 = new HashTable.HashNode(key: 5, data: "Андрей");
            var data2 = new HashTable.HashNode(key: 6, data: "Сергей");
            var data3 = new HashTable.HashNode(key: 12, data: "Владимир");
            var data4 = new HashTable.HashNode(key: 13, data: "Максим");
            var data5 = new HashTable.HashNode(key: 21, data: "Родион");
            var data6 = new HashTable.HashNode(key: 8, data: "Евгений");
            var data7 = new HashTable.HashNode(key: 54, data: "Ольга");
            var data8 = new HashTable.HashNode(key: 48, data: "Мария");
            var data9 = new HashTable.HashNode(key: 66, data: "Валентин");
            var data10 = new HashTable.HashNode(key: 1, data: "Борис");
            var data11 = new HashTable.HashNode(key: 3, data: "Анна");

            // Act
            hashTable.DoubleHashInsert(data1.Key, data1.Data);
            hashTable.DoubleHashInsert(data2.Key, data2.Data);
            hashTable.DoubleHashInsert(data3.Key, data3.Data);
            hashTable.DoubleHashInsert(data4.Key, data4.Data);
            hashTable.DoubleHashInsert(data5.Key, data5.Data);
            hashTable.DoubleHashInsert(data6.Key, data6.Data);
            hashTable.DoubleHashInsert(data7.Key, data7.Data);
            hashTable.DoubleHashInsert(data8.Key, data8.Data);
            hashTable.DoubleHashInsert(data9.Key, data9.Data);
            hashTable.DoubleHashInsert(data10.Key, data10.Data);

            // Assert
            Assert.IsFalse(hashTable.DoubleHashInsert(data11.Key, data11.Data));
        }
    }
}