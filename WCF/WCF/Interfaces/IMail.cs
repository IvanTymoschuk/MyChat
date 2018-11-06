using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Interfaces
{
    [ServiceContract]
    public interface IMail
    {
        [OperationContract]
        void SendCode(string Email);
    }
}
