using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Commands
{
    public class UpdateIngredientCommand
    {
        public int MaterialId { get; set; }
        public int FormulaId { get; set; }

        public string Phase { get; set; }
        public double Percentage { get; set; }
    }

    public class UpdateIngredientCommandHandler
    {
        private readonly IDataAccess access;

        public UpdateIngredientCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(UpdateIngredientCommand command)
        {
            access.UpdateIngredient(new()
            {
                MaterialId = command.MaterialId,
                FormulaId = command.FormulaId,
                Phase = command.Phase,
                Percentage = command.Percentage
            });
        }
    }

}
