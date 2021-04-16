using SkinFuryu.CostManager.UIFront.DataModels;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.ViewModels.Forumularies;
using SkinFuryu.CostManager.WPFUI.DataModels;
using SkinFuryu.CostManager.WPFUI.ValueConverters.Base;
using SkinFuryu.CostManager.WPFUI.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.WPFUI.ValueConverters
{
    /// <summary>
    /// Converts <see cref="ApplicationPage"/> Enum value to the actual page
    /// </summary>
    public class PageEnumToPageConverter : BaseValueConverter<PageEnumToPageConverter>
    {

        public override object Convert(object value, Type targetType, object parameter = null, CultureInfo culture = null)
        {
            object page = null;
            parameter = IoC.Application.ViewModel;
            //Gets the page depending on the enum type
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.FormularyIngredients:
                    page = new FormularyIngredientsManagerView(parameter as FormularyIngredientsManagerViewModel);
                    break;

                case ApplicationPage.FormulariesCreation:
                    page = new FormulariesCreationView(parameter as FormulariesCreationViewModel);
                    break;

                case ApplicationPage.Loading:
                    page = new LoadingPage();
                    break;

                case ApplicationPage.Formularies:
                    page = new FormulariesViewerView(parameter as FormulariesViewerViewModel);
                    break;

                case ApplicationPage.Materials:
                    page = new MaterialsManagerView(parameter as MaterialsManagerViewModel);
                    break;

                case ApplicationPage.FormularyDataEditor:
                    page = new FormularyDataEditor(parameter as FormularyIngredientsManagerViewModel);
                    break;
                     
                default:
                    break;
            }

            return page;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
