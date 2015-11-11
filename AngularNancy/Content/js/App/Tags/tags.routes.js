(function () {
    angular.module('app.tags')
    .config(tagsConfig);

    function tagsConfig($stateProvider) {
        var tags = {
            name: 'tags',
            url: '/tags',
            templateUrl: 'Content/html/tags/base.html'
        };

        $stateProvider
            .state(tags);
    };


})();