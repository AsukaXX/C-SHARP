using System;
using static System.Console;

namespace unit10
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Creating object myObj...");
            MyClass myObj = new MyClass("My Object");
            WriteLine("myObj created.");
            for (int i = -1; i <= 0; i++)
            {
                try
                {
                    WriteLine($"\nAttempting to assign {i} to myObj.Val...");
                    myObj.Val = i;
                    WriteLine($"Value {myObj.Val} assigned tp myObj.Val.");
                }
                catch (Exception e)
                {
                    WriteLine($"Exception {e.GetType().FullName} thrown.");
                    WriteLine($"Message:\n\"{e.Message}\"");
                }
            }
            WriteLine("\nOutputting myObj.ToString()...");
            WriteLine(myObj.ToString());
            WriteLine("myObj.ToString() OutPut.");
            WriteLine("\nmyDoubledIntPorp = 5...");
            WriteLine($"Getting myDoubledIntProp of 5 is {myObj.myDoubledIntProp}");
            ReadKey();
        }
    }
}
