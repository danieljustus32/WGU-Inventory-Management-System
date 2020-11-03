using System;
using System.Collections.Generic;
using System.Text;

namespace C968_PA_Task
{
    public class Inhouse : Part
    {
        private int MachineID { get; set; }

        public Inhouse(int ID, string name, decimal price, int inStock, int min, int max, int machineID) : base(ID, name, price, inStock, min, max)
        {
            MachineID = machineID;
        }
    }
}
