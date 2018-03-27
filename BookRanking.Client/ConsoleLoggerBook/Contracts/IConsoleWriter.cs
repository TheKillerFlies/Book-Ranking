namespace BookRanking.Client.ConsoleLoggerBook.Contracts
{
    public interface IConsoleWriter
    {
        void Write(string text);
        void Clear();
        void SetSize();
    }
}
