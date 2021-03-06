﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace C968_PA_Task
{
    public class Product
    {
        public BindingList<Part> associatedParts;
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public Product(int ID, string name, decimal price, int inStock, int min, int max)
        {
            associatedParts = new BindingList<Part>();
            ProductID = ID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public void addAssociatedPart(Part partToAdd)
        {
            associatedParts.Add(partToAdd);
        }

        public bool removeAssociatedPart(int PartID)
        {
            var deleted = false;
            for (int i = 0; i < associatedParts.Count; i++)
            {
                if (associatedParts[i].PartID == PartID)
                {
                    associatedParts.Remove(associatedParts[i]);
                    deleted = true;
                }
            }
            return deleted;
        }

        public Part lookupAssociatedPart(int PartID)
        {
            // Return null if not found so we can check if parts exist when calling from other classes
            Part foundPart = null;
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
