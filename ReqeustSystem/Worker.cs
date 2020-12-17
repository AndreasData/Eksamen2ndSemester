using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqeustSystem
{
    public class Worker : User
    {
        public Worker(string name, string prof)
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
