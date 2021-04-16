using SkinFuryu.CostManager.ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.ApplicationLayer.Interface
{
    public interface IFormulaPrinter
    {
        void PrintFile(FormulaReport formulaReport);
    }
}
