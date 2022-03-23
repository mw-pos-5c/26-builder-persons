using System;
using System.IO;

namespace Builder.Persons
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ReadCsv();
        }


        private static void ReadCsv()
        {
            var reader = new StreamReader("persons_with_address.csv");
            reader.ReadLine();
            
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    var builder = new Person.Builder();
                    builder.SetCsvData(line);

                    var person = builder.Build();

                    //Console.WriteLine(person.ToString());

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error in line {line} : {e.Message}");
                }
            }
        }
    }
}
