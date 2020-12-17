using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;

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
        public Room RequestRoom { get; set; }
        public string RequestDescription { get; set; }
        // Praparties used to show the list
        public int RequestID { get; set; }
        public string MyProperty { get; set; }

        #endregion
        private Building selectedBuilding;
        private Request selectedRequest;
        private Room selectedRoom;
        private Building specificBuilding;
        private Room specificRoom;

        public Building SpecificBuilding { get => specificBuilding; set => specificBuilding = value; }
        public Room SpecificRoom { get => specificRoom; set => specificRoom = value; }
        // OC for request
        public ObservableCollection<Request> OC_request { get; set; }

        #region Creating OC for Rooms
        // Room OC for a drop down view
        private ObservableCollection<Room> OC_room;
        public ObservableCollection<Room> OC_rooms
        {
            get { return OC_room; }
            set { OC_room = value; }
        }

        private Room _sRoom;
        public Room sRoom
        {
            get { return _sRoom; }
            set { _sRoom = value; }
        }
        #endregion

        #region Creating OC for Buildings
        private ObservableCollection<Building> OC_building;
        public ObservableCollection<Building> OC_buildings
        {
            get { return OC_building; }
            set { OC_building = value; }
        }

        private int _buildingID;
        public int _sbuildingID
        {
            get { return _buildingID; }
            set { _buildingID = value; }
        }
        #endregion

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
            OC_rooms = new ObservableCollection<Room>();
            #region OC for Room
            Room room1 = new Room(111, "Office");
            Room room2 = new Room(112, "Office");
            Room room3 = new Room(113, "Workshop");
            Room room4 = new Room(114, "Cafeteria");

            OC_rooms.Add(room1);
            OC_rooms.Add(room2);
            OC_rooms.Add(room3);
            OC_rooms.Add(room4);

            Request request1 = new Request(room1, "table");
            Request request2 = new Request(room4, "Light bulb out");
            OC_request.Add(request1);
            OC_request.Add(request2);
            #endregion

            _RequestSubmit = new RelayCommands(RequestSubmit);
            _BuildingList = new RelayCommands(SelectedBuildingList);

            SelectedRequest = new Request();
            SelectedBuilding = new Building();
            SelectedRoom = new Room();
        }
        public void RequestSubmit()
        {
            Request oRequest = new Request(RequestRoom, RequestDescription);

            OC_request.Add(oRequest);
        }


        //Work inProgress function to change room list after you choose building
        public Building SelectedBuilding 
        {
            get => selectedBuilding; 
            set
            {
                selectedBuilding = value;
            }
        }
        public Request SelectedRequest 
        {
            get => selectedRequest;
            set 
            {
                selectedRequest = value;
            }
        }
        public Room SelectedRoom 
        {
            get => selectedRoom;
            set 
            {
                selectedRoom = value;
            }
        }
        //Changing OC_room 
        public void SelectedBuildingList() 
        {
            OC_rooms.Clear();
            foreach(Room room in SelectedBuilding.List_Room) 
            {
                OC_rooms.Add(room);
            }
        }
    }
}
