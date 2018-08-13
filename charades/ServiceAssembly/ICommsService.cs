using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommsService" in both code and config file together.
    [ServiceContract (SessionMode = SessionMode.Required, 
        CallbackContract =typeof(ICommsServiceDuplexCallback))]
    public interface ICommsService
    {
        [OperationContract(IsOneWay = true)]
        void DoWork();

        [OperationContract(IsOneWay = true)]
        void Send(Message msg);
    }

    public interface ICommsServiceDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive( Message msg);
    }
}
