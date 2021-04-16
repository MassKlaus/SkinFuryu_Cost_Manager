using SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries;
using SkinFuryu.CostManager.UIFront.Commands;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.ViewModels.Materials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkinFuryu.CostManager.UIFront.ViewModels
{
    public class FormulariesCreationViewModel : BaseViewModel
    {
        public FormulariesCreationViewModel()
        {
            try
            {
                Materials = new(new GetAllMaterialsQueryHandler(IoC.DataAccess).Handle().Select(x => MaterialCheckListItemViewModel.Map(x)).OrderBy(x => x.Name));
            }
            catch (Exception)
            {
                Materials = new();
            }

            CreateFormularyCommand = new ProxyCommand(CreateFormulary);
        }

        public ObservableCollection<MaterialCheckListItemViewModel> Materials { get; set; }

        public ICommand CreateFormularyCommand { get; set; }

        public string Client { get; set; }

        public string Name { get; set; }

        public string SkinType { get; set; }

        public string Texture { get; set; }

        public string Description { get; set; }

        public string Procedure { get; set; }

        public double BatchSize { get; set; }

        public double Ph { get; set; }

        public void CreateFormulary()
        {
            if (Validate())
            {
                int formulaId = new CreateFormulaCommandHandler(IoC.DataAccess).Handle(new()
                {
                    Name = Name,
                    Client = Client,
                    Description = Description,
                    Size = BatchSize,
                    Ph = Ph,
                    Texture = Texture,
                    SkinType = SkinType,
                    Procedure = Procedure
                });

                foreach (var material in Materials.Where(x => x.Selected == true))
                {
                    new CreateIngredientCommandHandler(IoC.DataAccess).Handle(new()
                    {
                        FormulaId = formulaId,
                        MaterialId = material.Id,
                        Phase = string.Empty,
                        Percentage = 0
                    });
                }

                ClearInput();
                return;
            }

            IoC.UI.ShowMessage(new() { Message = "Make Sure the Name Field is filled!", Title = "Incomplete" });
        }

        private void ClearInput()
        {
            Name = string.Empty;
            Client = string.Empty;
            Description = string.Empty;
            BatchSize = 0;
            Ph = 0;
            Texture = string.Empty;
            SkinType = string.Empty;
            Procedure = string.Empty;
        }

        private bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
