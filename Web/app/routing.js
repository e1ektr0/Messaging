//Модуль messaging + роутинг
angular.module('messaging', [
    'ngSanitize',
    'ngRoute',
    'messaging.ctrl.usersController',
    'messaging.ctrl.sendMessageController',
    'messaging.ctrl.readMessageController',
    'messaging.ctrl.navigationController',
    'messaging.ctrl.messagesController',
    'messaging.ctrl.notificationController',
    'messaging.service.users',
    'messaging.service.messages',
    'chieffancypants.loadingBar',
    'ngAnimate'
]).config(['$routeProvider', '$locationProvider', function ($routeProvider) {

    $routeProvider.when('/Messaging/Users', {
        templateUrl: '/Messaging/Users',
        controller: 'usersController'
    });

    $routeProvider.when('/Messaging/Write/:id', {
        templateUrl: '/Messaging/MessageWrite',
        controller: 'sendMessageController'
    });

    $routeProvider.when('/Messaging/Read/:id', {
        templateUrl: '/Messaging/MessageRead',
        controller: 'readMessageController'
    });

    $routeProvider.when('/Messaging/Write/:id/:messageId', {
        templateUrl: '/Messaging/MessageWrite',
        controller: 'sendMessageController'
    });

    $routeProvider.when('/Messaging/Messages/:way', {
        templateUrl: '/Messaging/Messages',
        controller: 'messagesController'
    });

    $routeProvider.otherwise({ redirectTo: '/Messaging/Messages/Input' });
}]);