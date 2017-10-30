angular.module("booksSeller")
    .config(function ($routeProvider) {

        var books_directory = "app/books";

        $routeProvider.when('/', {
            'templateUrl': `${books_directory}/booksListView.html`,
            'controller': 'booksListController as vm'
        }).when('/books/new', {
            'templateUrl': `${books_directory}/booksEditView.html`,
            'controller': 'booksEditController as vm'
        }).when('/books/edit/:bookId', {
            'templateUrl': `${books_directory}/booksEditView.html`,
            'controller': 'booksEditController as vm'
        }).otherwise({
            'redirectTo': '/'
        });
    });