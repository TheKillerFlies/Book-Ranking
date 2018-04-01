using BookRanking.Common.Utils.Contracts;
using BookRanking.Engine.Commands.Contracts;
using BookRanking.Engine.Factories.Contracts;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRanking.Engine.Commands.AuthorCommands
{
    public class ExportAllAuthorsCommand : Command, ICommand
    {
        private IAuthorService authorService;
        private IPdfExporter pdfExporter;

        public ExportAllAuthorsCommand(IDTOFactory DTOFactory, IAuthorService authorService, IPdfExporter pdfExporter) : base(DTOFactory)
        {
            this.authorService = authorService;
            this.pdfExporter = pdfExporter;
        }

        public override string Execute(IList<string> parameters)
        {
            var fileName = parameters[0];

            var sb = new StringBuilder();
            sb.AppendLine("All authors:");
            foreach (var author in this.authorService.GetAllAuthors())
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} {author.Alias}");
            }

            this.pdfExporter.ExportPdf("Authors", sb.ToString(), fileName);

            return Messages.AuthorsExportedSuccessfully;
        }
    }
}
