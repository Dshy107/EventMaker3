using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using System.ComponentModel;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;

namespace EventMaker.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {

        private Model.Event selectedEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.EventCatalogSingleton SingletonRef { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public RelayCommand DeleteEventCommand { get; set; }
       // public RelayArgCommand<Event> DeleteEventCommand { get; private set; }
        private MyEventHandler EventHandler { get; set; }



        public Model.Event SelectedEvent
        {
            get { return selectedEvent; }
            set {
                selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new
            TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            SingletonRef = EventCatalogSingleton.Instance;
            EventHandler = new MyEventHandler(this);

            CreateEventCommand = new RelayCommand(EventHandler.CreateEvent);

            // DeleteEventCommand = new RelayCommand();
            //  DeleteEventCommand = new RelayArgCommand<Event>( ev => EventHandler.DeleteEvent(ev));

        }

        // Melder fejl - kan ikke finde OnPropertyChange?
        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertChanged(string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}



        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


        
    }
}
