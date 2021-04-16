using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Queries
{
    public class FormulaDTO
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

        public static FormulaDTO Map(Formula x)
        {
            return new()
            {
                Id = x.Id,
                Client = x.Client,
                Name = x.Name,
                Description = x.Description,
                Size = x.Size,
                Procedure = x.Procedure,
                Ph = x.Ph,
                SkinType = x.SkinType,
                Texture = x.Texture
            };
        }
    }
}
