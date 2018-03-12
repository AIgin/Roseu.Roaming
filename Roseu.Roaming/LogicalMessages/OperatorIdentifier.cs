using Org.Roseu.Roaming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Org.Roseu.Roaming.LogicalMessages
{
    /// <summary>
    /// Идентификатор оператора.
    /// Должен быть глобально уникальным, длина 3 символа.
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public class OperatorIdentifier : IEquatableAndEqualityComparer<OperatorIdentifier>, IStringValue
    {
        /// <summary>
        /// Длина
        /// </summary>
        public const int Length = 3;

        /// <summary>
        /// Шаблон
        /// </summary>
        public static readonly Regex Pattern = new Regex("^[a-zA-Z0-9]{3}$", RegexOptions.Compiled);

        public OperatorIdentifier(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (!Pattern.IsMatch(id)) throw new ArgumentException(ExceptionMessages.InvalidFormat("идентификатора оператора", Pattern.ToString(), id), "id");

            this.Value = id.ToUpperInvariant();
        }

        /// <inheritdoc />
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool EqualsWithoutNullCheck(OperatorIdentifier other)
        {
            return string.Equals(this.Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public bool Equals(OperatorIdentifier other)
        {
            return this.EquatableEquals(other);
        }

        /// <inheritdoc/>
        public bool Equals(OperatorIdentifier x, OperatorIdentifier y)
        {
            return x.EqualityComparerEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(OperatorIdentifier obj)
        {
            return obj.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.ObjectOverrideEquals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Value;
        }
    }
}
