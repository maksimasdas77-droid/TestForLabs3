using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            CarManager manager = new CarManager();
            manager.LoadFromFile(); 
            bool running = true;
            while (running)
            {
                MenuClass.ShowMainMenu();
                int choice = ReadClass.ReadValue<int>(int.TryParse);
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("завершение программы");
                        MenuClass.CloseMenu(manager);
                        running = false;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("======Список автомобилей======");
                        //manager.ShowAllCars();
                        manager.ShowCars();
                        int carIndex = ReadClass.ReadValueWithCondition<int>("Выберите автомобиль(0 - возврат в основное меню): ", int.TryParse, value => value >= 0 && value <= manager.Cars.Count, "Некорректный ввод, попробуйте снова: ");
                        if (carIndex == 0) break;
                        MenuClass.ShowUnderMenu(manager, carIndex-1);
                        break;
                    case 2:
                        Console.Clear();
                        Car newCar = CodeWrapper.AddCar();
                        manager.AddCar(newCar);
                        Console.WriteLine("Автомобиль успешно добавлен.");
                        Console.ReadLine();

                        break;

                    case 3:
                        Console.Clear();
                        manager.ShowCars();
                        int index = CodeWrapper.RemoveCar(manager.Cars);
                        if (index == 0) break;
                        manager.RemoveCar(index);
                        break;

                    case 4:
                        Console.Clear();
                        manager.ShowCars();
                        
                        //index = ReadClass.ReadValueWithCondition<int>("Введите номер машины для изменения: ", int.TryParse, value => value >= 1 && value <= manager.Cars.Count, "Не корректный ввод, попробуйите снова: ");
                        var result = CodeWrapper.UpdateCar(manager.Cars);
                        if (result.UpdateCar != null)
                        {
                            manager.UpdateCar(result.index, result.UpdateCar);
                        }
                        break;

                    case 5:
                        Console.Clear();

                        break;

                    case 6:
                        Console.Clear();

                        break;

                    default:
                        Console.WriteLine("Не правильный пункт меню.");
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
