(function () {
    'use strict';
    angular
        .module('mainApp')
        .controller('mainController', mainController);

    mainController.$inject = ['$scope', 'mainService'];

    function mainController($scope, mainService) {

        var vm = this;
        vm.$scope = $scope;
        vm.mainService = mainService;
        vm.$onInit = _init;
        vm.people = [
            { firstName: "Austin", lastName: "Overholt" },
            { firstName: "Allie", lastName: "Overholt" }
        ];


        // The fold 

        function _init() {
            console.log('controller initialized');
        }

    }


})();