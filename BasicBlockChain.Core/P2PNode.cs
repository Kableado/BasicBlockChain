using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BasicBlockChain.Core
{
    public class NetNode
    {
        private PeerAddress _nodeAddress = null;

        private List<NetPeer> _peers = new List<NetPeer>();

        private Socket _listen = null;

        private Thread _thread = null;
        private bool _running = false;

        public NetNode(PeerAddress nodeAddress)
        {
            _nodeAddress = nodeAddress;

            StartListening();

            _running = true;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void AddPeer(PeerAddress peerAddress)
        {
            NetPeer newPeer = new NetPeer(_nodeAddress, peerAddress);
            lock (_peers)
            {
                _peers.Add(newPeer);
            }
        }

        private void StartListening()
        {
            _listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listen.Bind(new IPEndPoint(IPAddress.Any, _nodeAddress.Port));
            _listen.Listen(1000);
        }

        private void Run()
        {
            while (_running)
            {
                if (_listen.Poll(100, SelectMode.SelectRead) == false) { continue; }

                Socket newSock = _listen.Accept();

                NetPeer newPeer = new NetPeer(_nodeAddress, null, newSock);
                lock (_peers)
                {
                    _peers.Add(newPeer);
                }
            }
        }
    }

    public class PeerAddress
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }

    public class NetPeer
    {
        private PeerAddress _nodeAddress = null;
        private PeerAddress _peerAddress = null;

        private Socket _socket = null;

        private Thread _thread = null;
        private bool _running = false;

        private enum PeerStatus
        {
            None,
            SendingId,
            WaitingId,
            Idle,
            Ended,
        };
        private PeerStatus _status = PeerStatus.None;

        public NetPeer(PeerAddress nodeAddress, PeerAddress peerAddress, Socket socket = null)
        {
            _nodeAddress = nodeAddress;
            _peerAddress = peerAddress;

            _socket = socket;

            _status = PeerStatus.Idle;
            if (_socket == null)
            {
                ConnectPeer();
                _status = PeerStatus.SendingId;
            }
            if (peerAddress == null)
            {
                _status = PeerStatus.WaitingId;
            }

            _socket.Blocking = false;
            _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

            _running = true;
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void ConnectPeer()
        {
            IPAddress ipAddress = IPAddress.Parse(_peerAddress.Address);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(ipAddress, _peerAddress.Port);
        }

        private void Run()
        {
            while (_running)
            {
                _socket.Poll(1, SelectMode.SelectRead);
                // TODO
            }
        }
    }
}
