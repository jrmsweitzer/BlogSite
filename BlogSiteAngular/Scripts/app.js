(function () {
    var app = angular.module('store', []);

    app.controller('StoreController', ['$http', function ($http) {
        var store = this;

        store.blogs = [];

        $http({
            method: 'GET',
            url: '/blogs/all'
        }).then(function successCallback(data) {
            alert(response);
            store.blogs = data;
        }, function errorCallback(response) {
            alert(response);
        });

        //$http.get('/blogs/all/')
        //    .success(function (data) {
        //        store.blogs = data;
        //    })
    }]);
})();