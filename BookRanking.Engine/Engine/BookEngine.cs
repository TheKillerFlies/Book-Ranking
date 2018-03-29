using BookRanking.Client.Engine.Contracts;
using BookRanking.Common.MapperContracts;
using BookRanking.Engine.Engine.Contracts;
using BookRanking.Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
namespace BookRanking.Client.Engine
{
    public class BookEngine : IBookEngine
    {
        private readonly IRenderer renderer;
        private readonly ICommandFactory factory;


        public BookEngine(IRenderer consoleRenderer, ICommandFactory factory)
        {
            this.renderer = consoleRenderer;
            this.factory = factory; 
        }

        public void Start()
        {
            var commandResults = new List<string>();

           
                foreach (var currentLine in this.renderer.Input())
                {
                    this.ProcessCommand(currentLine);
                }

        }

        private void ProcessCommand(string commandLine)
        {
            var commandParts = commandLine.Split(' ').ToList();

            var commandName = commandParts[0];
            var commandParameters = commandParts.Skip(1).ToList();

            var command = this.factory.GetCommand(commandName.ToLower());
            command.Execute(commandParameters);
        }
        //private readonly IScreenPrinter printer;

        //public BookEngine(IScreenPrinter printer)
        //{
        //    this.printer = printer ?? throw new ArgumentNullException();
        //}

        //public IScreenPrinter Printer { get { return this.printer; } }

        //public void Start()
        //{
        //    this.Printer.PrintStartScreen();
        //    this.Printer.PrintChooseCommandScreen();
        //}
    }
}
