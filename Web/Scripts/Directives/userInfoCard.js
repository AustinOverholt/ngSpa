(function () {
    'use strict';
    angular
        .module("mainApp")
        .directive("userInfoCard", userInfoCard);

    function userInfoCard() {
        return {
            template: "User Info Card <br/> Name: {{mainCtrl.users[0].FirstName}} <br/> Initial: {{mainCtrl.users[0].MiddleInitial}} <br/> Last Name: {{mainCtrl.users[0].LastName}} </br>",
            restrict: "E"
        }
    }
})();