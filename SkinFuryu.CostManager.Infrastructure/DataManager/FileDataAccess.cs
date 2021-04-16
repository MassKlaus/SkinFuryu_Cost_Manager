using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.Domain.Interfaces;
using SkinFuryu.CostManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SkinFuryu.CostManager.Infrastructure.Helpers;

namespace SkinFuryu.CostManager.Infrastructure.DataManager
{
    public class FileDataAccess : IDataAccess
    {
        #region Singelton

        public static FileDataAccess Instance => new();

        #endregion

        #region Private

        private readonly object WritingOnGoing = new();

        private const string Saves = "./Saves";
        private const string FormulariesFile = "/Formularies.json";
        private const string IngredientsFile = "/Ingredients.json";
        private const string MaterialsFile = "/Materials.json";

        private ObservableCollection<Formula> formularies;
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Material> materials;

        #endregion

        #region Constructors

        private FileDataAccess()
        {
            if (!Directory.Exists(Saves))
            {
                Directory.CreateDirectory(Saves);
            }

            Formularies.CollectionChanged += Formularies_CollectionChanged;
            Ingredients.CollectionChanged += Formularies_CollectionChanged;
            Materials.CollectionChanged += Formularies_CollectionChanged;
        }

        #endregion

        #region Caching

        public ObservableCollection<Formula> Formularies
        {
            get
            {
                if (formularies is null)
                {
                    formularies = new(GetData<Formula>(FormulariesFile));
                }

                return formularies;
            }

            set
            {
                formularies = value;
                DataChanged(value);
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                if (ingredients is null)
                {
                    ingredients = new(GetData<Ingredient>(IngredientsFile));
                }

                return ingredients;
            }

            set
            {
                ingredients = value;
                DataChanged(value);
            }
        }

        public ObservableCollection<Material> Materials
        {
            get
            {
                if (materials is null)
                {
                    materials = new(GetData<Material>(MaterialsFile));
                }

                return materials;
            }

            set
            {
                materials = value;
                DataChanged(value);
            }
        }

        #endregion

        #region Operations

        #region Formula

        public IEnumerable<Formula> GetAllFormularies()
        {
            return Formularies;
        }

        public Formula GetSpecificFormula(int id)
        {
            return Formularies.FirstOrDefault(x => x.Id == id);
        }

        public int CreateFormula(Formula formula)
        {
            formula.Id = Formularies.GetNewId();
            Formularies.Add(formula);
            return formula.Id;
        }

        public void UpdateFormula(Formula updatedFormula)
        {
            Formula formula = GetSpecificFormula(updatedFormula.Id);

            formula.Client = updatedFormula.Client;
            formula.Name = updatedFormula.Name;
            formula.Procedure = updatedFormula.Procedure;
            formula.Description = updatedFormula.Description;
            formula.Size = updatedFormula.Size;
            formula.Ph = updatedFormula.Ph;
            formula.Texture = updatedFormula.Texture;
            formula.SkinType = updatedFormula.SkinType;

            DataChanged(Formularies);
        }

        public void DeleteFormula(int id)
        {
            Formularies.Remove(GetSpecificFormula(id));
        }

        #endregion

        #region Material

        public IEnumerable<Material> GetAllMaterials()
        {
            return Materials;
        }

        public Material GetSpecificMaterial(int id)
        {
            return Materials.FirstOrDefault(x => x.Id == id);
        }

        public int CreateMaterial(Material material)
        {
            material.Id = Materials.GetNewId();
            Materials.Add(material);
            return material.Id;
        }

        public void UpdateMaterial(Material updatedMaterial)
        {
            Material material = GetSpecificMaterial(updatedMaterial.Id);

            material.InciName = updatedMaterial.InciName;
            material.Name = updatedMaterial.Name;
            material.Description = updatedMaterial.Description;
            material.Price = updatedMaterial.Price;

            DataChanged(Materials);
        }

        public void DeleteMaterial(int id)
        {
            Materials.Remove(GetSpecificMaterial(id));
        }

        #endregion

        #region Ingredient

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return Ingredients;
        }

        public Ingredient GetSpecificIngredient(int formulaId, int materialId)
        {
            return Ingredients.FirstOrDefault(x => x.FormulaId == formulaId && x.MaterialId == materialId);
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void UpdateIngredient(Ingredient updatedIngredient)
        {
            Ingredient ingredient = GetSpecificIngredient(updatedIngredient.FormulaId, updatedIngredient.MaterialId);

            ingredient.Phase = updatedIngredient.Phase;
            ingredient.Percentage = updatedIngredient.Percentage;

            DataChanged(ingredients);
        }

        public void DeleteIngredient(int formulaId, int materialId)
        {
            Ingredients.Remove(GetSpecificIngredient(formulaId, materialId));
        }

        public void DeleteAllMaterialIngredients(int materialId)
        {
            Ingredients = new(Ingredients.Where(x => x.MaterialId != materialId));
        }

        public void DeleteAllFormulaIngredients(int formulaId)
        {
            Ingredients = new(Ingredients.Where(x => x.FormulaId != formulaId));
        }

        #endregion

        #endregion

        #region Read Write

        #region Read Write To File

        private string ReadFile(string path)
        {
            lock (WritingOnGoing)
            {
                if (!File.Exists(path))
                {
                    return "";
                }

                return File.ReadAllText(path);
            }
        }

        private void WriteFile(string path, string content)
        {
            lock (WritingOnGoing)
            {
                File.WriteAllText(path, content);
            }
        }

        #endregion

        #region Read Write Data

        private IEnumerable<T> GetData<T>(string path)
        {
            string data = ReadFile($"{Saves}{path}");

            if (data == "")
            {
                return Enumerable.Empty<T>();
            }

            return JsonSerializer.Deserialize<IEnumerable<T>>(data);
        }

        private void WriteData<T>(string file, IEnumerable<T> Data)
        {
            WriteFile($"{Saves}{file}", JsonSerializer.Serialize(Data.ToArray()));
        }

        #endregion

        #endregion

        #region Data Change

        private void DataChanged(object sender)
        {
            Formularies_CollectionChanged(sender, null);
        }


        private async void Formularies_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            await Task.Run(() =>
            {
                switch (sender)
                {
                    case ObservableCollection<Formula>:
                        WriteData(FormulariesFile, Formularies);
                        break;

                    case ObservableCollection<Ingredient>:
                        WriteData(IngredientsFile, Ingredients);
                        break;

                    case ObservableCollection<Material>:
                        WriteData(MaterialsFile, Materials);
                        break;
                }
            });
        }

    }

    #endregion
}
