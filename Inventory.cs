using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace C968_PA_Task
{
    class Inventory
    {
        public BindingList<Product> products;
        public BindingList<Part> allParts;

        Inventory()
        {

        }
        
        private void addProduct(Product productToAdd)
        {
            products.Add(productToAdd);
        }

        private bool removeProduct(int ProductID)
        {
            bool found = false;
            foreach(var product in products)
            {
                if (product.ProductID == ProductID)
                {
                    products.Remove(product);
                    found = true;
                } else
                {
                    found = false;
                }
            }
            return found;
        }

        //private static Product lookupProduct(int ProductID)
        //{

        //}

        private void updateProduct(int ProductID, Product productToModify)
        {

        }

        private void addPart(Part partToAdd)
        {
            allParts.Add(partToAdd);
        }

        private bool deletePart(Part partToDelete)
        {
            bool found = false;
            foreach (var part in allParts)
            {
                if (part.PartID == partToDelete.PartID)
                {
                    allParts.Remove(part);
                    found = true;
                }
                else
                {
                    found = false;
                }
            }
            return found;
        }

        //private static Part lookupPart(int PartID)
        //{

        //}

        private static void updatePart(int PartID, Part partToUpdate)
        {

        }
    }
}
