(function () {
    'use strict';

    angular
        .module('app.tags')
        .factory('blogTagService', blogTagService);

    blogTagService.$inject = ['$http'];

    function blogTagService($http) {

        var service = {
            getTags: getTags
        };
        return service;

        /////////////////////

        function getTags(blogId) {
            return $http({
                url: '/api/v1/tags/' + blogId,
                method: "GET",
                data: {blogId, blogId}
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