using System.Net.Sockets;

namespace P2PVideoCalling.Networking
{
    class P2PConnectionHandler : IConnectionHandler
    {
        private TcpListener host;
        private TcpClient client;
        private NetworkStream connectedClientStream;

        public P2PConnectionHandler(TcpListener host)
        {
            this.host = host;
        }

        //Allows remote clients to connect to this local computer
        public void AllowConnection()
        {
            //Start the local server
            host.Start();
            //Waits for connections

            //Once connected we must get a handle on the connected client
            client = host.AcceptTcpClient();
        }

        //Gets the remote client that has connected to this computer
        public void GetConnection()
        {
            connectedClientStream = client.GetStream();
        }

        //Initalises a connection to a remote client
        public void MakeConnection(string hostName, int portNumber)
        {
            client = new TcpClient(hostName, portNumber);
        }

        public void CloseConnection()
        {
            connectedClientStream.Close();
            client.Close();
            host.Stop();
        }
    }
}
