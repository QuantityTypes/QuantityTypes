// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="QuantityTypes">
//   Copyright (c) 2012 Oystein Bjorke
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfExample
{
    using System.ComponentModel;

    using QuantityTypes;

    /// <summary>
    /// Represents the main window's view model.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The length.
        /// </summary>
        private Length length;

        /// <summary>
        /// The time.
        /// </summary>
        private Time time;

        /// <summary>
        /// The velocity.
        /// </summary>
        private Velocity velocity;

        /// <summary>
        /// The mass.
        /// </summary>
        private Mass? mass;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            this.Length = 100 * Length.Metre;
            this.Time = 9.58 * Time.Second;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value> The length. </value>
        public Length Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (this.length == value)
                {
                    return;
                }

                this.length = value;
                this.Velocity = this.Length / this.Time;
                this.RaisePropertyChanged("Length");
            }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value> The time. </value>
        public Time Time
        {
            get
            {
                return this.time;
            }

            set
            {
                if (this.time == value)
                {
                    return;
                }

                this.time = value;
                this.Velocity = this.Length / this.Time;
                this.RaisePropertyChanged("Time");
            }
        }

        /// <summary>
        /// Gets the velocity.
        /// </summary>
        public Velocity Velocity
        {
            get
            {
                return this.velocity;
            }

            private set
            {
                if (this.velocity == value)
                {
                    return;
                }

                this.velocity = value;
                this.RaisePropertyChanged("Velocity");
            }
        }

        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        /// <value>The mass.</value>
        public Mass? Mass
        {
            get
            {
                return this.mass;
            }

            set
            {
                this.mass = value;
                this.RaisePropertyChanged("Mass");
            }
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        protected void RaisePropertyChanged(string property)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}