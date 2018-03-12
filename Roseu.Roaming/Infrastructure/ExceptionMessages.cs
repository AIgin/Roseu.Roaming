using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Roseu.Roaming.Infrastructure
{
    /// <summary>
    /// Типовые сообщения для исключений
    /// </summary>
    public class ExceptionMessages
    {
        protected const string InvalidLengthMessageWith3Arg = "Недопустимая длина {0}. Ожидалась {1}, получена {2}";

        protected const string InvalidLengthMinMaxMessageWith4Arg = "Недопустимая длина {0}. Ожидалась от {1} до {2}, получена {3}";

        protected const string InvalidFormatMessageWith3Arg = "Недопустимый формат {0}. Полученное значение {1} не соответствует ожидаемому формату {2}";

        protected const string UnknownValueMessageWith2Arg = "Неизвестное значение {0}: {1}";

        /// <summary>
        /// Недопустимая длина. См. <see cref="InvalidLengthMessageWith3Arg"/>
        /// </summary>
        /// <param name="subjectInGenitive">Субъект в родительном падеже</param>
        /// <param name="expectedLength">Ожидаемая длина</param>
        /// <param name="receivedLength">Полученная длина</param>
        /// <returns></returns>
        public static string InvalidLength(string subjectInGenitive, int expectedLength, int receivedLength)
        {
            return string.Format(InvalidLengthMessageWith3Arg, subjectInGenitive, expectedLength, receivedLength);
        }

        /// <summary>
        /// Недопустимая длина. См. <see cref="InvalidLengthMinMaxMessageWith4Arg"/>
        /// </summary>
        /// <param name="subjectInGenitive">Субъект в родительном падеже</param>
        /// <param name="minExpectedLength">Минимальная ожидаемая длина</param>
        /// <param name="maxExpectedLength">Максимально ожидаемая длина</param>
        /// <param name="receivedLength">Полученная длина</param>
        /// <returns></returns>
        public static string InvalidLength(string subjectInGenitive, int minExpectedLength, int maxExpectedLength, int receivedLength)
        {
            return string.Format(InvalidLengthMinMaxMessageWith4Arg, subjectInGenitive, minExpectedLength, maxExpectedLength, receivedLength);
        }

        /// <summary>
        /// Недопустимый формат. См. <see cref="InvalidFormatMessageWith3Arg"/>
        /// </summary>
        /// <param name="subjectInGenitive">Субъект в родительном падеже</param>
        /// <param name="expectedFormat">Ожидаемый формат</param>
        /// <param name="receivedValue">Полученное значение</param>
        /// <returns></returns>
        public static string InvalidFormat(string subjectInGenitive, string expectedFormat, string receivedValue)
        {
            return string.Format(InvalidFormatMessageWith3Arg, subjectInGenitive, receivedValue, expectedFormat);
        }

        /// <summary>
        /// Неизвестное значение. См. <see cref="UnknownValueMessageWith2Arg"/>
        /// </summary>
        /// <param name="subjectInGenitive">Субъект в родительном падеже</param>
        /// <param name="receivedValue">Полученное значение</param>
        /// <returns></returns>
        public static string UnknownValue(string subjectInGenitive, string receivedValue)
        {
            return string.Format(UnknownValueMessageWith2Arg, subjectInGenitive, receivedValue);
        }
    }
}
