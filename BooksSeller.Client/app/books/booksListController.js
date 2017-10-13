(function () {
    "use strict";

    function booksListController() {
        var vm = this;
        vm.books = [];

    }

    angular
        .module("booksSeller")
        .controller("booksListController", 
            booksListController);
}());