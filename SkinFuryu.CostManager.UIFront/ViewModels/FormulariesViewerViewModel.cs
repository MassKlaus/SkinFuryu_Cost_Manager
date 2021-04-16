using SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Formularies.Queries;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Ingredients.Queries;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.ViewModels.Forumularies;
using SkinFuryu.CostManager.UIFront.ViewModels.Ingredients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkinFuryu.CostManager.UIFront.ViewModels
{
    public class FormulariesViewerViewModel : BaseViewModel
    {
        public FormularyItemViewModel Formula { get; set; }
        public ObservableCollection<FormularyItemViewModel> Formularies { get; set; }

        public FormulariesViewerViewModel()
        {
            try
            {
                Formularies = new(new GetAllFormulariesQueryHandler(IoC.DataAccess).Handle().Select(x => FormularyItemViewModel.Map(x)));

                foreach (var formula in Formularies)
                {
                    formula.Cost = new GetAllIngredientsQueryHandler(IoC.DataAccess).Handle(new() { FormulaId = formula.Id }).Select(x => IngredientItemViewModel.Map(x, formula.BatchSize)).Sum(x => x.Cost);

                    formula.PropertyChanged += Formula_PropertyChanged;
                }
            }
            catch (Exception)
            {
                Formularies = new();
            }

            Formularies.CollectionChanged += Formularies_CollectionChanged;
        }

        private void Formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is FormularyItemViewModel formulary)
            {
                new UpdateFormulaCommandHandler(IoC.DataAccess).Handle(new()
                {
                    Id = formulary.Id,
                    Client = formulary.Client,
                    Name = formulary.Name,
                    Procedure = formulary.Procedure,
                    SkinType = formulary.SkinType,
                    Texture = formulary.Texture,
                    Description = formulary.Description,
                    Ph = formulary.Ph,
                    Size = formulary.BatchSize
                });
            }
        }

        private void Formularies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    var formulaRemoved = (e.OldItems[0] as FormularyItemViewModel);
                    new DeleteFormulaCommandHandler(IoC.DataAccess).Handle(new()
                    {
                        Id = formulaRemoved.Id
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
