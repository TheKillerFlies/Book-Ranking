using BookRanking.Client.ConsoleLoggerBook.Contracts;
using System;

namespace BookRanking.Client.ConsoleLoggerBook
{
    public class ConsoleReader : IConsoleReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
