(function () {
    'use strict';

    angular
        .module('app.tags')
        .factory('tagService', tagService);

    tagService.$inject = ['$http'];

    function tagService($http) {

        var service = {
            getTags: getTags,
            getTag: getTag
        };
        return service;

        //////////////////

        function getTags() {
            return $http({
                url: '/api/v1/tags',
                method: "GET"
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });
        }

        function getTag(tagName) {
            return $http({
                url: '/api/v1/tags/' + tagName,
                method: "GET",
                data: { tagName: tagName }
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