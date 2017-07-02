namespace Transmax.Core.Interfaces
{
    public interface IGrader
    {
        string SourceFilename { get; set; }
        string DestinationFilename { get; set; }
        void Process();
    }
}