using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace Web.SignalR
{
    /// <summary>
    /// ������� ��� ��� ������������� ������������� � �������������
    /// </summary>
    public class BaseUserConnectionsHub : Hub
    {
        /// <summary>
        /// ������ �����������
        /// </summary>
        public readonly static ConnectionMapping<string> Connections = new ConnectionMapping<string>();

        /// <summary>
        /// ���������� ������ ����������� ��� ������������ ���������� ������������
        /// </summary>
        public override Task OnConnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Add(id, Context.ConnectionId);

            return base.OnConnected();
        }


        /// <summary>
        /// ���������� ������ ���������� ��� ��������� ����������� id ������������
        /// </summary>
        public override Task OnDisconnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Remove(id, Context.ConnectionId);

            return base.OnDisconnected();
        }

        /// <summary>
        /// ���������� ������ �������������� ��� ���������� �������� � ������������
        /// </summary>
        public override Task OnReconnected()
        {
            var id = Context.User.Identity.GetUserId();

            if (!Connections.GetConnections(id).Contains(Context.ConnectionId))
                Connections.Add(id, Context.ConnectionId);

            return base.OnReconnected();
        }
    }
}