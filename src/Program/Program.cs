﻿//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static List<Product> productCatalog = new List<Product>();
        private static List<Equipment> equipmentCatalog = new List<Equipment>();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = CreateCoffeeRecipe();
            
            IPrinter printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);

            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
        }

        private static Recipe CreateCoffeeRecipe()
        {
            Recipe recipe = Recipe.CreateRecipe(GetProduct("Café con leche"));
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));
            return recipe;
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product GetProduct(string description)
        {
            return productCatalog.FirstOrDefault(product => product.Description == description);
        }

        private static Equipment GetEquipment(string description)
        {
            return equipmentCatalog.FirstOrDefault(equipment => equipment.Description == description);
        }
    }
}
