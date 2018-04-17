using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ELEVEN.Model
{
    public abstract class BaseModel : INotifyPropertyChanged
    {

        // dispatcher associated with model
        public int changed = 0;
        protected Dispatcher dispatcher;

        PropertyChangedEventHandler propertyChangedEvent;

        public BaseModel()
        {
            // save off dispatcher 

            dispatcher = Dispatcher.CurrentDispatcher;
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                ConfirmOnUIThread();
                propertyChangedEvent += value;
            }
            remove
            {
                ConfirmOnUIThread();
                propertyChangedEvent -= value;
            }
        }


        // utility function for use by subclasses to notify that a property value has changed

        protected void Notify(string propertyName)
        {
            ConfirmOnUIThread();
            ConfirmPropertyName(propertyName);

            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));

            }
        }


        // debugging facility that ensures methods are called on the UI thread

        [Conditional("Debug")]
        protected void ConfirmOnUIThread()
        {
            Debug.Assert(Dispatcher.CurrentDispatcher == dispatcher, "Call must be made on UI thread.");
        }


        // debugging facility that ensures the property does exist on the class

        [Conditional("Debug")]
        private void ConfirmPropertyName(string propertyName)
        {
            Debug.Assert(GetType().GetProperty(propertyName) != null, "Property " + propertyName + " is not a valid name.");
        }
    }
}
