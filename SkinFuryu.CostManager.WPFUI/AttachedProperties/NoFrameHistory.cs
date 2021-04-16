using SkinFuryu.CostManager.WPFUI.AttachedProperties.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SkinFuryu.CostManager.WPFUI.AttachedProperties
{
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        /// <summary>
        /// Event to ensure that the frame history remains empty no matter what
        /// </summary>
        /// <param name="sender">The Frame which will be constantly cleared</param>
        /// <param name="e">arguments of the event</param>
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Converts the sender to a Frame
            Frame frame = sender as Frame;

            //Sets the Frame to be Hidden
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            //Adds an event to constantly clear the frame
            frame.Navigated += (sender, args) => (sender as Frame).NavigationService.RemoveBackEntry();
        }
    }
}
