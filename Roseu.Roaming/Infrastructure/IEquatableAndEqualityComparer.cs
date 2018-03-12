using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Roseu.Roaming.Infrastructure
{
    /// <inheritdoc cref="IEquatable{T}" />
    /// <inheritdoc cref="IEqualityComparer{T}" />
    /// <summary>
    /// Объединение интерфейсов <see cref="IEquatable{T}"/> и <see cref="IEqualityComparer{T}"/> с добавлением метода <see cref="EqualsWithoutNullCheck"/> для быстрой реализации методов с помощью <see cref="EqualsHelper"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEquatableAndEqualityComparer<T> : IEquatable<T>, IEqualityComparer<T>
    {
        /// <summary>
        /// Проверка равенства объектов без необходимости проверки на null (просто проверить, к примеру, соответствие полей)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool EqualsWithoutNullCheck(T other);
    }
}
