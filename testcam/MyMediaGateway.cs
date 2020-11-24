using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ozeki.MediaGateway;
using Ozeki.Media;
using Ozeki.Camera;

namespace testcam
{
    public class MyMediaGateway
    {
        public class MyMediaGateway : MediaGateway
        {
            private Dictionary<IClient, MyClient> clients;
            private IStreamService _streamService;

            public event EventHandler<EventArgs> ClientCountChange;

            public MyMediaGateway(MediaGatewayConfig config)
                : base(config)
            {
                clients = new Dictionary<IClient, MyClient>();
            }

            #region MediaGateway methods

            public override void OnStart()
            {
                base.OnStart();

                _streamService = GetService<IStreamService>();

                Console.WriteLine("MediaGateway started.");
            }

            public override void OnClientConnect(IClient client, object[] parameters)
            {
                Console.WriteLine(client.RemoteAddress + " client connected to the server with " + client.ClientType);
                if (clients.ContainsKey(client)) return;
                clients.Add(client, new MyClient(client, _streamService));
                ClientChange();
            }

            public override void OnClientDisconnect(IClient client)
            {
                var disconnectedClient = GetClient(client);
                if (disconnectedClient == null)
                    return;

                disconnectedClient.DisconnectCamera();
                clients.Remove(client);
                ClientChange();
            }

            private void ClientChange()
            {
                var handler = ClientCountChange;
                if (handler != null)
                    ClientCountChange(this, new EventArgs());
            }

            #endregion

            #region Client invokes

            public void CameraConnect(IClient client, string uri)
            {
                Console.WriteLine(client.RemoteAddress + " client IP camera connect " + uri);

                var myClient = GetClient(client);
                if (myClient == null)
                    return;

                myClient.ConnectCamera(uri);
            }

            public void CameraDisconnect(IClient client)
            {
                Console.WriteLine(client.RemoteAddress + " client IP camera disconnect.");

                var myClient = GetClient(client);
                if (myClient == null)
                    return;

                myClient.DisconnectCamera();
            }

            #endregion

            MyClient GetClient(IClient client)
            {
                return !clients.ContainsKey(client) ? null : clients[client];
            }
        }
    }
}
