using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries;
using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interactors.Printing
{
    public class PrintCommand
    {
        public int FormulaId { get; set; }
    }

    public class PrintCommandHandler
    {
        private readonly IDataAccess dataAccess;
        private readonly IFormulaPrinter printer;

        public PrintCommandHandler(IDataAccess dataAccess, IFormulaPrinter printer)
        {
            this.dataAccess = dataAccess;
            this.printer = printer;
        }

        public void Handle(PrintCommand command)
        {
            var formula = dataAccess.GetSpecificFormula(command.FormulaId);
            var ingredients = new GetAllIngredientsQueryHandler(dataAccess).Handle(new() { FormulaId = command.FormulaId });

            FormulaReport formulaReport = new()
            {
                Client = formula.Client ?? string.Empty,
                Name = formula.Name ?? string.Empty,
                Description = formula.Description ?? string.Empty,
                Procedure = formula.Procedure ?? string.Empty,
                Texture = formula.Texture ?? string.Empty,
                SkinType = formula.SkinType ?? string.Empty,
                PhLevel = formula.Ph,
                BatchSize = formula.Size
            };

            foreach (var ingredient in ingredients)
            {
                formulaReport.Ingredients.Add(new()
                {
                    Phase = ingredient.Phase ?? string.Empty,
                    InciName = ingredient.InciName ?? string.Empty,
                    Name = ingredient.Name ?? string.Empty,
                    Description = ingredient.Description ?? string.Empty,
                    Percentage = ingredient.Percentage,
                    Quantity = (formula.Size * ingredient.Percentage),
                    Pricing = ingredient.Pricing,
                    Cost = (decimal)(formula.Size * ingredient.Percentage) * ingredient.Pricing
                });
            }

            printer.PrintFile(formulaReport);
        }
    }
}
