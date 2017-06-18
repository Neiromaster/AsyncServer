using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Model.DataBaseModel;

namespace AsyncServer
{
    public class AsyncService : IAsyncService
    {
        private UserContext _db = new UserContext();
        private readonly int _port;

        public AsyncService(int port)
        {
            _port = port;
        }


        public async void Run()
        {
            var listener = new TcpListener(IPAddress.Any, _port);
            listener.Start(10);
            Debug.WriteLine("Service running on port " + _port);
            while (true)
            {
                try
                {
                    new ClientProcess(_db).Process(await listener.AcceptTcpClientAsync());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}