using P2PVideoCalling.Networking;
using P2PVideoCalling.Video;
using System.Net;
using System.Net.Sockets;

namespace P2PVideoCalling.IoC
{
    class Controller
    {
        public static IConnectionHandler GetP2PConnectionHandler(int portNumber)
        {
            var localHost = new TcpListener(IPAddress.Any, portNumber);
            //This will eventually be specific to the person the user wants to connect to
            return new P2PConnectionHandler(localHost);
        }

        public static IVideoHandler GetWebCamHandler()
        {
            return new WebCamHandler();
        }
    }
}
