namespace SkinFuryu.CostManager.Domain.Models
{
    public class Ingredient
    {
        public int FormulaId { get; set; }
        public int MaterialId { get; set; }

        public string Phase { get; set; }
        public double Percentage { get; set; }
    }
}
