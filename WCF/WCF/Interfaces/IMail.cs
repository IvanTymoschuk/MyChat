using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;

namespace WCF.Interfaces
{
    [ServiceContract]
    public interface IMail
    {
        [OperationContract]
        void SendCode(UserDTO user,int code);
    }
}
