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
    public class GetAllPublishersCommand : Command, ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private readonly IPublisherService publisherService;

        public GetAllPublishersCommand(IDTOFactory DTOFactory, IPublisherService publisherService)
            :base(DTOFactory)
        {
            this.DTOFactory = DTOFactory;
            this.publisherService = publisherService;
        }
        public override object Execute(IList<string> parameters)
        {
            var publishers = this.publisherService.GetAllPublishers();

            return publishers;
        }
    }
}
