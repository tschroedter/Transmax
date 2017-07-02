using System;
using JetBrains.Annotations;

namespace Transmax.Integration.Tests
{
    [UsedImplicitly]
    public class StudentScores
        : IComparable<StudentScores>
    {
        public int CompareTo(StudentScores other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) return firstNameComparison;
            var surnameComparison = string.Compare(Surname, other.Surname, StringComparison.Ordinal);
            if (surnameComparison != 0) return surnameComparison;
            return string.Compare(Score, other.Score, StringComparison.Ordinal);
        }

        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Score { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}