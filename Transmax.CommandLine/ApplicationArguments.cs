using Transmax.CommandLine.Interfaces;

namespace Transmax.CommandLine
{
    public class ApplicationArguments
        : IApplicationArguments
    {
        public string Filename { get; set; }
    }
}