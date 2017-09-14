(function () {
    'use strict';
    angular
        .module('mainApp', ['ui.router'])
        .config(function ($stateProvider) {

            var home = {
                    name: 'home',
                    url: '/home',
                    templateUrl: '/Scripts/Routes/Home.html'
            }

            var about = {
                    name: 'about',
                    url: '/about',
                    templateUrl: '/Scripts/Routes/About.html'
            }

            var contact = {
                name: 'contact',
                url: '/contact',
                templateUrl: '/Scripts/Routes/Contact.html'
            }

            var users = {
                name: 'users',
                url: '/users',
                templateUrl: '/Scripts/Routes/Users.html'
                // controller: ??
            }

            $stateProvider.state(home);
            $stateProvider.state(about);
            $stateProvider.state(contact);
            $stateProvider.state(users);

        });
})();