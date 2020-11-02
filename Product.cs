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

        private bool removeAssociatedPart(int PartID)
        {
            var deleted = false;
            foreach (var part in associatedParts)
            {
                if (part.PartID == PartID)
                {
                    associatedParts.Remove(part);
                    deleted = true;
                }
            }
            return deleted;
        }

        private Part lookupAssociatedPart(int PartID)
        {
            Part foundPart = new Inhouse();
            foreach (var part in associatedParts)
            {
                if (part.PartID == PartID)
                {
                    foundPart = part;
                }
            }
            return foundPart;
        }
    }
}
