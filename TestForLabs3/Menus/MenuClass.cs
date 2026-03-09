using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    internal class MenuClass
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=======Меню=======");
            Console.WriteLine("1. Показать автомобили");
            Console.WriteLine("2. Добавить автомобиль");
            Console.WriteLine("3. Удалить автомобиль");
            Console.WriteLine("4. Изменить автомобиль");
            Console.WriteLine("5. Сохранение в файл");
            Console.WriteLine("6. Загрузить из файла");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");
        }
    }
}
