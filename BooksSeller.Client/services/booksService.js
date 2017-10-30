(function () {
    "use strict";

    function booksService($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/Books/:id", {id: '@_Code'}, {
            update:{ 
                method:'PUT'
            }
        });        
    }

    angular
        .module("booksSeller")
        .factory("booksService", ["$resource", "appSettings", booksService]);
})();