(function() {
    'use strict';
    angular
        .module('app')
        .controller('homeCtrl', ['$scope', HomeController ]);
        
        function HomeController($scope)
        {
            $scope.coucou = "salut";
        }   
    
})();