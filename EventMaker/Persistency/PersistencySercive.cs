using EventMaker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace EventMaker.Persistency
{
    class PersistencySercive
    {
        static StorageFolder localfolder = null;
        static private readonly string filnavn = "JsonTextEvent.json";


        public static async void GemDataTilAsync()
        {
            localfolder = ApplicationData.Current.LocalFolder;
            string jsonText = EventCatalogSingleton.Instance.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);

        }



        public static async void HentDataTilDiskAsync()
        {
            try
            {
                localfolder = ApplicationData.Current.LocalFolder;
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                EventCatalogSingleton.Instance.EventList.Clear();
                EventCatalogSingleton.Instance.InsertJson(jsonText);
            }
            catch (Exception)
            {

            }

        }







        //public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        //{

        //}

        //public static async Task<List<Event>> LoadEventsFromJson()
        //{
        //    return null;
        //}

        //public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        //{

        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    return null;
        //}
    }
}