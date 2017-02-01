using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using System.ComponentModel;

namespace EventMaker.ViewModel
{
    public class EventViewModel
    {
        public Model.EventCatalogSingleton SingletonRef { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new
            TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            SingletonRef = EventCatalogSingleton.Instance;
        }
    }
}
