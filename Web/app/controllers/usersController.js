angular.module('messaging.ctrl.usersController', [])
    .controller('usersController', ['$scope', '$location', 'usersService', function ($scope, $location, usersService) {
        $scope.users = [];
        usersService.getAll().success(function (data) {
            $scope.users = data;
        });
        
        //Перейти к написанию сообщения для этого пользователя
        $scope.sendMessage = function (id) {
            $location.path('/Messaging/Write/' + id);
        };

    }]);

