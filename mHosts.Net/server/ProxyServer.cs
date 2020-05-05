using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mHosts.Net.forms;

namespace mHosts.Net.server
{
    public class ProxyServer : IDisposable
    {
        public readonly int Port = 1994;
        private Socket _socket;
        public bool IsBound => _socket.IsBound;
        private static HashSet<Socket> clients = new HashSet<Socket>();

        public ProxyServer(int port)
        {
            this.Port = port;
            _initSocket();
        }

        public ProxyServer()
        {
            _initSocket();
        }

        private void _initSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void OnStart()
        {
            if (_socket.IsBound)
            {
                return;
            }

            var point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            _socket.Bind(point);
            _socket.Listen(20);
            LogForm.Notice($"服务已启动：127.0.0.1:{Port}");
            var thread = new Thread(OnListen) {IsBackground = true};
            thread.Start(_socket);
        }

        private void OnListen(object socket)
        {
            var server = (Socket) socket;
            while (server.IsBound)
            {
                var client = server.Accept();
                new Thread(OnAccept).Start(client);
            }
        }

        private void OnAccept(object socket)
        {
            var client = (Socket) socket;
            LogForm.Notice($"收到请求:{client}");

            var buffer = new byte[4096];
            int count;
            while ((count = client.Receive(buffer)) > 0)
            {
                var str = Encoding.UTF8.GetString(buffer, 0, count);
                LogForm.Notice($"收到消息:{str}");
            }

            client.Send(Encoding.UTF8.GetBytes("Hello From Server"));
            client.Close();
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                _socket.Disconnect(false);
                _socket.Close();
                _socket.Dispose();
            }
        }
    }
}