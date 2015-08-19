(function () {

    var injectParams = ['$http', '$q'];

    var blogsFactory = function ($http, $q) {
        var serviceBase = '/api/dataservice',
            factory = {};

        factory.getBlogs = function () {
            return getPagedResource('blogs');
        };

        function getPagedResource(baseResource) {
            return $http.get('/api/dataservice/blogs').then(function (response) {
                var blogs = response.data;
                return {
                    results: blogs
                };
            });
        }
    }
})