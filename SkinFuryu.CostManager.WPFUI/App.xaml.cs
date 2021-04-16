using Microsoft.Extensions.DependencyInjection;
using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.Infrastructure.DataManager;
using SkinFuryu.CostManager.Infrastructure.FilePrinters;
using SkinFuryu.CostManager.UIFront.IoCContainer;
using SkinFuryu.CostManager.UIFront.UI;
using SkinFuryu.CostManager.UIFront.ViewModels;
using SkinFuryu.CostManager.WPFUI.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SkinFuryu.CostManager.WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let Application do it's magic
            base.OnStartup(e);

            //Setup IOC Container
            SetupDI();

            //Show Main Window
            (Current.MainWindow = new MainWindow()).Show();
            
        }

        private void SetupDI()
        {
            IServiceCollection serviceCollection = IoC.AddSingleton<IUIManager>(new UIManager())
                .AddSingleton(new ApplicationViewModel())
                .AddSingleton<IFormulaPrinter>(new PdfPrinter())
                .AddSingleton<IDataAccess>(FileDataAccess.Instance);

            IoC.Setup();
        }
    }
}
