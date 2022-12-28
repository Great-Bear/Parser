using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models.Interfaces
{
    // Интерфейс был создан для унификации работы с парсерами если в приложение будут добавляться новые реализации

    public interface IParser
    {
        public ICollection<Car> ParseCar(string linkToPage)
        {
            throw new NotImplementedException();
        }
        public Task ParseConfiguration(string linkToPage, Car car)
        {
            throw new NotImplementedException();
        }
    }
}
