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
        List<Client> clientList = new List<Client>();

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
            Console.WriteLine(message.Sender + ": " + message.Content);
            //update clients
            lock (syncObj)
            {
                try
                {

                    foreach (ICommsServiceDuplexCallback callback in clients.Values)
                    {
                        callback.Receive(message);
                    }
                }
                catch (Exception e)
                {
                    //lol
                }
            }
        }

        public bool Connect(Client client)
        {
            if (!clients.ContainsValue(CurrentCallback) && !SearchClientsByName(client.Name))
            {
                lock (syncObj)
                {
                    clients.Add(client, CurrentCallback);
                    clientList.Add(client);

                    foreach (Client key in clients.Keys)
                    {
                        ICommsServiceDuplexCallback callback = clients[key];
                        try
                        {
                            // callback.RefreshClients(clientList);
                            //callback.UserJoin(client);
                        }
                        catch
                        {
                            //clients.Remove(key);
                            return false;
                        }

                    }

                }
                return true;
            }
            return false;
        }

    }
}
