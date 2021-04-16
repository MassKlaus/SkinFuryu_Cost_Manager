using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Commands;
using SkinFuryu.CostManager.ApplicationLayer.Interactors.Materials.Queries;
using SkinFuryu.CostManager.Domain.Models;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.ViewModels.Materials
{
    public class MaterialItemViewModel : BaseViewModel
    {
        #region Public Properties

        public int Id { get; set; }
        public string InciName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        #endregion

        public static MaterialItemViewModel Map(MaterialDTO material)
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
