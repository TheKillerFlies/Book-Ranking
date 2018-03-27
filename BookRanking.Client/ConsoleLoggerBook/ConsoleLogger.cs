using BookRanking.Client.ConsoleLoggerBook.Contracts;

namespace BookRanking.Client.ConsoleLoggerBook
{
    public class ConsoleLogger : IConsoleLogger
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public ConsoleLogger(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Read()
        {
            return this.reader.Read();
        }

        public void Write(string text)
        {
            this.writer.Write(text);
        }

        public void ReadKey()
        {
            this.reader.ReadKey();
        }

        public void Clear()
        {
            this.writer.Clear();
        }

        public void SetSize()
        {
            this.writer.SetSize();
        }
    }
}
