using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Queries
{
    public class GetAllFormulariesQuery
    {
        
    }

    public class GetAllFormulariesQueryHandler
    {
        private readonly IDataAccess access;

        public GetAllFormulariesQueryHandler(IDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<FormulaDTO> Handle()
        {
            IEnumerable<Material> materials = access.GetAllMaterials();
            return access.GetAllFormularies().Select(x => FormulaDTO.Map(x));
        }
    }
}
