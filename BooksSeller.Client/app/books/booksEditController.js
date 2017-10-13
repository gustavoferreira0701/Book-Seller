(function () {
    "use strict";

    function booksEditController() {
        var vm = this;
        vm.book = {};
        vm.originalBook = {};
        vm.title = '';
        vm.message = '';

        // Query the book using a service

        if (vm.book && vm.book.code) {
            vm.title = "Edit: " + vm.book.title;
        }
        else {
            vm.title = "New Book";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.book.code) {
                // Update Book
            } else {
                // Save a New Book
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalBook);
            vm.message = '';
        };

    }

    angular
    .module("booksSeller")
    .controller("booksEditController",
                 booksEditController);
}());
