using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries;

namespace SkinFuryu.CostManager.UIFront.ViewModels.Materials
{
    public class MaterialCheckListItemViewModel : MaterialItemViewModel
    {
        public bool Selected { get; set; }

        public static new MaterialCheckListItemViewModel Map(MaterialDTO material)
        {
            return new()
            {
                Id = material.Id,
                InciName = material.InciName,
                Name = material.Name,
                Description = material.Description,
                Price = material.Price,
            };

        }
    }
}
