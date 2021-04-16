using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Commands
{
    public class UpdateMaterialCommand
    {
        public int Id { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateMaterialCommandHandler
    {
        private readonly IDataAccess access;

        public UpdateMaterialCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(UpdateMaterialCommand command)
        {
            access.UpdateMaterial(new()
            {
                Id = command.Id,
                InciName = command.InciName,
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            });
        }
    }

}
