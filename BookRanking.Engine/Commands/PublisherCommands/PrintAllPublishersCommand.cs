using BookRanking.DTO;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands.PublisherCommands
{
    public class PrintAllPublishersCommand : Command, ICommand
    {
        private readonly IPublisherService publisherService;

        public PrintAllPublishersCommand(IDTOFactory DTOFactory, IPublisherService publisherService)
            :base(DTOFactory)
        {
            this.publisherService = publisherService;
        }
        public override string Execute(IList<string> parameters)
        {
            var publishers = this.publisherService.GetAllPublishers();

            return this.PrintPublishers(publishers);
        }

        private string PrintPublishers(IEnumerable<PublisherDTO> publishers)
        {
            var publishersPrint = new StringBuilder();
            foreach (var publisher in publishers)
            {
                publishersPrint.AppendLine(string.Format("Name: {0}", publisher.Name));
            }

            return publishersPrint.ToString();
        }
    }
}
