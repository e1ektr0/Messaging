using System.Collections.Generic;
using System.Linq;

namespace Web.SignalR
{
    /// <summary>
    /// Структура для хранения соединений пользователей
    /// </summary>
    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections = new Dictionary<T, HashSet<string>>();

        /// <summary>
        /// Обзее колличесво соединений
        /// </summary>
        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        /// <summary>
        /// Добавить соединение пользователя
        /// </summary>
        public void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        /// <summary>
        /// Вернёт список соединений пользователя
        /// </summary>
        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Удаляет соединение пользователя из словаря
        /// </summary>
        public void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}