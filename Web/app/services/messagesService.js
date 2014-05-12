//Сервис сообщений
angular.module("messaging.service.messages", []).factory('messagesService', ['$http', function ($http) {
    return {
        getAll: function (way) {
            return $http({ method: 'GET', url: '/api/Message/' + way });
        },
        deleteMessage: function (id, way) {
            return $http({ method: 'POST', url: '/api/Message/Delete' + way + '/' + id });
        },
        getById: function (id) {
            return $http({ method: 'GET', url: '/api/Message/GetById/' + id });
        },
        getScrolled: function (way,  skip, count, sortingColumn, sortingDirection) {
            return $http({
                method: 'POST',
                url: '/api/Message/' + way,
                data: {
                    'Skip': skip,
                    'Count': count,
                    'SortingColumn': sortingColumn,
                    'SortingDirection': sortingDirection
                }
            });
        },
        sendMessage: function (userId, subject, message) {
            return $http({
                method: 'POST',
                url: '/api/Message/SendMessage/',
                data: {
                    'receiverId': userId,
                    'subject': subject,
                    'content': message
                }
            });
        }
    };
}]);
