using SkinFuryu.CostManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.Domain.Models
{
    public class Material : IHasId
    {
        public int Id { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
