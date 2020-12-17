using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ReqeustSystem
{
    public class User : INotifyPropertyChanged
    {
        public int workerID { get; set; }
        public static int workerCount { get; set; }
        public string workerName { get; set; }
        public string workerProf { get; set; }

        public virtual void UserLogin()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
