(function () {
    "use strict";

    function booksEditController($routeParams, $location, $http, appSettings, booksService) {
        
        var vm = this;

        if($routeParams.bookId != undefined){            
            $http.get(`${appSettings.serverPath}api/books/get/${$routeParams.bookId}`)
                 .then(function (result) {                
                        vm.originalBook = result.data;    
                        vm.book = angular.copy(vm.originalBook);
                  });
        }else{
            vm.originalBook = {}
            vm.book = angular.copy(vm.originalBook);
        }

        vm.title = '';
        vm.message = '';        

        // Query the book using a service
        vm.title = (vm.book && vm.book.code)? "Edit: " + vm.book.title:"New Book";

        vm.submit = function () {
            vm.message = '';

            if(angular.equals(vm.originalBook, {}) || vm.originalBook.Code !== vm.book.Code){
                $http.post(`${appSettings.serverPath}api/books/post/`, vm.book).then(function () {
                    $location.path("/");
                });
            }else{

                $http.put(`${appSettings.serverPath}api/books/put/${vm.book.Code}`, vm.book).then(function () {
                    $location.path("/");
                });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.book = angular.copy(vm.originalBook);
            vm.message = '';
        };

    }

    angular
    .module("booksSeller")
    .controller("booksEditController", booksEditController);
}());
