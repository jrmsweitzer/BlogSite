(function () {
    angular.module('app.blog')
    .config(blogConfig);

    function blogConfig($stateProvider) {
        var blogs = {
            name: 'blogs',
            url: '/blogs',
            template: "'<div ui-view></div>'"
        };
        var bloglist = {
            name: 'blogs.list',
            url: '/list',
            templateUrl: 'Content/App/Blog/list.html',
            controller: 'BlogController',
            controllerAs: 'vm'
        };
        var blogview = {
            name: 'blogs.detail',
            url: '/view/:blogTitle',
            templateUrl: 'Content/App/Blog/details.html',
            controller: 'BlogDetailController',
            controllerAs: 'vm'
        };
        var blogedit = {
            name: 'blogs.edit',
            url: '/edit/:blogTitle',
            templateUrl: 'Content/html/blogs/edit.html',
            controller: 'BlogEditController',
            controllerAs: 'vm'
        };
        var blogCreate = {
            name: 'blogs.create',
            url: '/create',
            templateUrl: 'Content/App/Blog/create.html',
            controller: 'BlogCreateController',
            controllerAs: 'vm'
        };

        $stateProvider
            .state(blogs)
            .state(blogview)
            .state(bloglist)
            .state(blogedit)
            .state(blogCreate);
    };
})();