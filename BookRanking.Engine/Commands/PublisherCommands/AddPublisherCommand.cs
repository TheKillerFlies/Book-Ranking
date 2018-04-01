using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Engine.Commands.PublisherCommands
{
    public class AddPublisherCommand : Command, ICommand
    {
        private readonly IDTOFactory DTOFactory;
        private readonly IPublisherService publisherService;

        public AddPublisherCommand(IDTOFactory DTOFactory, IPublisherService publisherService)
            : base(DTOFactory)
        {
            this.DTOFactory = DTOFactory;
            this.publisherService = publisherService;
        }
        public override object Execute(IList<string> parameters)
        {
            var name = parameters[0];
            var publisher = this.DTOFactory.CreatePublisherDTO(name);
            this.publisherService.AddPublisher(publisher);
            return null;
        }
    }
}
