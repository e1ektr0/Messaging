//Сервис пользователей
angular.module("messaging.service.users", []).factory('usersService', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http({ method: 'GET', url: '/api/User' });
        },
        getById: function (id) {
            return $http({ method: 'GET', url: '/api/User/GetById/' + id });
        }
    };
}]);