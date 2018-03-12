using Org.Roseu.Roaming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Org.Roseu.Roaming.LogicalMessages
{
    /// <summary>
    /// Идентификационный номер налогоплательщика (ИНН)
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public class Inn : IEquatableAndEqualityComparer<Inn>, IStringValue
    {
        /// <summary>
        /// Шаблон
        /// </summary>
        public static readonly Regex Pattern = new Regex("^(([0-9]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{8})|(([0-9]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{10})$", RegexOptions.Compiled);

        /// <inheritdoc />
        public string Value { get; private set; }

        public Inn(string inn)
        {
            if (inn == null) throw new ArgumentNullException("inn");
            if (!Pattern.IsMatch(inn)) throw new ArgumentException(ExceptionMessages.InvalidFormat("ИНН", Pattern.ToString(), inn), "inn");

            this.Value = inn;
        }

        /// <inheritdoc/>
        public bool EqualsWithoutNullCheck(Inn other)
        {
            return this.Value == other.Value;
        }

        /// <inheritdoc/>
        public bool Equals(Inn other)
        {
            return this.EquatableEquals(other);
        }

        /// <inheritdoc/>
        public bool Equals(Inn x, Inn y)
        {
            return x.EqualityComparerEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(Inn obj)
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
