(function () {
    'use strict';
    angular
        .module("mainApp")
        .directive("userInfoCard", userInfoCard);

    function userInfoCard() {
        return {
            templateUrl: "/Scripts/Directives/userInfoCard.html",
            restrict: "E"
        }
    }
})();