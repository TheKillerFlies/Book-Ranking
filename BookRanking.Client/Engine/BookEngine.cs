using BookRanking.Client.Engine.Contracts;
using BookRanking.Client.Models.Contracts;
using System;

namespace BookRanking.Client.Engine
{
    public class BookEngine : IBookEngine
    {
        private readonly IScreenPrinter printer;

        public BookEngine(IScreenPrinter printer)
        {
            this.printer = printer ?? throw new ArgumentNullException();
        }

        public IScreenPrinter Printer { get { return this.printer; } }

        public void Start()
        {
            this.Printer.PrintStartScreen();
            this.Printer.PrintChooseCommandScreen();
        }
    }
}
