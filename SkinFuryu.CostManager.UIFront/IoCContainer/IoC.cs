using Microsoft.Extensions.DependencyInjection;
using SkinFuryu.CostManager.ApplicationLayer.Interface;
using SkinFuryu.CostManager.Infrastructure.DataManager;
using SkinFuryu.CostManager.UIFront.UI;
using SkinFuryu.CostManager.UIFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.IoCContainer
{
    /// <summary>
    /// The Kernel for our IOC Container
    /// </summary>
    public class IoC
    {
        /// <summary>
        /// Singleton Instance of the IOC Container in order to avoid duplicates
        /// </summary>
        public static IServiceCollection ServiceCollection { get; private set; } = new ServiceCollection();
        public static IServiceProvider Service { get; private set; }

        /// <summary>
        /// Function to run in at the start of the application in order to set up the IOC Container
        /// </summary>
        public static void Setup()
        {
            Service = ServiceCollection.BuildServiceProvider();
        }

        public static IServiceCollection AddSingleton<T>(T implementation) where T : class
        {
            ServiceCollection.AddSingleton(implementation);

            return ServiceCollection;
        }

        public static T Get<T>()
        {
            return Service.GetService<T>();
        }

        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        public static IDataAccess DataAccess => Get<IDataAccess>();
        public static IUIManager UI => Get<IUIManager>();
        public static IFormulaPrinter FormulaPrinter => Get<IFormulaPrinter>();

    }
}
