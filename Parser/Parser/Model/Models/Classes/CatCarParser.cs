using AngleSharp.Dom;
using Parser.Model.Models.BaseClasses;
using Parser.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models.Classes
{
    // enums были созданы чтобы не было магических чисел
    public enum FieldCar
    {
        Code,
        Name,
        DateCreation,
    }
    public enum FieldConfig
    {
        Code,
        Engine,
        DateCreation,
        SpecificationItems
    }

    // Эти свойства мне нужны чтобы во время парсинга конфигураций
    // можно было по имени значения взятое с сайта обращаться к правильной таблице в БД
    // чтобы проверить есть ли такое значение уже или создать новое

    // P.S.
    // Уже при просмотре проекта я заметил что такое решение не очень хорошее, потому что эти свойства прямо вызываются в
    // CarCarContext а значит для каждого сайта нужно писать отдельный контекст

    public static class NameTableFromSite
    {
        public readonly static string Body = "BODY:";
        public readonly static string FuelInduction = "FUEL INDUCTION:";
        public readonly static string BuildingCondition = "BUILDING CONDITION:";
        public readonly static string Grade = "GRADE:";
        public readonly static string ATM_MTM = "ATM,MTM:";
        public readonly static string GearShiftType = "GEAR SHIFT TYPE:";
        public readonly static string Cab = "CAB:";
        public readonly static string TransmissionModel = "TRANSMISSION MODEL:";
        public readonly static string LoadingCapacity = "LOADING CAPACITY:";
        public readonly static string RearTire = "REAR TIRE:";
        public readonly static string Destination = "DESTINATION:";
    }


    public class CatCarParser : BaseParser, IParser
    {
        public CatCarParser(CarCatContext context) : base(context) { }

        public ICollection<Car> ParseCar(string linkToPage)
        {
            using var doc = StaticParser.StaticParser.LoadPage(linkToPage);

            // Первый элемент tr это названия полей его можно пропустить
            var containerCars = doc.QuerySelectorAll("tr").Skip(1);

            var carList = new List<Car>();
            int index = 0;
            foreach (var containerCar in containerCars)
            {
                // Такое ограничение стоит чтобы не парсить все модели машин
                if (index == 5)
                {
                    return carList;
                }
                index++;

               var itemsCar = containerCar.ChildNodes.GetElementsByClassName("table__td").ToArray();

               var newCar = new Car()
               {
                   Code = itemsCar[(int)FieldCar.Code].Text(),
                   Name = itemsCar[(int)FieldCar.Name].Text(),
                   DateCreation = itemsCar[(int)FieldCar.DateCreation].Text(),
                   LinkToConfig = containerCar.QuerySelector("a").Attributes["href"].Text()
               };
               carList.Add(newCar);
            }
            return carList;
        }

        public async Task ParseConfiguration(string linkToPage, Car car)
        {
            using var doc = StaticParser.StaticParser.LoadPage(linkToPage);

            // Первый элемент tr это названия полей его можно пропустить
            var containerConfigs = doc.GetElementsByClassName("table").First().QuerySelectorAll("tr").Skip(1);

            car.Configuration_Cars = new List<Configuration_Car?>();

            foreach (var containerConfig in containerConfigs)
            {
               var itemConfig = containerConfig.ChildNodes.GetElementsByClassName("table__td").ToArray();

               // На сайте данные конфигурации разделены тегом перехода на новую строку <br>
               // На платформе Windows это будет как \n
               // Его я использую для получения строки ключ значение
               string[] specificationItems = itemConfig[(int)FieldConfig.SpecificationItems].Text().Split('\n');

               var newConfig = new Configuration_Car()
               {
                   Code = itemConfig[(int)FieldConfig.Code].Text(),
                   Engine = itemConfig[(int)FieldConfig.Engine].Text(),
                   DateCreation = itemConfig[(int)FieldConfig.DateCreation].Text()
               };

               car.Configuration_Cars.Add(newConfig);

                // При получении массива значений его длина будет n + 1, последний элемент будет некорректным
                // Поэтому при итерации массива последний элемент не нужно просматривать
               for (int i = 0; i < specificationItems.Length - 2; i += 2)
               {
                 await CreateConfigObject(newConfig, specificationItems[i], specificationItems[i + 1]);
               }
            }
            return;
        }

        private async Task CreateConfigObject(Configuration_Car config, string? name, string? value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(name))
            {
                return;
            }
            // Строки я обрезаю чтобы при добавлении в БД пробелы до и после не занимали лишнее место
            value = value.Trim();
            name = name.Trim();

            // Тут я беру объект из БД если такого нет то itemDB будет null
            var itemDB = _context.GetConfigObj(value, name);

            // Этот блок кода создаёт новый объект и потом сохраняет его в БД
            if (itemDB == null)
            {
                var newItem = _context.CreateNewDbItem(value, name);
                await CreateNewItemInDb(newItem);
                itemDB = newItem;
            }

            if (itemDB is not null)
            {
                config.AddObjectToConfig(itemDB);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CreateNewItemInDb(BaseConfiguration newObj)
        {
            if (newObj is not null)
            {
                var context = new CarCatContext();
                await context.AddAsync(newObj);
                await context.SaveChangesAsync();
            }
        }
    }
}
