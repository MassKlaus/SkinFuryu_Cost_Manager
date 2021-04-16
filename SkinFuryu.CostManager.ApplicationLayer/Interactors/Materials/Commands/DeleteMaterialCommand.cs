using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Commands
{
    public class DeleteMaterialCommand
    {
        public int Id { get; set; }
    }

    public class DeleteMaterialCommandHandler
    {
        private readonly IDataAccess access;

        public DeleteMaterialCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(DeleteMaterialCommand command)
        {
            access.DeleteAllMaterialIngredients(command.Id);
            access.DeleteMaterial(command.Id);
        }
    }
}
