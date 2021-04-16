using SkinFuryu.CostManager.UIFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.UI
{
    public interface IUIManager
    {
        public Task ShowMessage(MessageBoxViewModel message);
    }
}
