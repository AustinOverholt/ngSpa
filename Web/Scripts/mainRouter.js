(function () {
    'use strict';
    angular
        .module('routerApp', ['ui.router'])
        .config(function ($stateProvider, $urlRouteProvider) {

            $urlRouteProvider.otherwise('/home');

            $stateProvider

                .state('home', {
                    url: '/home',
                    templateUrl: 'Views/Partial/partial-home.html'
                })

                .state('about', {
                    url: '/about',
                    templateUrl: 'partial-about.html'
                })

                .state('contact', {
                    url: '/contact',
                    templateUrl: 'partial-contact.html'
                });

        });



})();