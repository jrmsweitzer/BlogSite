﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('blogService', blogService);

    blogService.$inject = ['$http'];

    function blogService($http) {

        var service = {
            getBlogs: getBlogs,
            getBlog: getBlog
        };
        return service;

        //////////////////

        function getBlogs() {
            return $http.get('/api/v1/blogs')
                .success(function (data) {
                    return data;
                })
                .error(function (data) {
                    alert(data);
                });
        }

        function getBlog(blogTitle) {

            return $http({
                url: '/api/v1/blog/' + blogTitle,
                method: "GET",
                data: { blogTitle: blogTitle }
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