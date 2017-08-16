using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Assignment 1.Override the Object's ToString() method to show some info about your class.
            var myClass = new MyClass(6,7);
            string myClassDetails = myClass.ToString();
            Console.WriteLine(myClassDetails);


            //Assignment 2.Demonstrate the above class for A System.Dictionary as A key and do following operations.
            //A.Ability to add A key value
            //B.Update value by key
            //c.Delete value by using key   

            var dictionary = new Dictionary<MyClass, string>();
            var myClass1 = new MyClass(1,2);
            var myClass2 = new MyClass(2,3);
            var myClass3 = new MyClass(3,4);

            dictionary.Add(myClass1, "first");
            dictionary.Add(myClass2, "second");
            dictionary.Add(myClass3, "third");
            //dictionary.Add(myClass2, "third"); //why was the equals method called in the above two instances?


            dictionary[myClass2] = "secondClass";

            dictionary.Remove(myClass2);

            Console.WriteLine(myClass1.GetHashCode());
            Console.WriteLine(myClass2.GetHashCode());

            Console.WriteLine(myClass1.GetType());
            Console.WriteLine(myClass2.GetType());

            Console.ReadKey();
        }
    }
}
