using System;
using System.Collections.Generic;
using System.Text;

namespace C968_PA_Task
{
    public class Outsourced : Part
    { 
        private string CompanyName { get; set; }

        public Outsourced(int ID, string name, decimal price, int inStock, int min, int max, string companyName) : base(ID, name, price, inStock, min, max)
        {
            CompanyName = companyName;
        }
    }
}
