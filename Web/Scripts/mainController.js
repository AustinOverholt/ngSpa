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
        vm.users = {};
        vm.scraperForm = {};
        vm.scrapedResults = {};
        vm.scraperHtml = {};
        vm.scraperAttributes = {};
        vm.usersForm = {};
        vm.scraperForm = {};
        vm.editUser = null;
        vm.deleteButton = _deleteButton;
        vm.editButton = _editButton;
        vm.postScraper = _postScraper;
        
           
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
            if (vm.editUser == null) {
                mainService.post("/api/users/", vm.usersForm)
                    .then(_postSuccess)
                    .catch(_postFailed);

                function _postSuccess(res) {
                    console.log("Post users success", res);
                }

                function _postFailed(err) {
                    console.log("Post users failed", err);
                }
            } else {
                mainService.put("/api/users/", vm.editUser, vm.usersForm)
                    .then(_putSuccess)
                    .catch(_putFailed);

                function _putSuccess(res) {
                    console.log("Put Success", res);
                }

                function _putFailed(err) {
                    console.log("Put Failed", err);
                }

            }
        }

        function _editButton(data) {
            mainService.getById("/api/users/", data)
                .then(_getByIdSuccess)
                .catch(_getByIdFailed)

            function _getByIdSuccess(res) {
                vm.editUser = data;
                console.log(vm.editUser);
                console.log("Get Success", res);
                vm.usersForm = res.data.Item; 
            }

            function _getByIdFailed(err) {
                console.log("Get Failed", err);
            }
        }

        function _deleteButton(data, index) { 
            mainService.delete("/api/users/", data)
                .then(_deleteSuccess)
                .catch(_deleteFailed)

            function _deleteSuccess(res) {
                console.log("Delete Success", res);
                vm.users.splice(index, 1);
            }

            function _deleteFailed(err) {
                console.log("Delete Failed", err);
            }
        }

        function _postScraper() {
            console.log(vm.scraperForm);
            mainService.post("/api/scrape/", vm.scraperForm)
                .then(_postSuccess)
                .catch(_postFailed)

            function _postSuccess(res) {
                console.log("Post Successful", res);
                vm.scrapedResults = res.data.Items;
                // insert scraped results into db
            }

            function _postFailed(err) {
                console.log("Post Failed", err);
            }


        }

    }
})();