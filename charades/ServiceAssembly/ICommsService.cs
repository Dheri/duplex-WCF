using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceAssembly
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommsService" in both code and config file together.
    [ServiceContract (SessionMode = SessionMode.Required, 
        CallbackContract =typeof(ICommsServiceDuplexCallback))]
    public interface ICommsService
    {
        [OperationContract(IsOneWay = true)]
        void DoWork( Client c);

        [OperationContract(IsOneWay = true)]
        void Send(Message msg);

        [OperationContract(IsInitiating = true)]
        bool Connect(Client c);
    }

    public interface ICommsServiceDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive( Message msg);
        void RefreshClients(List<Client> clientList);
        void UserJoin(Client client);
    }
}
