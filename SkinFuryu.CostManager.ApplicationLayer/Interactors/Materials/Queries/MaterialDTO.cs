using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static MaterialDTO Map(Material x)
        {
            return new()
            {
                Id = x.Id,
                InciName = x.InciName,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            };
        }
    }
}
