using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

{
    class HashTable
    {
        class HashArray
        {
            public int key;
            public string value;
            //constructor
            public HashArray(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
            //getter
            public int getkey()
            {
                return key;
            }
            //getter
            public string getvalue()
            {
                return value;
            }
        }
        //our hash size
        int maxSize = 20;
        HashArray[] hash;

        //creates empty hashtable
        public HashTable()
        {
            hash = new HashArray[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                hash[i] = null;
            }
        }

        //Search method to find value in table
        public string findValue(int key, string value)
        {
            int index = key % maxSize;
            for (int j = 0; j < maxSize; j++)
            {
                index = (index + j * j) % maxSize;
                if (hash[index].getvalue() == value)
                {

                    return String.Format("{0} found at key[{1}]", value, index); ;
                }
                else if (hash[index].getvalue() == null)
                {
                    return "Found null value, exiting.";
                }

            }
            return String.Format("{0} was not found.", value);

        }

        //checks for open spaces in the hash for insertion
        private bool checkOpenSpace()
        {
            bool isOpen = false;
            for (int i = 0; i < maxSize; i++)
            {
                if (hash[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }
        public void print()
        {
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] == null && i <= maxSize)//if we have null entries
                    continue;// continue the looping, skips the null
                else
                {

                    Console.WriteLine("String: " + findValue(hash[i].getkey(), hash[i].getvalue())
                        + " Length of value: " + hash[i].getvalue().Length);
                }
            }
        }

        //Quadratic probing method inserts into the table
        public void quadraticHashInsert(int key, string value)
        {
            if (!checkOpenSpace())//If no open spaces available
            {
                Console.WriteLine("Table is full");
                return;
            }

            int j;
            int index = key % maxSize;
            for (j = 0; j < maxSize && hash[index] != null && hash[index].getkey() != key; j++)
            {
                index = (index + j * j) % maxSize;
            }

            if (hash[index] == null)
            {
                hash[index] = new HashArray(key, value);
                return;
            }
        }
    }
}
