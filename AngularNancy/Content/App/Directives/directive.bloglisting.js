(function () {
    'use strict';

    angular
        .module('app')
        .directive('myBlogListing', myBlogListing);

    function myBlogListing() {
        return {
            templateUrl: 'Content/App/Directives/directive.bloglisting.html'
        };
    }

})();