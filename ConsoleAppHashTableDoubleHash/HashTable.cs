using System;
using System.Linq;

namespace ConsoleAppDoubleHash
{
    public class HashTable
    {
        public class HashNode
        {
            int _key;
            string _data;

            public HashNode(int key, string data)
            {
                Key = key;
                Data = data;
                Next = null;
            }

            public int Key { get { return _key; } set { _key = value; } }

            public string Data { get { return _data; } set { _data = value; } }

            public HashNode Next { get; set; }

            public int count = 1;
        }

        int tabSize = 0;
        const int maxSize = 10; //our table size
        HashNode[] table;

        public HashTable()
        {
            table = new HashNode[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }

        public HashNode Retrieve(int key)
        {
            HashNode node = table.SingleOrDefault(l => l != null && l.Key == key);
            return node;
        }

        public bool DoubleHashInsert(int key, string data)
        {
            if (tabSize == maxSize)
            {
                Console.WriteLine("Таблица заполнена!");
                return false;
            }
                
            HashNode node = new HashNode(key, data);

            //double probing method
            int i = 1;
            int hashVal = Hash1(key);
            //int stepSize = Hash2(key);

            while (table[hashVal] != null && table[hashVal].Key != key)
            {
                hashVal = (hashVal + i * Hash2(key)) % maxSize;
                i++;
            }
            if (table[hashVal] != null)
            {
                node.Next = table[hashVal].Next;
                table[hashVal].Next = node;
                table[hashVal].count++;
            }
            else
            {
                table[hashVal] = node;
                tabSize++;
            }
            return true;
        }

        private int Hash1(int key)
        {
            return key % maxSize;
        }

        private int Hash2(int key)
        {
            //must be non-zero, less than array size, ideally odd
            //return 5 - key % 5;
            return key % 7 + 1;
        }
    }
}