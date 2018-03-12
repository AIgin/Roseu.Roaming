using Org.Roseu.Roaming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Org.Roseu.Roaming.LogicalMessages
{
    /// <summary>
    /// Идентификатор участника ЭДО.
    /// Формат идентификатора: [ИдентификаторОператора][ИдентификаторАбонента].
    /// </summary>
    [DebuggerDisplay("{Value}, OperatorId = {OperatorId.Value}, SubscriberId = {SubscriberId.Value}")]
    public class EdoMemberIdentifier : IEquatableAndEqualityComparer<EdoMemberIdentifier>, IStringValue
    {
        /// <summary>
        /// Минимальная длина
        /// </summary>
        public const int MinLength = OperatorIdentifier.Length + SubscriberIdentifier.MinLength;

        /// <summary>
        /// Максимальная длина
        /// </summary>
        public const int MaxLength = OperatorIdentifier.Length + SubscriberIdentifier.MaxLength;

        /// <summary>
        /// Идентификатор оператора
        /// </summary>
        public OperatorIdentifier OperatorId { get; private set; }

        /// <summary>
        /// Идентификатор абонента
        /// </summary>
        public SubscriberIdentifier SubscriberId { get; private set; }

        /// <inheritdoc />
        public string Value { get { return string.Format("{0}{1}", this.OperatorId.Value, this.SubscriberId.Value); } }

        public EdoMemberIdentifier(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (id.Length < MinLength || id.Length > MaxLength) throw new ArgumentException(ExceptionMessages.InvalidLength("идентификатора участника ЭДО", MinLength, MaxLength, id.Length));

            this.OperatorId = new OperatorIdentifier(id.Substring(0, 3));
            this.SubscriberId = new SubscriberIdentifier(id.Substring(3));
        }

        public EdoMemberIdentifier(OperatorIdentifier operatorId, SubscriberIdentifier subscriberId)
        {
            if (operatorId == null) throw new ArgumentNullException("operatorId");
            if (subscriberId == null) throw new ArgumentNullException("subscriberId");

            this.OperatorId = operatorId;
            this.SubscriberId = subscriberId;
        }

        /// <inheritdoc/>
        public bool EqualsWithoutNullCheck(EdoMemberIdentifier other)
        {
            return this.OperatorId.Equals(other.OperatorId)
                   && this.SubscriberId.Equals(other.SubscriberId);
        }

        /// <inheritdoc/>
        public bool Equals(EdoMemberIdentifier other)
        {
            return this.EquatableEquals(other);
        }

        /// <inheritdoc/>
        public bool Equals(EdoMemberIdentifier x, EdoMemberIdentifier y)
        {
            return x.EqualityComparerEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(EdoMemberIdentifier obj)
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
