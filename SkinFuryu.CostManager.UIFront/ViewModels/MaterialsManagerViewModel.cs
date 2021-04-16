using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Commands;
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
    public class MaterialsManagerViewModel : BaseViewModel
    {
        #region Public Collections

        public ObservableCollection<MaterialItemViewModel> Materials { get; set; }

        #endregion

        #region Constructor

        public MaterialsManagerViewModel()
        {
            //Necessary for Design Time View
            try
            {
                Materials = new ObservableCollection<MaterialItemViewModel>(new GetAllMaterialsQueryHandler(IoC.DataAccess).Handle().Select(x => MaterialItemViewModel.Map(x)));
            }
            catch (Exception)
            {
                Materials = new ObservableCollection<MaterialItemViewModel>();
            }

            foreach (var material in Materials)
            {
                material.PropertyChanged += MaterialUpdated;
            }

            SortMaterials();
            AddMaterialCommand = new ProxyCommand(AddMaterial);
        }

        #endregion

        #region Events

        private void MaterialUpdated(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is MaterialItemViewModel material)
            {
                new UpdateMaterialCommandHandler(IoC.DataAccess).Handle(new()
                {
                    Id = material.Id,
                    InciName = material.InciName,
                    Name = material.Name,
                    Description = material.Description,
                    Price = material.Price
                });

                SortMaterials();
            }
        }

        private void Materials_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var material = (e.NewItems[0] as MaterialItemViewModel);
                    material.Id = new CreateMaterialCommandHandler(IoC.DataAccess).Handle(
                        new()
                        {
                            Name = material.Name,
                            InciName = material.InciName,
                            Description = material.Description,
                            Price = material.Price
                        });
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    new DeleteMaterialCommandHandler(IoC.DataAccess).Handle(new() { Id = (e.OldItems[0] as MaterialItemViewModel).Id });
                    break;

                default:
                    break;
            }

            SortMaterials();
        }

        #endregion

        #region Public Properties

        public ICommand AddMaterialCommand { get; set; }

        public string InciName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        #endregion

        public void AddMaterial()
        {
            if (!ValidateData())
            {
                IoC.UI.ShowMessage(new() { Title = "Data Error", Message = "Name And InciName Cannot be Empty" });
                return;
            }

            Materials.Add(new()
            {
                InciName = InciName,
                Name = Name,
                Description = Description,
                Price = Price
            });

            ClearInput();
        }

        #region Utility

        public bool ValidateData()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(InciName);
        }

        private void SortMaterials()
        {
            Materials = new(Materials.OrderBy(x => x.InciName));
            Materials.CollectionChanged += Materials_CollectionChanged;
        }

        private void ClearInput()
        {
            InciName = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
        }

        #endregion
    }
}
