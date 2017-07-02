using JetBrains.Annotations;

namespace Transmax.Core.Interfaces
{
    public interface IGradeRunner
    {
        void Grade(
            [NotNull] string sourceFilename);
    }
}