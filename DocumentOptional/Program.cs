using System;
using System.IO;  // this is needed to use StreamWriter
using System.Globalization;  // this is needed to use CultureInfo

namespace DocumentOptional
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            while (true)
            {
                Console.WriteLine("Document\n");
                Console.Write("Enter the name of the document: ");
                string name = Console.ReadLine();
                Console.Write("Enter the content of the document: ");
                string content = Console.ReadLine();
                StreamWriter streamWriter = null;
                try
                {
                    if (!name.EndsWith(".txt", true, cultureInfo))
                    {
                        name += ".txt";
                    }
                    streamWriter = new StreamWriter(name);
                    streamWriter.WriteLine(content);
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", name, content.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                    }
                }
                Console.Write("Would you like to save another document? (y/n): ");
                if (!Console.ReadLine().ToLower().StartsWith('y')) break;  // y, yes, Yes, yeah, yo, etc will work
                //if (!Console.ReadLine().ToLower().Equals("y")) break;  // or use this when y or Y only is allowed
                Console.WriteLine(""); //put a blank line between sessions
            }
        }
    }
}
