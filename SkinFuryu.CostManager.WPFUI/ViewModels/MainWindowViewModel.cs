using SkinFuryu.CostManager.UIFront.Commands;
using SkinFuryu.CostManager.UIFront.DataModels;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.WPFUI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkinFuryu.CostManager.WPFUI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            OpenFormulariesView = new ProxyCommand(() => ChangePage(ApplicationPage.FormulariesCreation));
            OpenFormularies = new ProxyCommand(() => ChangePage(ApplicationPage.Formularies));
            OpenMaterials = new ProxyCommand(() => ChangePage(ApplicationPage.Materials));
            
            OpenFormularyIngredients = new ProxyCommand(() => ChangePage(ApplicationPage.FormularyIngredients, IoC.Application.ViewModel));
            OpenFormularyData = new ProxyCommand(() => ChangePage(ApplicationPage.FormularyDataEditor, IoC.Application.ViewModel));
        }

        public ICommand OpenFormulariesView { get; set; }
        public ICommand OpenFormularies { get; set; }
        public ICommand OpenMaterials { get; set; }

        public ICommand OpenFormularyIngredients { get; set; }
        public ICommand OpenFormularyData { get; set; }

        public static void ChangePage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            IoC.Get<ApplicationViewModel>().GotoPage(page, viewModel);
        }
    }
}
