(function () {
    'use strict';
    angular
        .module('mainApp', ['ui.router'])
        .config(function ($stateProvider) {

            $stateProvider

                .state('home', {
                    url: '/home',
                    template: '<h1>Hello World</h1>'
                    //templateUrl: 'Views/Partial/partial-home.html'
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