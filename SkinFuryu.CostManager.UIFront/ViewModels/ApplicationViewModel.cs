using SkinFuryu.CostManager.UIFront.DataModels;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.ViewModels
{
    /// <summary>
    /// The application state as a viewModel In order to change the application state
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Loading;

        public BaseViewModel ViewModel { get; set; } = null;

        public bool NavigationMenuVisible { get; set; } = false;
        
        public bool TabsNavigationVisible { get; set; } = false;

        public void GotoPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            ViewModel = viewModel;

            if (CurrentPage != page)
            {
                CurrentPage = page;
            }

            NavigationMenuVisible = CurrentPage != ApplicationPage.Loading;
            TabsNavigationVisible = CurrentPage == ApplicationPage.FormularyIngredients || CurrentPage == ApplicationPage.FormularyDataEditor;
        }
    }
}
