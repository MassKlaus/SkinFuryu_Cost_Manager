using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Models
{
    public class FormulaReport
    {
        public string Name { get; set; }
        public string SkinType { get; set; }
        public string Description { get; set; }
        public string Texture { get; set; }
        public double BatchSize { get; set; }
        public double PhLevel { get; set; }
        public string Client { get; set; }

        public string Procedure { get; set; }

        public List<IngredientReport> Ingredients { get; set; } = new();
    }
}
