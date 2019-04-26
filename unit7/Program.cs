using System;
using System.Diagnostics;
using static System.Console;

namespace unit7
{
    class Program
    {
        static string[] sarray = { "begin", "ok", "good", "error", "end" };
        static void throwExcept()
        {
            foreach (string s in sarray)
            {
                switch (s)
                {
                    case "begin":
                        Trace.Write(s, "no throw");
                        break;
                    case "ok":
                        Trace.Write(s, "no throw");
                        break;
                    case "good":
                        Trace.Write(s, "no throw");
                        break;
                    case "error":
                        Trace.Write(s, "throw");
                        throw new Exception();
                        break;
                    case "end":
                        Trace.Write(s, "no throw");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (string s in sarray)
            {
                try
                {

                    WriteLine(s);
                    if (s.Equals("good") || s.Equals("ok"))
                        throwExcept();
                }

                catch (Exception e) when (s == "good")
                {
                    WriteLine("good\n" + e);
                }
                catch (Exception e)
                {
                    WriteLine("not good\n" + e);
                }
                finally
                {
                    WriteLine("finally");
                }
            }
        }
    }
}
