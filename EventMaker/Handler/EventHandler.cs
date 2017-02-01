using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.ViewModel;
using EventMaker.Model;
using EventMaker.Converter;

namespace EventMaker.Handler
{
    class EventHandler
    {
        EventViewModel eventVM;

        public EventHandler()
        {
            eventVM = new EventViewModel();
        }

        public void CreateEvent()
        {
            Event newEvent = new Event(eventVM.Id, eventVM.Name, eventVM.Description, eventVM.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(eventVM.Date, eventVM.Time));

            EventCatalogSingleton.Singleton.EventList.Add(newEvent);
        }


    }
}
