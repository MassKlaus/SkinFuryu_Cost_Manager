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

namespace SkinFuryu.CostManager.WPFUI.Views
{
    /// <summary>
    /// Interaction logic for FormulariesView.xaml
    /// </summary>
    public partial class FormulariesViewerView : BasePage<FormulariesViewerViewModel>
    {
        public FormulariesViewerView()
        {
            InitializeComponent();
        }

        public FormulariesViewerView(FormulariesViewerViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
