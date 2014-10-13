(function() {
    'use strict';
      
    var app = angular.module("app", ['ngRoute', 'ui.bootstrap'])
        .config(function ($routeProvider) {
            $routeProvider
            .when("/", {templateUrl:'/partials/home.partial.html', controller:'homeCtrl'})
        });
    
    app.value("apiPort", "60455");

})();