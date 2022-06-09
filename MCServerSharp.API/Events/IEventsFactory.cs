using System.Net.Sockets;

namespace MCServerSharp.Events
{
    public interface IEventsFactory
    {
        void OnClientConnected(object sender, TcpClient tcp, ref bool cancel);

        void OnPacketReceived(object sender, object packet, ref bool cancel);
    }
}