using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_app
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }

        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
        }

        public void Scale(double factor)
        {
            Quantity *= factor;
        }

        public override string ToString()
        {
            return $"{Quantity} {UnitOfMeasurement} of {Name}";
        }
    }
}

