using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interface
{
    public interface IDataAccess
    {
        #region Get

        public IEnumerable<Material> GetAllMaterials();
        public IEnumerable<Formula> GetAllFormularies();
        public IEnumerable<Ingredient> GetAllIngredients();

        #endregion

        #region GetSpecific

        public Formula GetSpecificFormula(int id);
        public Material GetSpecificMaterial(int id);
        public Ingredient GetSpecificIngredient(int Formulaid, int MaterialId);

        #endregion

        #region Create

        public int CreateMaterial(Material material);
        public int CreateFormula(Formula formula);
        public void CreateIngredient(Ingredient ingredient);
        #endregion

        #region Update

        public void UpdateMaterial(Material material);
        public void UpdateFormula(Formula formula);
        public void UpdateIngredient(Ingredient ingredient);

        #endregion

        #region Delete

        public void DeleteMaterial(int id);
        public void DeleteFormula(int id);
        public void DeleteIngredient(int formulaId, int materialId);
        public void DeleteAllMaterialIngredients(int materialId);
        public void DeleteAllFormulaIngredients(int formulaId);

        #endregion
    }
}
