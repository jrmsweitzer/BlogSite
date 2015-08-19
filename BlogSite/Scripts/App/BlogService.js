angular.module('BlogApp.services', [])
    .factory('BlogService', ['$http', function ($http) {

        

        return {
            events: function () { return getBlogs(); },
        };
    }]);


BlogApp.factory('getBlogs', ['$document', function ($document) {
    var getBlogs = function () {

        $http.get('/api/BlogApi/GetBlogs')
            .success(function (data, status, headers, config) {
                console.log(data);
                $scope.blogs = data;
            });
    };
    return getBlogs;
}])