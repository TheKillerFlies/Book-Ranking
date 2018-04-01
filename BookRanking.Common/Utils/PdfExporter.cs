using System.IO;
using BookRanking.Common.Utils.Contracts;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BookRanking.Common.Utils
{
    public class PdfExporter : IPdfExporter
    {
        public void ExportPdf(string title, string content, string filename)
        {
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + $"{filename}.pdf",
                FileMode.Create);

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.AddTitle(title);

            document.Open();


            document.Add(new Paragraph(content));

            // Close the document

            document.Close();
            // Close the writer instance

            writer.Close();
            // Close open filehandles explicity
            fs.Close();
        }
    }
}
