using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace C968_PA_Task
{
    class Product
    {
        public BindingList<Part> associatedParts;
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        private void addAssociatedPart(Part partToAdd)
        {
            associatedParts.Add(partToAdd);
        }

        private static bool removeAssociatedPart(int PartID)
        {
            return true;
        }

        // private static Part lookupAssociatedPart(int PartID)
        // {
           
        // }
    }
}
