using SkinFuryu.CostManager.Domain.Interfaces;

namespace SkinFuryu.CostManager.Domain.Models
{
    public class Formula : IHasId
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Name { get; set; }
        public string Texture { get; set; }
        public string SkinType { get; set; }
        public string Description { get; set; }
        public string Procedure { get; set; }
        public double Ph { get; set; }
        public double Size { get; set; }
    }
}
