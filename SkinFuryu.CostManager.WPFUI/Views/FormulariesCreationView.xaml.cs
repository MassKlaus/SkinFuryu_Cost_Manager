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
    /// Interaction logic for FormulariesCreationView.xaml
    /// </summary>
    public partial class FormulariesCreationView : BasePage<FormulariesCreationViewModel>
    {
        public FormulariesCreationView()
        {
            InitializeComponent();
        }

        public FormulariesCreationView(FormulariesCreationViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
