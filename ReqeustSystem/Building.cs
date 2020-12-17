using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReqeustSystem
{
    public class Building : INotifyPropertyChanged
    {
        private string buildingTitle;
        public string _buildingTitle
        {
            get { return buildingTitle; }
            set { buildingTitle = value; } 
        }

        public static int _BuildingCount { get; set; }
        public int _BuildingId { get; set; }

        private List<Room> list_Room;
        public List<Room> List_Room
        {
            get => list_Room; set 
            {
                list_Room = value;
                OnPropertyChanged();
            }
        }
        public int buildingId 
        {
            get { return _BuildingId; }
            set { _BuildingId = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Building(String BuildingTitle) 
        {
            buildingTitle = BuildingTitle;
            _BuildingCount++;
            _BuildingId = _BuildingCount;
            List_Room = new List<Room>();
        }
        public Building() 
        { }
    }
}
