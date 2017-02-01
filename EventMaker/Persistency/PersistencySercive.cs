using EventMaker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    class PersistencySercive
    {
        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {

        }

        public static async Task<List<Event>> LoadEventsFromJson()
        {
            return null;
        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {

        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            return null;
        }
    }
}
