using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqeustSystem
{
    class Admin : User
    {
        public Admin(string name, string prof)
        {
            workerCount++;
            workerID = workerCount;

            this.workerName = name;
            this.workerProf = prof;
        }

        public override void UserLogin()
        {
        }
    }
}
