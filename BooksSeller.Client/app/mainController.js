(function () {
    "use strict";

    function mainController($scope, $rootScope) {
        $rootScope.currency = 'R$'; // Default currency

        var vm = this;
        vm.editionMode = false;

    }

    angular
        .module("booksSeller")
        .controller("mainController",
            ["$scope", "$rootScope", mainController]);
})();