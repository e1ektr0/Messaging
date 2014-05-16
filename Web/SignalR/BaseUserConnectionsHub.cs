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
        /// <summary>
        /// Список подключений
        /// </summary>
        public readonly static ConnectionMapping<string> Connections = new ConnectionMapping<string>();

        /// <summary>
        /// Перегрузка метода подключения для отслеживания соединейни пользователя
        /// </summary>
        public override Task OnConnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Add(id, Context.ConnectionId);

            return base.OnConnected();
        }


        /// <summary>
        /// Перегрузка метода отключения для удалиения устаревшего id пользователя
        /// </summary>
        public override Task OnDisconnected()
        {
            var id = Context.User.Identity.GetUserId();

            Connections.Remove(id, Context.ConnectionId);

            return base.OnDisconnected();
        }

        /// <summary>
        /// Перегрузка метода переподключния для добавления коннекта к пользователю
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