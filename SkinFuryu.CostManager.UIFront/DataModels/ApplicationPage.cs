using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.DataModels
{
    /// <summary>
    /// Enum that will hold all the pages that will be shown and presented
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// Page where formulas will be created
        /// </summary>
        FormulariesCreation = 0,

        /// <summary>
        /// Page where all stored formularies will be shown
        /// </summary>
        Formularies,

        /// <summary>
        /// Page where all materials will be shown
        /// </summary>
        Materials,

        /// <summary>
        /// Loading Page That will be shown at the start of the application
        /// </summary>
        Loading,

        /// <summary>
        /// A Page that will display all the ingredients within a formulary ordered by Phase
        /// </summary>
        FormularyIngredients,

        /// <summary>
        /// A Page that will display the data of a formula and update it
        /// </summary>
        FormularyDataEditor
    }
}
