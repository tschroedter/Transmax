using JetBrains.Annotations;
using Transmax.Core.Interfaces;

namespace Transmax.Core
{
    [UsedImplicitly]
    public class ApplicationMode
        : IApplicationMode
    {
        public ApplicationMode()
        {
#if DEBUG
            IsRelease = false;
#else
            IsRelease = true;
#endif
        }

        public bool IsRelease { get; }
    }
}