using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.WPFUI.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
