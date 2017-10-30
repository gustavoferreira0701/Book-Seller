(function () {
    "use strict";

    function mainController($rootScope) {
    }

    angular
        .module("booksSeller")
        .controller("mainController",["$scope", "$rootScope", mainController]);
})();