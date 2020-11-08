using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace C968_PA_Task
{
    class Inventory
    {
        public static BindingList<Product> products = new BindingList<Product>();
        public static BindingList<Part> allParts = new BindingList<Part>();

        public Inventory()
        {

        }
        
        public static void addProduct(Product productToAdd)
        {
            products.Add(productToAdd);
        }

        public static bool removeProduct(int ProductID)
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

        public static Product lookupProduct(int ProductID)
        {
            Product foundProduct = null;
            foreach (var product in products)
            {
                if (product.ProductID == ProductID)
                {
                    foundProduct = product;
                }
            }
            return foundProduct;
        }

        public static void updateProduct(int ProductID, Product productToModify)
        {

        }

        public static void addPart(Part partToAdd)
        {
            if (lookupPart(partToAdd.PartID) == null)
            {
                allParts.Add(partToAdd);
            }
        }

        public static bool deletePart(Part partToDelete)
        {
            bool deleted = false;
            for (int i = 0; i < allParts.Count; i++)
            {
                if (allParts[i].PartID == partToDelete.PartID)
                {
                    allParts.Remove(allParts[i]);
                    deleted = true;
                }
            }
            return deleted;
        }

        public static Part lookupPart(int PartID)
        {
            Part foundPart = null;
            foreach (var part in allParts)
            {
                if (Regex.Match(part.PartID.ToString(), $"{PartID}").Success)
                {
                    foundPart = part;
                    break;
                }
            }
            return foundPart;
        }

        public static void updatePart(int PartID, Part partToUpdate)
        {
           for(int i = 0; i < allParts.Count; i++)
            { 
                if (allParts[i].PartID == PartID)
                {
                    allParts[i] = partToUpdate;
                    return;
                }
            }
        }
    }
}
