
using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Commands
{
    public class CreateIngredientCommand
    {
        public int MaterialId { get; set; }
        public int FormulaId { get; set; }
        public string Phase { get; set; }
        public double Percentage { get; set; }
    }

    public class CreateIngredientCommandHandler
    {
        private readonly IDataAccess access;

        public CreateIngredientCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(CreateIngredientCommand command)
        {
            access.CreateIngredient(new()
            {
                FormulaId = command.FormulaId,
                MaterialId = command.MaterialId,
                Phase = command.Phase,
                Percentage = command.Percentage
            });
        }
    }
}
