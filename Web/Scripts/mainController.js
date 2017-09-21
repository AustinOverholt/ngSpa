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
        vm.postUsers = _postUsers;
        vm.$onInit = _init;
        vm.config = [{
            "displayLength": "10",
            "displayStart": "0",
            "sortCol": "0",
            "sortDir": "asc",
            "search": ""
        }]
        vm.users = {};
        vm.usersForm = {};
           
        // The fold 

        function _init() {
            console.log("controller initialized");
            // do post for grid
            _getUsers();
        }

        function _getUsers() {
            console.log("get users called");
            // on page load get list of users
            mainService.get("/api/users/")
                .then(_getUsersSuccess)
                .catch(_getUsersFailed);

            function _getUsersSuccess(res) {
                console.log("Get users success", res);
                vm.users = res.data.Items;
                console.log(vm.users);
            }

            function _getUsersFailed(err) {
                console.log("Get users failed", err);
            }
        }

        function _postUsers() {
            console.log(vm.usersForm);
            mainService.post("/api/users/", vm.usersForm)
                .then(_postUserSuccess)
                .catch(_postUserFailed);

            function _postUserSuccess(res) {
                console.log("Post users success", res);
            }

            function _postUserFailed(err) {
                console.log("Post users failed", err);
            }
        }

    }
})();