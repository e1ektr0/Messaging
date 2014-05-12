//Контроллер списка сообщений
angular.module('messaging.ctrl.messagesController', ['infinite-scroll'])
    .controller('messagesController', ['$scope', '$location', 'messagesService', '$routeParams', function ($scope, $location, messagesService, $routeParams) {
        $scope.messages = {};
        $scope.sorting = { 'column': "SendDate", 'directionWay': 'Desc' };
        $scope.changeSorting = function (column) {
            $scope.sorting.column = column;
            $scope.reloadMessages();
        };

        //Удаление сообщения
        $scope.deleteMessage = function (id) {
            
            //Удаляем сообщение на сервере
            messagesService.deleteMessage(id, $routeParams.way);
            
            //Удаляем из скоупа
            for (var i = 0; i < $scope.messages.length; i++) {
                if ($scope.messages[i].Id == id) {
                    $scope.messages.splice(i, 1);
                    break;
                }
            }
        };
        
        //Перейти на список пользователей
        $scope.goToUsers = function () {
            $location.path('/Messaging/Users');
        };
        
        ///Ответ
        $scope.reply = function (id, messageId) {
            $location.path('/Messaging/Write/' + id + '/' + messageId);
        };
        
        //Презагрузить список сообщений
        $scope.reloadMessages = function () {
            messagesService.getScrolled($routeParams.way, 0, 20, $scope.sorting.column, $scope.sorting.directionWay).success(function (data) {
                $scope.messages = data;
            });
        };
        
        //Подписываемся на события пушуведомления от сигналр о приходе сообщения
        $scope.$on('recieveMessageFromSignalR', function () {
            $scope.reloadMessages();
        });

        //Загрузка сообщений для инфинити скрола
        $scope.loadMessage = false;
        $scope.loadMore = function () {
            if ($scope.loadMessage)
                return;
            $scope.loadMessage = true;
            var last = $scope.messages[$scope.messages.length - 1];
            if (last == null) {
                $scope.reloadMessages();
            } else {
                messagesService.getScrolled($routeParams.way, $scope.messages.length, 2, $scope.sorting.column, $scope.sorting.directionWay).success(function (data) {
                    for (var i = 0; i < data.length; i++) {
                        $scope.messages.push(data[i]);
                    }
                });
            }
            $scope.loadMessage = false;
        };
        $scope.showMessage = function (messageId) {
            $location.path('/Messaging/Read/' + messageId);
        }
    }]);