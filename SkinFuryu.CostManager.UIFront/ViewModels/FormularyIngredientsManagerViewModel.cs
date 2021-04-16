using SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries;
using SkinFuryu.CostManager.UIFront.Commands;
using SkinFuryu.CostManager.UIFront.DataModels;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.ViewModels.Forumularies;
using SkinFuryu.CostManager.UIFront.ViewModels.Ingredients;
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
    public class FormularyIngredientsManagerViewModel : BaseViewModel
    {
        public FormularyIngredientsManagerViewModel()
        {

        }

        public FormularyIngredientsManagerViewModel(FormularyItemViewModel formula)
        {
            Formula = formula;

            try
            {
                Ingredients = new(new GetAllIngredientsQueryHandler(IoC.DataAccess).Handle(new() { FormulaId = formula.Id }).Select(x => IngredientItemViewModel.Map(x, formula.BatchSize)));

                var MaterialsBlackList = Ingredients.Select(x => x.MaterialId);

                Materials = new(new GetAllMaterialsQueryHandler(IoC.DataAccess).Handle().Where(x => !MaterialsBlackList.Contains(x.Id)).Select(x => MaterialItemViewModel.Map(x)));
            }
            catch (Exception)
            {
                Materials = new ObservableCollection<MaterialItemViewModel>();
                Ingredients = new ObservableCollection<IngredientItemViewModel>();
            }

            CreateIngredientCommand = new ProxyCommand(CreateIngredient);
            SaveFormularyDataCommand = new ProxyCommand(SaveFormulary);

            foreach (var ingredient in Ingredients)
            {
                ingredient.PropertyChanged += FormularyIngredientsManagerViewModel_PropertyChanged;
            }

            SortIngredients();
        }

        private void SaveFormulary()
        {
            new UpdateFormulaCommandHandler(IoC.DataAccess).Handle(new()
            {
                Id = Formula.Id,
                Client = Formula.Client,
                Name = Formula.Name,
                Description = Formula.Description,
                Ph = Formula.Ph,
                Procedure = Formula.Procedure,
                Size = Formula.BatchSize,
                SkinType = Formula.SkinType,
                Texture = Formula.Texture
            });

            IoC.Application.GotoPage(ApplicationPage.FormularyIngredients, this);
        }

        private void FormularyIngredientsManagerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is IngredientItemViewModel ingredient)
            {
                new UpdateIngredientCommandHandler(IoC.DataAccess).Handle(new UpdateIngredientCommand()
                {
                    FormulaId = ingredient.FormulaId,
                    MaterialId = ingredient.MaterialId,
                    Phase = ingredient.Phase,
                    Percentage = ingredient.Percentage
                });

            }

            SortIngredients();
        }

        private void Ingredients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var addedIngredient = (e.NewItems[0] as IngredientItemViewModel);
                    new CreateIngredientCommandHandler(IoC.DataAccess).Handle(new()
                    {
                        FormulaId = addedIngredient.FormulaId,
                        MaterialId = addedIngredient.MaterialId,
                        Phase = addedIngredient.Phase,
                        Percentage = addedIngredient.Percentage
                    });
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    var removedIngredient = (e.NewItems[0] as IngredientItemViewModel);
                    new DeleteIngredientCommandHandler(IoC.DataAccess).Handle(new()
                    {
                        FormulaId = removedIngredient.FormulaId,
                        MaterialId = removedIngredient.MaterialId
                    });
                    break;

                default:
                    break;
            }

            SortIngredients();
        }

        public ICommand CreateIngredientCommand { get; set; }
        public ICommand SaveFormularyDataCommand { get; private set; }
        public ObservableCollection<MaterialItemViewModel> Materials { get; set; }
        public ObservableCollection<IngredientItemViewModel> Ingredients { get; set; }

        public string Phase { get; set; }
        public MaterialItemViewModel Material { get; set; }
        public double Percentage { get; set; }

        public FormularyItemViewModel Formula { get; set; }

        public void CreateIngredient()
        {
            if (ValidateData())
            {
                Ingredients.Add(new IngredientItemViewModel
                {
                    FormulaId = Formula.Id,
                    MaterialId = Material.Id,

                    Phase = Phase,
                    Name = Material.Name,
                    Description = Material.Description,
                    Percentage = Percentage,
                    Pricing = Material.Price,
                    TotalBatch = Formula.BatchSize
                });

                Materials.Remove(Material);

                return;
            }

            IoC.UI.ShowMessage(new() { Message = "Make Sure To Select a Material and to Fill In a Phase!", Title = "Incomplete" });
        }

        private bool ValidateData()
        {
            return !string.IsNullOrWhiteSpace(Phase) && Material is not null;
        }

        private void SortIngredients()
        {
            Ingredients = new(Ingredients.OrderBy(x => x.Phase));
            Ingredients.CollectionChanged += Ingredients_CollectionChanged;
        }
    }
}
