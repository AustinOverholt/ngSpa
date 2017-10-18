(function () {
    'use strict';
    angular
        .module("mainApp")
        .directive("userInfoCard", userInfoCard);

    function userInfoCard() {
        return {
            templateUrl: "/Scripts/Directives/userInfoCard.html", // takes HTML from template
            restrict: "E", // restricts to element type
            controller: function ($scope) { // controller for directive functionality
                $scope.collapsed = false; // by default panel is not collapsed
                $scope.collapse = function () {
                    $scope.collapsed = !$scope.collapsed; // when heading clicked panel collapses
                } 
            }
        }
    }
})();