(function () {
    angular
        .module('app.tags')
        .config(tagsConfig);

    function tagsConfig($stateProvider) {
        var tags = {
            name: 'tags',
            url: '/tags',
            template: "'<div ui-view></div>'"
        };
        var tagslist = {
            name: 'tags.list',
            url: '/list',
            templateUrl: 'Content/App/Tags/list.html',
            controller: 'TagsListController',
            controllerAs: 'vm'
        };
        var viewtag = {
            name: 'tags.view',
            url: '/:tagName',
            templateUrl: 'Content/App/Tags/view.html',
            controller: 'TagDetailController',
            controllerAs: 'vm'
        };

        $stateProvider
            .state(tags)
            .state(tagslist)
            .state(viewtag);
    };


})();