//Контроллер просмотра сообщений
angular.module('messaging.ctrl.readMessageController', [])
    .controller('readMessageController', ['$scope', '$location', 'messagesService', '$routeParams', function ($scope, $location, messagesService, $routeParams) {
        $scope.message = {};
        messagesService.getById($routeParams.id).success(function (data) {
            $scope.message = data;
        });

        //Назад
        $scope.back = function () {
            $location.path('/Messaging/Messages/Input');
        };
    }]);
