using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;

namespace WCF.Interfaces
{
//    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required,
//                  CallbackContract = typeof(IUserCallback))]



    public interface IUserCallback
    {
        [OperationContract(IsOneWay = true)]
        void GetMessage(MessageDTO msg);

    }
}
