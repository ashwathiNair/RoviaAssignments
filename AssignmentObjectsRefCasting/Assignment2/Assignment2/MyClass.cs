using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class MyClass
    {
        public MyClass(int num1, int num2)
        {
            a = num1;
            b = num2;
        }
       
        public override string ToString()
        {
            var myClassDetails = "This is a test class used to demonstrate how to override the ToString() method of an object";
            return myClassDetails;
            //return base.ToString();
        }

        int a = 5;
        int b = 10;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return a ^ b;
        }

    }

  }
