using JetBrains.Annotations;

namespace Transmax.Common
{
    [UsedImplicitly]
    public static class ConvertScore
    {
        private const int Unknown = int.MinValue;

        [UsedImplicitly]
        public static int ToInt32([NotNull] string text)
        {
            if ( string.IsNullOrEmpty(text) ||
                 string.IsNullOrWhiteSpace(text) )
            {
                return Unknown;
            }

            int score;

            return int.TryParse(text,
                                out score)
                       ? score
                       : Unknown;
        }
    }
}