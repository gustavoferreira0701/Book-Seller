(function () {
    "use strict";

    function booksService($resource, appSettings) {
        return {
            get: $resource(appSettings.serverPath + "/api/Books/:id", null),
            getAll: $resource(appSettings.serverPath + "/api/Books", null),
            save: $resource(appSettings.serverPath + "/api/Books", null,
            {
                'save': { method: 'POST' }
            })
        }
    }

    angular
        .module("booksSeller")
        .factory("booksService",
                  ["$resource", "appSettings",
                   booksService]);
})();