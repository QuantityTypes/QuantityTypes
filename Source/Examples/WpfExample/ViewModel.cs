// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="X">
//   X
// </copyright>
// <summary>
//   Represents the main window's view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfExample
{
    using System.ComponentModel;

    using Units;

    /// <summary>
    /// Represents the main window's view model.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        #region Constants and Fields

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

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.Length = 100 * Length.Metre;
            this.Time = 9.58 * Time.Second;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length. 
        /// </value>
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
        /// <value>
        /// The time. 
        /// </value>
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

        #endregion

        #region Methods

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

        #endregion
    }
}