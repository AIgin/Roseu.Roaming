using Org.Roseu.Roaming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Org.Roseu.Roaming.LogicalMessages
{
    /// <summary>
    /// Код причины постановки на учет (КПП)
    /// </summary>
    public class Kpp : IEquatableAndEqualityComparer<Kpp>, IStringValue
    {
        /// <summary>
        /// Шаблон
        /// </summary>
        public static readonly Regex Pattern = new Regex("^([0-9]{1}[1-9]{1}|[1-9]{1}[0-9]{1})([0-9]{2})([0-9A-F]{2})([0-9]{3})$", RegexOptions.Compiled);

        /// <inheritdoc />
        public string Value { get; private set; }

        public Kpp(string kpp)
        {
            if (kpp == null) throw new ArgumentNullException("kpp");
            if (!Pattern.IsMatch(kpp)) throw new ArgumentException(ExceptionMessages.InvalidFormat("КПП", Pattern.ToString(), kpp), "kpp");

            this.Value = kpp;
        }

        /// <inheritdoc/>
        public bool EqualsWithoutNullCheck(Kpp other)
        {
            return this.Value == other.Value;
        }

        /// <inheritdoc/>
        public bool Equals(Kpp other)
        {
            return this.EquatableEquals(other);
        }

        /// <inheritdoc/>
        public bool Equals(Kpp x, Kpp y)
        {
            return x.EqualityComparerEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(Kpp obj)
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
