using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BloomFilter
{
    public class BloomStorage<T>
    {
        public List<Func<T, int>> HashFunctions { get; private set; }
        public int arraySize { get; private set; }
        public bool[] storage { get; private set; }

        private int DefaultHash(T value)
        {
            return value.GetHashCode();
        }

        public BloomStorage(int arraySize)
        {
            HashFunctions = new List<Func<T, int>>();
            HashFunctions.Add(DefaultHash);
            this.arraySize = arraySize;
            storage = new bool[arraySize];
        }

        public BloomStorage(int arraySize, Func<T, int> HashFunction)
        {
            HashFunctions = new List<Func<T, int>>();
            HashFunctions.Add(HashFunction);
            this.arraySize = arraySize;
            storage = new bool[arraySize];
        }

        public bool AddHash(Func<T, int> newHash)
        {
            bool result = true;
            if(HashFunctions.Contains(newHash))
            {
                result = false;
            }
            HashFunctions.Add(newHash);
            return result;
        }

        public bool RemoveHash(Func<T, int> targetHash)
        {
            return HashFunctions.Remove(targetHash);
        }

        public void Insert(T value)
        {
            foreach(Func<T, int> hashFunction in HashFunctions)
            {
                storage[Math.Abs(hashFunction(value)) % arraySize] = true;
            }
        }

        public bool PossiblyInside(T value)
        {
            foreach(Func<T, int> hashFunction in HashFunctions)
            {
                if(!storage[Math.Abs(hashFunction(value)) % arraySize])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
