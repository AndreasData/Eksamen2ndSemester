using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Storage;
using RequestSystem;
using Newtonsoft.Json;

namespace ReqeustSystem
{
    public class RequestViewModel : INotifyPropertyChanged
    {
   
        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Proparties
        // Proparties used to create a database
        public string RequestDescription { get; set; }
        private Request selectedRequest;

        private Building _sbuilding;
        public Building sBuilding
        {
            get { return _sbuilding; }
            set { _sbuilding = value; }
        }

        private Room _sRoom;
        public Room sRoom
        {
            get { return _sRoom; }
            set { _sRoom = value; }
        }
        #endregion
        #region ObservableCollection
        public ObservableCollection<Request> OC_request { get; set; }
        private ObservableCollection<Building> OC_building;
        public ObservableCollection<Building> OC_buildings
        {
            get { return OC_building; }
            set { OC_building = value; }
        }

        private ObservableCollection<Room> OC_room;
        public ObservableCollection<Room> OC_rooms
        {
            get { return OC_room; }
            set { OC_room = value; }
        }
        #endregion

        const string serverUrl = "http://localhost:51474/";

        #region RelayCommands
        /*
        public RelayCommands LoginAdmin { get; set; }
        public RelayCommands Loginworker { get; set; }
        */
        public RelayCommands _RequestSubmit { get; set; }
        public RelayCommands _BuildingList { get; set; }
        #endregion
        public RequestViewModel()   
        {
            OC_request = new ObservableCollection<Request>();   
            OC_buildings = new ObservableCollection<Building>();
            OC_rooms = new ObservableCollection<Room>();
            #region OC for buildings
            Building Building1 = new Building("Haldor Topsøe");
            Building Building2 = new Building("Kiwi");
            Building Building3 = new Building("Apple");

            OC_buildings.Add(Building1);
            OC_buildings.Add(Building2);
            OC_buildings.Add(Building3);

            Building1.List_Room.Add(new Room(111, "Office"));
            Building1.List_Room.Add(new Room(112, "Office"));
            Building1.List_Room.Add(new Room(113, "Cafeteria"));
            Building1.List_Room.Add(new Room(114, "Meeting Room"));
            Building1.List_Room.Add(new Room(115, "Toilet"));
            Building1.List_Room.Add(new Room(211, "Office"));
            Building1.List_Room.Add(new Room(212, "Building Adminstration Room"));
            Building1.List_Room.Add(new Room(213, "Meeting Room"));
            Building1.List_Room.Add(new Room(221, "Office"));
            Building1.List_Room.Add(new Room(222, "Office"));
            Building1.List_Room.Add(new Room(223, "Office"));

            Building2.List_Room.Add(new Room(111, "Office"));
            Building2.List_Room.Add(new Room(112, "Meeting Room"));
            Building2.List_Room.Add(new Room(113, "Office"));
            Building2.List_Room.Add(new Room(114, "Toilet"));
            Building2.List_Room.Add(new Room(115, "Office"));
            Building2.List_Room.Add(new Room(116, "Office"));
            Building2.List_Room.Add(new Room(117, "Workshop"));
            Building2.List_Room.Add(new Room(118, "Labratory"));

            Building3.List_Room.Add(new Room(111, "Office"));
            Building3.List_Room.Add(new Room(112, "Office"));
            Building3.List_Room.Add(new Room(113, "Office"));
            Building3.List_Room.Add(new Room(211, "Office"));
            Building3.List_Room.Add(new Room(212, "Office"));
            Building3.List_Room.Add(new Room(311, "Office"));
            Building3.List_Room.Add(new Room(312, "Recration Room"));


            #endregion
            _RequestSubmit = new RelayCommands(RequestSubmit);
            _BuildingList = new RelayCommands(SelectedBuildingList);
        }
        public void RequestSubmit()
        {
            Request oRequest = new Request(sRoom, RequestDescription);

            OC_request.Add(oRequest);
        }


        //Work inProgress function to change room list after you choose building
        public Request SelectedRequest 
        {
            get => selectedRequest;
            set 
            {
                selectedRequest = value;
            }
        }
        //Changing OC_room 
        public void SelectedBuildingList() 
        {
            OC_rooms.Clear();
            foreach(Room room in sBuilding.List_Room) 
            {
                OC_rooms.Add(room);
            }
        }
        #region Hent Data
        private async void HentDataFraDiskAsync()
        {
            OC_request.Clear();
            List<Request> nyListe = new List<Request>();
            nyListe = await PersistencyService.HentDataFraDiskAsyncPS();

            //Setup client handler
            HttpClientHandler handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };

            using (var client = new HttpClient(handler))
            {
                //Initialize client
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //Request JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //Get all the Requests from the database
                    var oRequest = client.GetAsync("api/Requests").Result;

                    //Check response -> throw exception if NOT successful
                    oRequest.EnsureSuccessStatusCode();

                    //Get the Request as a ICollection
                    var Requests = oRequest.Content.ReadAsAsync<ICollection<Request>>().Result;

                    foreach (var ViewRequest in Requests)
                    {

                        this.OC_request.Add(new Request(ViewRequest.Room,ViewRequest.Description));
                    }

                    
                }
                catch
                {

                }
            }
            //StorageFile file = await localfolder.GetFileAsync(filnavn);
            //string jsonText = await FileIO.ReadTextAsync(file);
            //this.OC_blomster.Clear();
            //IndsætJson(jsonText);
        }
        #endregion

        #region Gem data
        private async void GemDataTilDiskAsync()
        {
            this.jsonRequest = GetJson();

            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, this.jsonRequest);
        }

        private string GetJson()
        {
            string json = JsonConvert.SerializeObject(OC_request);
            return json;
        }
        
        #endregion
        private string jsonRequest;

        public string JsonRequest
        {
            get { return jsonRequest; }
            set { jsonRequest = value; }
        }

        private readonly StorageFolder localfolder = null;

        private readonly string filnavn = "Request1.json";

       

    }


}
