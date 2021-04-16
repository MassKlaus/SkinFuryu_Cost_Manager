using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries
{
    public class GetAllMaterialsQuery
    {
        
    }

    public class GetAllMaterialsQueryHandler
    {
        private readonly IDataAccess access;

        public GetAllMaterialsQueryHandler(IDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<MaterialDTO> Handle()
        {
            return access.GetAllMaterials().Select(x => MaterialDTO.Map(x));
        }
    }
}
