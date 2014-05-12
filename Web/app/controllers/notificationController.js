//Контроллер для работы с уведомленими signalR о входящих сообщениях
angular.module('messaging.ctrl.notificationController', [])
    .controller('notificationController', ['$rootScope', function ($rootScope) {
        var messagesnotificationHub = $.connection.messagesNotificationHub;
        messagesnotificationHub.client.RecieveMessage = function (message) {
            noty({ text: 'U recieve message from ' + message.SenderEmail, type: 'information', layout: 'bottomRight' });
            $rootScope.$broadcast('recieveMessageFromSignalR', message);
        };
        
        $.connection.hub.start()
            .done(function () { console.log('Now connected, connection ID=' + $.connection.hub.id); })
            .fail(function () { console.log('Could not Connect!'); });
    }]);

