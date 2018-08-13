using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceAssembly
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommsService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    public class CommsService : ICommsService
    {
        Dictionary<Client, ICommsServiceDuplexCallback> clients =
             new Dictionary<Client, ICommsServiceDuplexCallback>();
        object syncObj = new object();


        public ICommsServiceDuplexCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.
                       GetCallbackChannel<ICommsServiceDuplexCallback>();
            }
        }


        private bool SearchClientsByName(string name)
        {
            foreach (Client c in clients.Keys)
            {
                if (c.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void DoWork(Client c)
        {
            c.Name = "Parteek";
        }

        public void Send(Message message)
        {
            //update game

            //update clients
            lock (syncObj)
            {
                foreach (ICommsServiceDuplexCallback callback in clients.Values)
                {
                    callback.Receive(message);
                }
            }
        }
    }
}
