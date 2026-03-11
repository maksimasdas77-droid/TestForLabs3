using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    internal class MyUtills
    {
        public static bool CheckCars(List<Car> Cars) //вызывать потом MyUtills.CheckCars(Cars);
        {
            if (!Cars.Any())
            {
                Console.WriteLine("Список техники пуст.");
                return false;
            }
            return true;
        }

        


    }
}
