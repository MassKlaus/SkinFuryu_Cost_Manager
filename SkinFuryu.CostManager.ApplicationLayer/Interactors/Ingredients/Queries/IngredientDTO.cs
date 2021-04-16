using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries
{
    public class IngredientDTO
    {
        public int MaterialId { get; set; }
        public int FormulaId { get; set; }
        public string Phase { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Percentage { get; set; }
        public decimal Pricing { get; set; }

        public static IngredientDTO Map(Ingredient x, Material y)
        {
            return new()
            {
                MaterialId = x.MaterialId,
                FormulaId = x.FormulaId,
                Phase = x.Phase,
                InciName = y.InciName,
                Name = y.Name,
                Description = y.Description,
                Percentage = x.Percentage,
                Pricing = y.Price
            };
        }
    }
}
