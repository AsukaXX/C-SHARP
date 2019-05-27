using System;
using static System.Console;

namespace unit13_2
{
    public class Display
    {
        //public void DisplayMessage(String message) =>
        // WriteLine($"Message arrived: {message}");

        public void DisplayMessage(object source, MessageArrivedEventArgs e)
        {
            WriteLine($"Message arrived from:{((Connection)source).Name}");
            WriteLine($"Message Text: {e.Message}");
        }
    }
}