using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries
{
    public class GetAllIngredientsQuery
    {
        public int FormulaId { get; set; }
    }

    public class GetAllIngredientsQueryHandler
    {
        private readonly IDataAccess access;

        public GetAllIngredientsQueryHandler(IDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<IngredientDTO> Handle(GetAllIngredientsQuery query)
        {
            IEnumerable<Material> materials = access.GetAllMaterials();
            return access.GetAllIngredients().Where(x => x.FormulaId == query.FormulaId).Select(x => IngredientDTO.Map(x, materials.First(y => y.Id == x.MaterialId)));
        }
    }
}
