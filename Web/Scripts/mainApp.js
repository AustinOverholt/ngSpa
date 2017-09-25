(function () {
    "use strict";
    angular
        .module("mainApp", ["ui.router"])
        .config(function ($stateProvider) {

            var home = {
                    name: 'home',
                    url: '/home',
                    templateUrl: '/Scripts/Routes/Home.html'
            }

            var scraper = {
                name: 'scraper',
                url: '/scraper',
                templateUrl: '/Scripts/Routes/Scraper.html'
            }

            var users = {
                name: 'users',
                url: '/users',
                templateUrl: '/Scripts/Routes/Users.html'
                // controller: ??
            }

            $stateProvider.state(home);
            $stateProvider.state(scraper);
            $stateProvider.state(users);

        });
})();