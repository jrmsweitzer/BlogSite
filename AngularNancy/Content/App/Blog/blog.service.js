(function () {
    'use strict';

    angular
        .module('app.blog')
        .factory('blogService', blogService);

    blogService.$inject = ['$http'];

    function blogService($http) {

        var service = {
            getBlogs: getBlogs,
            getBlogsByUser: getBlogsByUser,
            getBlog: getBlog,
            addBlog: addBlog,
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

        function getBlogsByUser(userName) {
            return $http({
                url: '/api/v1/blogs/' + userName,
                method: "GET",
                data: { userName, userName }
            })
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

        function addBlog(blog) {
            
            return $http({
                url: '/api/v1/blog/new',
                method: "POST",
                data: blog
            })
            .success(function (data) {
                $location.start();
                $location.url('/blogs')
            })
            .error(function (data) {
                alert("There was an error when attempting to Add New Blog. Please try again later.")
            });
        }
    }

})();