using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Commands
{
    public class DeleteIngredientCommand
    {
        public int FormulaId { get; set; }
        public int MaterialId { get; set; }
    }

    public class DeleteIngredientCommandHandler
    {
        private readonly IDataAccess access;

        public DeleteIngredientCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(DeleteIngredientCommand command)
        {
            access.DeleteIngredient(command.FormulaId, command.MaterialId);
        }
    }
}
