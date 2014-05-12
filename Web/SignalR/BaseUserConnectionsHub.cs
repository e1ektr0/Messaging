using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace Web.SignalR
{
    /// <summary>
    /// Базовый хаб для сопоставления пользователей с подключениями
    /// </summary>
    public class BaseUserConnectionsHub : Hub
    {
        public readonly static ConnectionMapping<string> Connections = new ConnectionMapping<string>();
        public override Task OnConnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Add(id, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Remove(id, Context.ConnectionId);

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            var id = Context.User.Identity.GetUserId();

            if (!Connections.GetConnections(id).Contains(Context.ConnectionId))
                Connections.Add(id, Context.ConnectionId);

            return base.OnReconnected();
        }
    }
}