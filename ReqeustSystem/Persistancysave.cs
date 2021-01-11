using Newtonsoft.Json;
using ReqeustSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace RequestSystem

{
    public class PersistencyService
    {
        private static readonly string filnavn = "Request1.json";

        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        public static async Task GemDataTilDiskAsyncPS(ObservableCollection<Request> oc_request)
        {
            string jsonText = GetJsonPS(oc_request);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        /// <summary>
        /// Giver mig Jsonformat for oc_request object
        /// </summary>
        /// <returns></returns>
        public static string GetJsonPS(ObservableCollection<Request> oc_request)
        {
            string json = JsonConvert.SerializeObject(oc_request);
            return json;
        }


        /// <summary>
        /// metode som modtager en string af json og deserialiserer til objekter af Request
        /// </summary>
        /// <param name="jsonText"></param>
        private static List<Request> DeserialiserJson(string jsonText)
        {
            List<Request> nyListe = JsonConvert.DeserializeObject<List<Request>>(jsonText);
            return nyListe;
        }

        /// <summary>
        /// Henter en json fil fra disken 
        /// </summary>
        public static async Task<List<Request>> HentDataFraDiskAsyncPS()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            List<Request> list = new List<Request>();
            list = DeserialiserJson(jsonText);

            return list;
        }

    }
}