using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace ReqeustSystem
{
    public class Request : INotifyPropertyChanged
    {
        #region Proparties
        private Room _requestRoom { get; set; }
        private string _requestDescription { get; set; }
        private User _workerID { get; set; }
        private static int _requestcount { get; set; }
        private int _requestId { get; set; }
        //Used to show the information on a OC in View
        public Room _RequestRoom
        {
            get { return _requestRoom;}
            set
            {
                _requestRoom = value;
                OnPropertyChanged();
            }
        }
        public string _RequestDescription 
        {
            get { return _requestDescription;}
            set
            {
                _requestDescription = value;
                OnPropertyChanged();
            }
        }
        public int _RequestID 
        {
            get { return _requestId; }
            set
            {
                _requestId = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public Request(Room RequestRoom, string RequestDescription)
        {
            _requestDescription = RequestDescription;
            _requestRoom = RequestRoom;
            //Making a unique key for request
            _requestcount++;
            _requestId = _requestId;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Request() { }
    }
}
