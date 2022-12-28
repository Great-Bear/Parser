using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models.BaseClasses
{
    // Этот базовый класс я создал для возможности расширения приложения в будущем
    // Как например можно будет создать приложение для парсинга разных сайтов, и создать подписки, в зависимости от подписки
    // давать доступ к разным объектам классов

    public class BaseParser
    {
        protected CarCatContext _context;
        public BaseParser(CarCatContext context)
        {
            _context = context;
        }
    }
}
