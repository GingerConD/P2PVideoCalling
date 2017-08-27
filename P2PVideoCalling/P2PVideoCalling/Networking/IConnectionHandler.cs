namespace P2PVideoCalling.Networking
{
    interface IConnectionHandler
    {
        void GetConnection();

        void AllowConnection();

        void MakeConnection(string hostName, int portNumber);

        void CloseConnection();
    }
}
