namespace SkinFuryu.CostManager.ApplicationLayer.Models
{
    public class IngredientReport
    {
        public string Phase { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Percentage { get; set; }
        public double Quantity { get; set; }
        public decimal Pricing { get; set; }
        public decimal Cost { get; set; }
    }
}