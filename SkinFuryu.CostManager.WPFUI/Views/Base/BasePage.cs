using SkinFuryu.CostManager.WPFUI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using SkinFuryu.CostManager.UIFront.ViewModels.Base;
using SkinFuryu.CostManager.UIFront.IoCContainer;

namespace SkinFuryu.CostManager.WPFUI.Views.Base
{
    public class BasePage<VM> : UserControl where VM : BaseViewModel, new()
    {
        #region Public Properties

        public VM ViewModel { get; set; }

        /// <summary>
        /// Animation To Be Performed at the time of loading the page
        /// </summary>
        public PageAnimation LoadAnimation { get; set; } = PageAnimation.None;

        /// <summary>
        /// Animation to be performed at the time of unloading the page
        /// </summary>
        public PageAnimation UnLoad { get; set; } = PageAnimation.None;

        /// <summary>
        /// Time it takes to apply the animation
        /// </summary>
        public double AnimationTime { get; set; } = 1;

        #endregion

        #region Constructors

        #endregion
        /// <summary>
        /// Constrctor to set up the different actions
        /// </summary>
        public BasePage()
        {
            try
            {
                this.DataContext = ViewModel = IoC.Get<VM>() ?? new VM();
            }
            catch (Exception)
            {
                this.DataContext = ViewModel = new VM();
            }

            //Listens to page load
            this.Loaded += BasePage_Loaded;

            //Listen to page unload
            this.Unloaded += BasePage_Unloaded;
        }

        public BasePage(VM SpecificViewModel) : this()
        {
            if (SpecificViewModel != null)
            {
                this.DataContext = ViewModel = SpecificViewModel;
            }
        }
        /// <summary>
        /// Called when the page is unloaded in order to do the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Called when the page is loaded in order to do the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}
