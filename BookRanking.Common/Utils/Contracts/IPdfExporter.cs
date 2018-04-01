namespace BookRanking.Common.Utils.Contracts
{
    public interface IPdfExporter
    {
        void ExportPdf(string title, string content, string filename);
    }
}
