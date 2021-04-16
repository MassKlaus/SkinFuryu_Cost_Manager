using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Commands
{
    public class UpdateFormulaCommand
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

    public class UpdateFormulaCommandHandler
    {
        private readonly IDataAccess access;

        public UpdateFormulaCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(UpdateFormulaCommand command)
        {
            access.UpdateFormula(new()
            {
                Id = command.Id,
                Client = command.Client,
                Name = command.Name,
                Description = command.Description,
                Size = command.Size,
                Ph = command.Ph,
                Procedure = command.Procedure,
                SkinType = command.SkinType,
                Texture = command.Texture
            });
        }
    }

}
