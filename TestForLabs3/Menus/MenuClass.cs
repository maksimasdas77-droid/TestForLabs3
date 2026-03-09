using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static void ShowUnderMenu(CarManager manager, int index)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Информация об автомобиле:\n");
                Console.WriteLine(manager.Cars[index].ToPrettyString());
                Console.WriteLine();

                Console.WriteLine("1. Показать неисправности");
                Console.WriteLine("2. Добавить неисправности");
                Console.WriteLine("3. Удалить неисправности");
                Console.WriteLine("4. Изменить неисправность");
                Console.WriteLine("0. Назад");

                int choice = ReadClass.ReadValue<int>("Выберите действие: ", int.TryParse);

                switch (choice)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        manager.ShowFaults(index);
                        break;

                    case 2:
                        manager.AddFault(index);
                        break;
                    case 3:
                        manager.RemoveFault(index);
                        break;
                    case 4:
                        manager.UpdateFault(index);
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static void CloseMenu(CarManager manager)
        {
            Console.WriteLine("Сохранить перед выходом?");
            int choice = ReadClass.ReadValueWithCondition<int>("1 - да | 2 - нет: ", int.TryParse, x => x >= 1 && x <= 2, "Не правильный вариант меню, попробуйте снова: ");
            switch (choice)
            {
                case 1:
                    manager.SaveToFile();
                    break;
                case 2:
                    break;
            }

        }
    }
}
