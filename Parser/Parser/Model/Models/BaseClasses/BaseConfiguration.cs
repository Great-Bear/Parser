using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Этот класс используется для создания объектов конфигурации
// чтобы не дублировать повторяющийся код и не привязываться к конкретным реализациям объектов конфигурации
// и также чтобы обеспечить атомарность данных

// Индекс я создал на поле Value, потому что при добавлении нового значения конфигурации нужно проверить есть ли оно в БД
// и не будет ли дублироваться информация


namespace Parser.Model.Models.BaseClasses
{
    [Index(nameof(Value), IsUnique = true)]
    public class BaseConfiguration
    {
        public BaseConfiguration()
        {

        }
        public BaseConfiguration(string value)
        {
            Value = value;
        }

        public Guid Id { get; set; }

        public string? Value { get; set; }

        public ICollection<Configuration_Car> Configuration_Cars { get; set; }
    }
}
