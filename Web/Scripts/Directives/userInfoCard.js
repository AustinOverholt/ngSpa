(function () {
    'use strict';
    angular
        .module("mainApp")
        .directive("userInfoCard", userInfoCard);

    function userInfoCard() {
        return {
            template: "User Info Card",
            restrict: "E"
        }
    }
})();