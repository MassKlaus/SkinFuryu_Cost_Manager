using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Commands
{
    public class CreateMaterialCommand
    {
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateMaterialCommandHandler
    {
        private readonly IDataAccess access;

        public CreateMaterialCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public int Handle(CreateMaterialCommand command)
        {
            return access.CreateMaterial(new()
            {
                InciName = command.InciName,
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            });
        }
    }
}
