//Контроллер отправки сообщений
angular.module('messaging.ctrl.sendMessageController', [])
    .controller('sendMessageController', ['$scope', '$location', 'usersService', 'messagesService', '$routeParams', function ($scope, $location, usersService, messagesService, $routeParams) {
        $scope.user = {};
        usersService.getById($routeParams.id).success(function (data) {
            $scope.user = data;
        });
        
        //Отправка ответа
        if ($routeParams.messageId != undefined) {
            messagesService.getById($routeParams.messageId).success(function (data) {
                $scope.message = {};
                $scope.message.subject = 'Re: ' + data.Subject;
            });
        }
        
        //Отправить сообщение
        $scope.send = function () {
            if ($scope.messageWriteForm.$valid) {
                messagesService.sendMessage($scope.user.Id, $scope.message.subject, $scope.message.message);
                $location.path('/Messaging/Users');
            }
        };
        
        //Отменить отправку
        $scope.cancel = function () {
            $location.path('/Messaging/Users');
        };
    }]);
