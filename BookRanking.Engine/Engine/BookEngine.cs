using BookRanking.Client.Engine.Contracts;
using BookRanking.Common.MapperContracts;
using BookRanking.Engine.Engine.Contracts;
using BookRanking.Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;

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
            var commandResults = new StringBuilder();
           
                foreach (var currentLine in this.renderer.Input())
                {
                    this.renderer.Output(this.ProcessCommand(currentLine));
                }
        }

        private string ProcessCommand(string commandLine)
        {
            var commandParts = commandLine.Split(' ').ToList();

            var commandName = commandParts[0];
            var commandParameters = commandParts.Skip(1).ToList();
            var command = this.factory.GetCommand(commandName.ToLower());
            return command.Execute(commandParameters);
        }
    }
}
