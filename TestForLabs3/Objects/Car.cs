using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs3
{
    [Serializable] //обозначение для сериализатора что можно данные записывать по байтам
    internal class Car
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public string Owner { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public List<Fault> Faults { get; set; }

        public string ToPrettyString()
        {
            return
                $"Название: {Name}\n" +
                $"Гос. номер: {Number}\n" +
                $"Год выпуска: {Year}\n" +
                $"Владелец: {Owner}\n" +
                $"Создано: {CreatedAt:dd.MM.yyyy HH:mm}\n" +
                $"Обновлено: {LastUpdatedAt:dd.MM.yyyy HH:mm}";
        }
    }
}
