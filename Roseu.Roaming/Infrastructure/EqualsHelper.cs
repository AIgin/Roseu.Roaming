using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Roseu.Roaming.Infrastructure
{
    /// <summary>
    /// Вспомогательные методы для реализации интерфейсов <see cref="IEquatable{T}"/> и <see cref="IEqualityComparer{T}"/>
    /// </summary>
    public static class EqualsHelper
    {
        /// <summary>
        /// Используется для реализации <see cref="IEquatable{T}.Equals(T)"/>
        /// </summary>
        /// <typeparam name="T">Тип объектов для сравнения</typeparam>
        /// <param name="this">Текущий объект</param>
        /// <param name="other">Другой объект</param>
        /// <param name="equalsWithoutCheck"></param>
        /// <returns>true, если <param name="this"></param> равен <param name="other"></param>, в противном случае — false</returns>
        public static bool EquatableEquals<T>(this T @this, T other, Func<T, T, bool> equalsWithoutCheck)
            where T : class, IEquatable<T>
        {
            if ((object)other == null)
            {
                return false;
            }
            else
            {
                return equalsWithoutCheck(@this, other);
            }
        }

        /// <summary>
        /// Используется для реализации <see cref="IEquatable{T}.Equals(T)"/> (для типов, реализующих <see cref="IEquatableAndEqualityComparer{T}"/>)
        /// </summary>
        /// <example>
        /// <code>
        /// public bool Equals(T other)
        /// {
        ///     return this.EquatableEquals(other);
        /// }
        /// </code>
        /// </example>
        /// <typeparam name="T">Тип объектов для сравнения</typeparam>
        /// <param name="this">Текущий объект</param>
        /// <param name="other">Другой объект</param>
        /// <returns>true, если <param name="this"></param> равен <param name="other"></param>, в противном случае — false</returns>
        public static bool EquatableEquals<T>(this T @this, T other)
            where T : class, IEquatableAndEqualityComparer<T>
        {
            return EquatableEquals(@this, other, (x, y) => x.EqualsWithoutNullCheck(y));
        }

        public static bool EqualityComparerEquals<T>(this T x, T y)
            where T : class, IEquatable<T>
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.Equals(y);
            }
        }

        public static bool ObjectOverrideEquals<T>(this T @this, object obj)
            where T : class, IEquatable<T>
        {
            if ((obj == null) || @this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                return @this.Equals(obj as T);
            }
        }
    }
}
