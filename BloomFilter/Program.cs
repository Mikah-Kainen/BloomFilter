using System;

namespace BloomFilter
{
    class Program
    {
        static int Hash1(string value)
        {
            return (value, "test").GetHashCode();
        }

        static int Hash2(string value)
        {
            return (value, 31).GetHashCode() ^ Hash1(value);
        }

        static void Main(string[] args)
        {
            BloomStorage<string> bloomFilter = new BloomStorage<string>(50);
            bloomFilter.AddHash(Hash1);
            bloomFilter.AddHash(Hash2);


            bloomFilter.Insert("int");
            bloomFilter.Insert("string");
            bloomFilter.Insert("bool");
            bloomFilter.Insert("array");
            bloomFilter.Insert("class");
            bloomFilter.Insert("List");
            bloomFilter.Insert("Queue");
            bloomFilter.Insert("Stack");
            bloomFilter.Insert("Interface");
            bloomFilter.Insert("HI");
            bloomFilter.Insert("student");
            bloomFilter.Insert("teacher");
            bloomFilter.Insert("computer");
            bloomFilter.Insert("mouse");
            bloomFilter.Insert("mice");
            bloomFilter.Insert("moose");
            bloomFilter.Insert("house");
            bloomFilter.Insert("goose");
            bloomFilter.Insert("geese");

            bool result1 = bloomFilter.PossiblyInside("geese");
            bool result2 = bloomFilter.PossiblyInside("Queue");
            bool result3 = bloomFilter.PossiblyInside("queue");

            bool result4 = bloomFilter.PossiblyInside("zoo");
            bool result5 = bloomFilter.PossiblyInside("cow");
            bool result6 = bloomFilter.PossiblyInside("eat");
            bool result7 = bloomFilter.PossiblyInside("studious");
            bool result8 = bloomFilter.PossiblyInside("programming");
        }
    }
}
