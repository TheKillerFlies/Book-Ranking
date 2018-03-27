using BookRanking.Client.ConsoleLoggerBook.Contracts;
using System;

namespace BookRanking.Client.ConsoleLoggerBook
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void SetSize()
        {
            Console.SetWindowSize(120, 26);
        }
    }
}
