using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace SkinFuryu.CostManager.WPFUI.AttachedProperties.Base
{
    /// <summary>
    /// A Base Model for attached properties in order to simply the process of creating Attached Properties
    /// </summary>
    /// <typeparam name="Parent">The class that the property will be attached to</typeparam>
    /// <typeparam name="Property">The clas/Type that this property will be</typeparam>
    public class BaseAttachedProperty<Parent, Property> where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public Properties

        /// <summary>
        /// Instance of the Attached Property
        /// </summary>
        public static Parent Instance { get; set; } = new Parent();

        #endregion

        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        #endregion

        #region Attached Property

        /// <summary>
        /// Gets the values of the attached property from the passed dependency object
        /// </summary>
        /// <param name="obj">The dependency object that contains the property</param>
        /// <returns>The value of the property</returns>
        public static Property GetValue(DependencyObject obj) => (Property)obj.GetValue(ValueProperty);

        /// <summary>
        /// Sets the values of the attached property on the passed depency object
        /// </summary>
        /// <param name="obj">The dependency object that the property is linked to</param>
        /// <param name="value">The value that the dependecy object will hold</param>
        public static void SetValue(DependencyObject obj, Property value) => obj.SetValue(ValueProperty, value);

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(Parent), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Method to call inform EventListeners when <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI Element that changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Calling the classes own update method
            Instance.OnValueChanged(d, e);

            //Calls Listeners
            Instance.ValueChanged(d, e);
        }
        #endregion

        #region Event Method

        /// <summary>
        /// the method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}
