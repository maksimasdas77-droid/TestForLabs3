using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    internal class CodeWrapper
    {
        public static Car AddCar()
        {
            Console.WriteLine("добавление автомобиля");
            Car newCar = new Car();

            Console.Write("Введите название автомобиля: ");
            newCar.Name = Console.ReadLine();

            Console.Write("Введите гос.номер автомобиля: ");
            newCar.Number = Console.ReadLine();

            newCar.Year = ReadClass.ReadValue<int>("Введите год автомобиля: ", int.TryParse);

            Console.Write("Введите владельца автомобиля: ");
            newCar.Owner = Console.ReadLine();

            return newCar;

        }
        public static int RemoveCar(List<Car> cars)
        {
            int index = ReadClass.ReadValueWithCondition<int>("Введите номер машины для удаления: ", int.TryParse, x => x >= 0 && x <= cars.Count, "Нет такого автомобиля, попробуйте снова: ");

            return index;
        }

        public static (Car UpdateCar, int index) UpdateCar(List<Car> cars)
        {
            if(MyUtills.CheckCars(cars))
            {
                int index = ReadClass.ReadValueWithCondition<int>("Введите номер автомобиля для изменения: ", int.TryParse, value => value >= 0 && value <= cars.Count, "Нет такой машины. Попробуйте снова: ");
                if (index == 0)
                {
                    return (null, -1);
                }
                Console.WriteLine("Редактирование автомобиля (ввод пустого значения для оставления без изменений)");
                Car oldCar = cars[index - 1]; //старый автомобиль
                Car newCar = new Car(); //новый автомобиль

                Console.Write($"Введите новое название автомобиля ({oldCar.Name}): ");
                string nametemp = Console.ReadLine();
                newCar.Name = string.IsNullOrWhiteSpace(nametemp) ? oldCar.Name : nametemp;

                Console.Write($"Введите новый гос.номер автомобиля ({oldCar.Number}): ");
                string numbertemp = Console.ReadLine();
                newCar.Number = string.IsNullOrWhiteSpace(numbertemp) ? oldCar.Number : numbertemp;

                Console.Write($"Введите новый год автомобиля ({oldCar.Year}): ");
                string yeartemp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(yeartemp))
                {
                    newCar.Year = oldCar.Year;
                }
                else
                {
                    newCar.Year = ReadClass.ParseOrRetry<int>(yeartemp, int.TryParse, "Не праавильный ввод, попробуйте снова: ");
                }

                Console.Write($"Введите нового владельца автомобиля ({oldCar.Owner}): ");
                string ownertemp = Console.ReadLine();

                newCar.Owner = string.IsNullOrWhiteSpace(ownertemp) ? oldCar.Owner : ownertemp;

                return (UpdateCar: newCar, index: index);
            }
            return (null, -1); //что бы не жаловался компилятор, в теории до сюда не дойдем
        }


    }
}
