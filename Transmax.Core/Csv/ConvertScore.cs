using JetBrains.Annotations;

namespace Transmax.Core.Csv
{
    public static class ConvertScore
    {
        private const int Unknown = int.MinValue;

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