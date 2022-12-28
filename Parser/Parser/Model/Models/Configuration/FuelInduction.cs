using Parser.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Model.Models.Configuration
{
    public class FuelInduction : BaseConfiguration
    {
        public FuelInduction()
        {

        }
        public FuelInduction(string value)
        {
            Value = value;
        }
    }
}
