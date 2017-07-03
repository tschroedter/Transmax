using JetBrains.Annotations;
using Transmax.Core.Interfaces.Csv;

namespace Transmax.Core.Csv
{
    [UsedImplicitly]
    public class InputFileColumnIndices
        : IInputFileColumnIndices
    {
        public InputFileColumnIndices()
        {
            FirstName = 0;
            Surname = 1;
            Score = 2;
        }

        public int FirstName { get; private set; }
        public int Surname { get; private set; }
        public int Score { get; private set; }
    }
}