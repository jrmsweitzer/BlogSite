(function () {
    angular.module('app.blog')
    .config(blogConfig);

    function blogConfig($stateProvider) {
        var blogs = {
            name: 'blogs',
            url: '/blogs',
            templateUrl: 'Content/html/blogs/blogsbase.html'
        };
        var bloglist = {
            name: 'blogs.list',
            url: '/list',
            templateUrl: 'Content/html/blogs/list.html',
            controller: 'BlogController',
            controllerAs: 'blogCtrl'
        };
        var blogview = {
            name: 'blogs.detail',
            url: '/view/:blogTitle',
            templateUrl: 'Content/html/blogs/detail.html',
            controller: 'BlogDetailController',
            controllerAs: 'blogCtrl'
        };
        var blogedit = {
            name: 'blogs.edit',
            url: '/edit/:blogTitle',
            templateUrl: 'Content/html/blogs/edit.html',
            controller: 'BlogEditController',
            controllerAs: 'blogCtrl'
        };
        var blogCreate = {
            name: 'blogs.create',
            url: '/create',
            templateUrl: 'Content/html/blogs/create.html',
            controller: 'BlogCreateController',
            controllerAs: 'blogCtrl'
        };

        $stateProvider
            .state(blogs)
            .state(blogview)
            .state(bloglist)
            .state(blogedit)
            .state(blogCreate);
    };
})();