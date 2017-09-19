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
        vm.users = [];
           
        // The fold 

        function _init() {
            console.log("controller initialized");
            _getUsers();
        }

        function _getUsers() {
            console.log("get users called");
            // on page load get list of users
            mainService.get("/api/users/")
                .then(_getUsersSuccess)
                .catch(_getUsersFailed);

            function _getUsersSuccess(resp) {
                console.log("Get users success", resp);
                vm.users = resp.data.Items;
                console.log(vm.users);
            }

            function _getUsersFailed(err) {
                console.log("Get users failed", err);
            }
        }
    }
})();