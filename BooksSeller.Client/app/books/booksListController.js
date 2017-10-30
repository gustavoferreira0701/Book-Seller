(function () {
    "use strict";

    function booksListController($http, appSettings, booksService) {
        var vm = this;
        vm.books = [];

        vm.orderCriteria = "";
        vm.orderDirection = false;        
        vm.searchParameter = "";
        
        function getBooks() {            
            booksService.query(function (data) {
                vm.books = data;
            });
        }
        
        vm.delete = function (book) {
            $http.delete(`${appSettings.serverPath}api/books/delete/${book.Code}`).then(getBooks);
        }

        vm.orderBy = function (criteria) {
            vm.orderCriteria = criteria;
            vm.orderDirection = !vm.orderDirection;
        }

        vm.searchBook = function (searchTerm) {
            if(searchTerm == undefined || searchTerm.trim() === ""){
                getBooks();
            }else{
                $http.get(`${appSettings.serverPath}api/books/filter?title=${searchTerm}`).then(function (response) {                
                    vm.books = response.data;
                });
            }           
        }

        getBooks();

    }

    angular
        .module("booksSeller")
        .controller("booksListController", booksListController);
}());