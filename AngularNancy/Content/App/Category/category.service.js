(function () {
    'use strict';

    angular
        .module('app')
        .factory('categoryService', categoryService);

    categoryService.$inject = ['$http'];

    function categoryService($http) {

        var service = {
            getCategories: getCategories,
            getCategory: getCategory
        };
        return service;

        //////////////////

        function getCategories() {
            return $http({
                url: '/api/v1/categories',
                method: "GET"
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });
        }

        function getCategory(categoryID) {
            return $http({
                url: '/api/v1/categories/' + categoryID,
                method: "GET",
                data: { categoryID: categoryID }
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });
        }

    }
})();