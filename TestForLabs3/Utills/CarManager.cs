using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace TestForLabs3
{
    internal class CarManager
    {
        public List<Car> Cars { get; private set; } = new List<Car>();
        private const string FileName = @"D:\projekts\testforlabs3\cars.bin"; //объявление абсолютного пути к файлу для будущих сохранений в файл и чтения из файла

        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(Cars, Formatting.Indented);
            File.WriteAllText(FileName, json);
            Console.WriteLine("Данные успешно сохранены.");
        }

        public void LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine("Файл не найден");
                return;
            }
            string json = File.ReadAllText(FileName);
            Cars = JsonConvert.DeserializeObject<List<Car>>(json);
            Console.WriteLine("Данные успешно загружены");
        }

        public void ShowCars()
        {
            MyUtills.CheckCars(Cars);
            for (int i = 0; i < Cars.Count; i++)
            {
                Car car = Cars[i];
                Console.WriteLine($"{i + 1}. {car.Name}, {car.Number}, {car.Year} г.в., {car.Owner}");
            }
        }

        public void ShowAllCars()
        {
            MyUtills.CheckCars(Cars);
            for(int i = 0; i < Cars.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                Console.WriteLine(Cars[i].ToPrettyString());
                Console.WriteLine();
            }
        }

        public void AddCar(Car newCar)
        {
            newCar.CreatedAt = DateTime.Now;
            newCar.LastUpdatedAt = DateTime.Now;
            Cars.Add(newCar);
        }

        public void RemoveCar(int index) 
        {
            if(index >= 0 && index <= Cars.Count)
            {
                Cars.RemoveAt(index - 1);
                Console.WriteLine("Автомобиль успешно удален.");
            }
            else
            {
                Console.WriteLine("Такого автомобиля не существует.");
            }
        }
        public void UpdateCar(int index, Car newCar)
        {
            MyUtills.CheckCars(Cars);
            newCar.CreatedAt = Cars[index - 1].CreatedAt;
            newCar.LastUpdatedAt = DateTime.Now;
            Cars[index - 1] = newCar;
        }

        public void AddFault(int index)
        {
            Console.WriteLine("Введите описание неисправности: ");
            string desc = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(desc))
            {
                Console.WriteLine("Описание не должно быть пустым.");
                Console.ReadLine();
                return;
            }
            if (Cars[index].Faults == null)
                Cars[index].Faults = new List<Fault>();
            Cars[index].Faults.Add(new Fault { Description = desc, Date = DateTime.Now, UpdateAt = DateTime.Now });
            Console.WriteLine("Неисправность добавлена.");
            Console.ReadLine();
        }

        public void ShowFaults(int index)
        {
            var faults = Cars[index].Faults;
            if (faults == null || faults.Count == 0)
            {
                Console.WriteLine("Неисправностей нет.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Список неисправностей:");
            for (int i = 0; i < faults.Count; i++)
            {
                Console.WriteLine($"{i + 1}.({faults[i].Date}) {faults[i].Description} | последнее обновление: {faults[i].UpdateAt}");

            }
            Console.ReadLine();
        }

            public void RemoveFault(int index)
        {
            var faults = Cars[index].Faults;
            if (faults == null || faults.Count == 0)
            {
                Console.WriteLine("Неисправностей нет.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Список неисправностей:");

            for(int i = 0; i < faults.Count; i++)
                Console.WriteLine($"{i + 1}. {faults[i].Description} (дата: {faults[i].Date:dd.MM.yyyy HH:mm})");
            Console.Write("Введите номер неисправности для удаления: ");
            int faultIndex = ReadClass.ReadValueWithCondition<int>(int.TryParse, x => x >= 1 && x <= faults.Count, $"Введите число от 1 до {faults.Count}: ");
            faults.RemoveAt(faultIndex - 1);
            Console.WriteLine("Неисправность удалена.");
            Console.ReadLine();
        }
        public void UpdateFault(int carIndex)
        {
            Car car = Cars[carIndex];
            if (car.Faults == null || car.Faults.Count == 0)
            {
                Console.WriteLine("У автомобиля нет неисправностей.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Список неисправностей:");
            for (int i = 0; i < car.Faults.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {car.Faults[i].Description} ({car.Faults[i].Date:d})");
            }
            int faultIndex = ReadClass.ReadValueWithCondition<int>(
             "Введите номер неисправности для изменения (0 - назад): ",
             int.TryParse,
            x => x >= 0 && x <= car.Faults.Count,
            "Некорректный ввод, попробуйте снова: "
            );
            if (faultIndex == 0)
                return;
            faultIndex--;
            Fault oldFault = car.Faults[faultIndex];
            Fault newFault = new Fault();
            Console.Write($"Новое описание ({oldFault.Description}): ");
            string desc = Console.ReadLine();
            newFault.Description = string.IsNullOrWhiteSpace(desc) ? oldFault.Description : desc;

            newFault.Date = oldFault.Date; //дата остается прежней

            newFault.UpdateAt = DateTime.Now; //дата обновления обновляется

            car.Faults[faultIndex] = newFault;

            Console.WriteLine("Неисправность успешно обновлена.");
            Console.ReadLine();
        }
    }
}
