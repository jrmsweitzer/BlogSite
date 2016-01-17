(function () {
    'use strict';

    angular
        .module('app')
        .directive('blogListingInd', blogListingInd);

    function blogListingInd() {
        return {
            templateUrl: 'Content/App/Directives/directive.bloglistingind.html'
        };
    }

})();