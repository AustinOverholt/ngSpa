(function () {
    "use strict";
    angular
        .module("mainApp")
        .controller("mainController", mainController);

    mainController.$inject = ["$scope", "mainService"];

    function mainController($scope, mainService) {

        var vm = this;
        vm.$scope = $scope;
        vm.mainService = mainService;
        vm.$onInit = _init;
        vm.person = { firstName: "Austin", lastName: "Overholt" };
           
        // The fold 

        function _init() {
            console.log("controller initialized");
            _getUsers();
        }

        function _getUsers() {
            console.log("get users called");
            // on page load get list of users
        }
    }
})();