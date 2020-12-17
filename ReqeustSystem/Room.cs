using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ReqeustSystem
{
    public class Room : INotifyPropertyChanged
    {
        #region Variables
        private String _roomType;
        public string roomType 
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        private int _roomNo;
        public int roomNo 
        {
            get { return _roomNo; }
            set { _roomNo = value; }
        }

        private string _roomInfo;
        public string roomInfo
        {
            get { return _roomInfo; }
            set { _roomInfo = value; }
        }
        public static int _roomCount { get; set; }
        public int _roomId { get; set; }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged

        public Room(int roomNo, string roomType)
        {
            //Creating ID for Room
            _roomCount++;
            _roomId = _roomCount;
            _roomType = roomType;
            _roomNo = roomNo;

            //Making a new Variable for showing roomInfo
            string String_roomId = _roomId.ToString();
            _roomInfo = $"Room ID {String_roomId}, {_roomType}";
        }
        public Room() { }
    }
}
