using BookRanking.Client.ConsoleLoggerBook.Contracts;

namespace BookRanking.Client.Models.Contracts
{
    public interface IScreenPrinter
    {
        IConsoleLogger Logger { get; set; }

        void PrintStartScreen();

        void PrintChooseCommandScreen();
    }
}
