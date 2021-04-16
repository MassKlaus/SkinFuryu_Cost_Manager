using SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Queries;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Printing;
using SkinFuryu.CostManager.UIFront.Commands;
using SkinFuryu.CostManager.UIFront.DataModels;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.ViewModels.Ingredients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkinFuryu.CostManager.UIFront.ViewModels.Forumularies
{
    public class FormularyItemViewModel : BaseViewModel
    {
        #region Public Properties

        public FormularyItemViewModel()
        {
            Open = new ProxyCommand(OpenFormula);
            Print = new ProxyCommand(async () => await PrintFormula());
        }

        private async Task PrintFormula()
        {
            try
            {
                await Task.Run(() =>
                new PrintCommandHandler(IoC.DataAccess, IoC.FormulaPrinter).Handle(new PrintCommand
                {
                    FormulaId = this.Id
                }));

                await IoC.UI.ShowMessage(new MessageBoxViewModel { Message = "Formula Printed!", Title = "Completed" });
            }
            catch (Exception ex)
            {
                await IoC.UI.ShowMessage(new MessageBoxViewModel { Message = ex.Message, Title = "Error During Printing" });
            }
        }

        private void OpenFormula()
        {
            IoC.Application.GotoPage(ApplicationPage.FormularyIngredients, new FormularyIngredientsManagerViewModel(this));
        }

        public int Id { get; set; }

        public string Client { get; set; }

        public string Name { get; set; }

        public string SkinType { get; set; }

        public string Texture { get; set; }

        public string Description { get; set; }

        public string Procedure { get; set; }

        public double BatchSize { get; set; }

        public double Ph { get; set; }

        public decimal Cost { get; set; }

        public decimal Price => Cost * 2;

        public ICommand Open { get; set; }

        public ICommand Print { get; set; }

        #endregion

        public static FormularyItemViewModel Map(FormulaDTO x)
        {
            return new FormularyItemViewModel
            {
                Id = x.Id,
                Client = x.Client,
                Name = x.Name,
                Description = x.Description,
                BatchSize = x.Size,
                Texture = x.Texture,
                SkinType = x.SkinType,
                Ph = x.Ph,
                Procedure = x.Procedure,
            };
        }
    }
}
