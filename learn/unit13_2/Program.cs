using System;
using static System.Console;

namespace unit13_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Connection connect = new Connection();
            Display display = new Display();
            connect.MessageArrived += display.DisplayMessage;
            connect.Connect();
            Console.ReadKey(); */
            Connection myconnect1 = new Connection();
            myconnect1.Name = "First connection";
            Connection myconnect2 = new Connection();
            myconnect2.Name = "Second connection";
            Display display = new Display();
            myconnect1.MessageArrived += display.DisplayMessage;
            myconnect2.MessageArrived += display.DisplayMessage;
            myconnect1.Connect();
            myconnect2.Connect();
            ReadKey();
        }
    }
}
