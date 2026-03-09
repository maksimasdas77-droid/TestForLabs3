using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    internal class ReadClass
    {

        public delegate bool UniTryParse<T>(string input, out T value); //дженерик для readvalue<T>
        public static T ReadValue<T>(string message, UniTryParse<T> parser) //самый универсальный метод ввода и безопасный на данный момент который я знаю
        {
            Console.Write(message);
            T value;

            while (!parser(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }
        public static T ReadValue<T>(UniTryParse<T> parser)
        {
            T value;
            while (!parser(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        //методы для зацикливания ввода при выходе за необходимый диапазон (два варианта, по аналогии с ReadValue
        public static T ReadValueWithCondition<T>(string message, UniTryParse<T> parser, Func<T, bool> condition, string errorMessage = "Некорректный ввод. Попробуйте снова: ")
        {
            Console.Write(message);
            T value;
            while (true)
            {
                if (parser(Console.ReadLine(), out value) && condition(value)) return value;
                Console.Write(errorMessage);
            }
        }
        //        int choice = ReadClass.ReadValueWithCondition(
        //    $"Введите номер машины (1..{cars.Count}): ",
        //    int.TryParse,
        //    value => value >= 1 && value <= cars.Count,
        //    "Нет такой машины. Попробуйте снова: "
        //);

        public static T ReadValueWithCondition<T>(ReadClass.UniTryParse<T> parser, Func<T, bool> condition, string errorMessage = "Некорректный ввод. Попробуйте снова: ")
        {
            T value;

            while (true)
            {
                if (parser(Console.ReadLine(), out value) && condition(value))
                    return value;

                Console.Write(errorMessage);
            }
        }
        //int choice = ReadClass.ReadValueWithCondition(
        //    int.TryParse,
        //    value => value >= 1 && value <= cars.Count,
        //    $"Введите число от 1 до {cars.Count}: "
        //);
        public static T ParseOrRetry<T>(string initialValue, UniTryParse<T> parser, string errorMessage = "Некорректный ввод. Попробуйте снова: ")
        {
            T value;

            // сначала пробуем уже имеющуюся строку
            if (parser(initialValue, out value))
                return value;

            // если не получилось — начинаем цикл ввода
            Console.Write(errorMessage);

            while (!parser(Console.ReadLine(), out value))
            {
                Console.Write(errorMessage);
            }

            return value;
        }



    }
}
