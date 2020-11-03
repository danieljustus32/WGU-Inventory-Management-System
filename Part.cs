using System;
using System.Collections.Generic;
using System.Text;

namespace C968_PA_Task
{
    public abstract class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }


        public Part(int ID, string name, decimal price, int inStock, int min, int max)
        {
            PartID = ID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }
    }
}
