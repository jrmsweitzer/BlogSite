(function () {
    'use strict';

    angular
        .module('app')
        .directive('viewBlog', viewBlog);

    function vieewBlog() {
        return {
            templateUrl: 'Content/App/Directives/directive.viewblog.html'
        };
    }

})();