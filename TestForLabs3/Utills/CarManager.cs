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

    }
}
