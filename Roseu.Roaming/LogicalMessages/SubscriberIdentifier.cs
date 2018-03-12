using Org.Roseu.Roaming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Org.Roseu.Roaming.LogicalMessages
{
    /// <summary>
    /// Идентификатор абонента у оператора.
    /// Может быть уникален лишь в рамках одного оператора, длина не более 43 символов.
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public class SubscriberIdentifier : IEquatableAndEqualityComparer<SubscriberIdentifier>, IStringValue
    {
        /// <summary>
        /// Минимальная длина
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// Максимальная длина
        /// </summary>
        public const int MaxLength = 43;

        /// <inheritdoc />
        public string Value { get; private set; }

        public SubscriberIdentifier(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (id.Length < MinLength || id.Length > MaxLength) throw new ArgumentException(ExceptionMessages.InvalidLength("идентификатора абонента", MinLength, MaxLength, id.Length));

            this.Value = id;
        }

        /// <inheritdoc/>
        public bool EqualsWithoutNullCheck(SubscriberIdentifier other)
        {
            return string.Equals(this.Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public bool Equals(SubscriberIdentifier other)
        {
            return this.EquatableEquals(other);
        }

        /// <inheritdoc/>
        public bool Equals(SubscriberIdentifier x, SubscriberIdentifier y)
        {
            return x.EqualityComparerEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(SubscriberIdentifier obj)
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
