using SkinFuryu.CostManager.ApplicationLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Commands
{
    public class DeleteFormulaCommand
    {
        public int Id { get; set; }
    }

    public class DeleteFormulaCommandHandler
    {
        private readonly IDataAccess access;

        public DeleteFormulaCommandHandler(IDataAccess access)
        {
            this.access = access;
        }

        public void Handle(DeleteFormulaCommand command)
        {
            access.DeleteAllFormulaIngredients(command.Id);
            access.DeleteFormula(command.Id);
        }
    }
}
