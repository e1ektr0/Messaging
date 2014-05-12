//Контоллер для панели навигации
angular.module('messaging.ctrl.navigationController', [])
    .controller('navigationController', ['$scope', '$location', function ($scope, $location) {

        //Определяет текущий путь
        $scope.isActive = function (route) {
            return $location.path().indexOf(route) > -1;
        };
        
    }]);

