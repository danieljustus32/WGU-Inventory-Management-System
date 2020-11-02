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
            var deleted = false;
            foreach(var product in products)
            {
                if (product.ProductID == ProductID)
                {
                    products.Remove(product);
                    deleted = true;
                }
            }
            return deleted;
        }

        private Product lookupProduct(int ProductID)
        {
            Product foundProduct = new Product();
            foreach (var product in products)
            {
                if (product.ProductID == ProductID)
                {
                    foundProduct = product;
                }
            }
            return foundProduct;
        }

        private void updateProduct(int ProductID, Product productToModify)
        {

        }

        private void addPart(Part partToAdd)
        {
            allParts.Add(partToAdd);
        }

        private bool deletePart(Part partToDelete)
        {
            bool deleted = false;
            foreach (var part in allParts)
            {
                if (part.PartID == partToDelete.PartID)
                {
                    allParts.Remove(part);
                    deleted = true;
                }
            }
            return deleted;
        }

        private Part lookupPart(int PartID)
        {
            Part foundPart = new Inhouse();
            foreach (var part in allParts)
            {
                if (part.PartID == PartID)
                {
                    foundPart = part;
                }
            }
            return foundPart;
        }

        private void updatePart(int PartID, Part partToUpdate)
        {
           
        }
    }
}
