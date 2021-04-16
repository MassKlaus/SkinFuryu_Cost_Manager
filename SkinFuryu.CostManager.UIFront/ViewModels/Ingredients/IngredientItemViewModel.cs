using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries;
using SkinFuryu.CostManager.Domain.Models;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.ViewModels.Ingredients
{
    public class IngredientItemViewModel : BaseViewModel
    {
        public double TotalBatch { get; set; }
        public decimal Pricing { get; set; }
        
        
        public int FormulaId { get; set; }
        public int MaterialId { get; set; }

        public string Phase { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Percentage { get; set; }

        public double Quantity => TotalBatch * Percentage;
        public decimal Cost => (decimal)Quantity * Pricing;


        public static IngredientItemViewModel Map(IngredientDTO x, double total)
        {
            return new()
            {
                FormulaId = x.FormulaId,
                MaterialId = x.MaterialId,

                Phase = x.Phase,
                Name = x.Name,
                Description = x.Description,
                Percentage = x.Percentage,

                Pricing = x.Pricing,
                TotalBatch = total
            };
        }
    }
}
