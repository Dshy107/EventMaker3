using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EventMaker.Persistency;
using Newtonsoft.Json;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        public static EventCatalogSingleton Singleton = new EventCatalogSingleton();
        public ObservableCollection<Event> EventList { get; set; }
        
        private static EventCatalogSingleton instance;

        private EventCatalogSingleton()
        {
            EventList = new ObservableCollection<Event>();

            EventList.Add(new Event(1408, "Fastelavnsfest", "Kom i din bedste kostume og slå katten af tønden!", "Fælleshuset", new DateTime(2017, 02, 04)));
            EventList.Add(new Event(2643, "Musical", "Få en fantastisk oplevelse med dygtige skuespillere og sangere!", "Koncertsalen", new DateTime(2017, 04, 10)));
            EventList.Add(new Event(5121, "Sommerfest", "Kom til den årlige sommefest med dit bedste grillkød og godt humør!", "Udendørsarealet", new DateTime(2017, 06, 27)));

        }

        public static EventCatalogSingleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new EventCatalogSingleton();
                    }
                    return instance;
                }
            }

        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        /// <param name="jsonText"></param>

        public void InsertJson(string jsonText)
        {
            List<Event> newList = JsonConvert.DeserializeObject<List<Event>>(jsonText);

            foreach (var eventItem in newList)
            {
                EventList.Add(eventItem);
            }
        }




        //Spørgsmål til opgave 1,6 : Hvorfor skal vi lave en Add-metode, da dette allerede eksistere i systemet gennem ObservableCollection?
    }
}
