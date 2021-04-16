using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.ViewModels;
using SkinFuryu.CostManager.WPFUI.ViewModels;
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

namespace SkinFuryu.CostManager.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
