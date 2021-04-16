using SkinFuryu.CostManager.WPFUI.DataModels;
using SkinFuryu.CostManager.UIFront.ViewModels;
using SkinFuryu.CostManager.WPFUI.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.DataModels;

namespace SkinFuryu.CostManager.WPFUI.Views
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : BasePage<LoadingPageViewModel>
    {
        /// <summary>
        /// Constructor while passing in a specific ViewModel
        /// </summary>
        public LoadingPage(LoadingPageViewModel specificViewModel) : this()
        {
            this.DataContext = specificViewModel;
        }

        public LoadingPage()
        {
            InitializeComponent();
        }

        protected async override void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            base.BasePage_Loaded(sender, e);

            await Task.Delay(1975);

            IoC.Application.GotoPage(ApplicationPage.Formularies, null);
        }
    }
}
