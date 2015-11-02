(function () {

    angular.module('app')
        .config(appConfig)
        .run(['$state', function ($state) {
            $state.transitionTo('home');
        }]);

    function appConfig($stateProvider) {

        var home = {
            name: 'home',
            url: '/',
            templateUrl: 'Content/html/home/landing.html'
        },
        blogs = {
            name: 'blogs',
            url: 'blogs/list',
            templateUrl: 'Content/html/blogs/blogsbase.html'
        },
        bloglist = {
            name: 'blogs.list',
            parent: blogs,
            url: 'blogs/list',
            templateUrl: 'Content/html/blogs/list.html',
            controller: BlogController,
            controllerAs: 'blogCtrl'
        },
        blogdetail = {
            name: 'blogs.detail',
            parent: blogs,
            url: '/:blogTitle',
            templateUrl: 'Content/html/blogs/detail.html',
            controller: BlogDetailController,
            controllerAs: 'blogCtrl',
        };

        $stateProvider.state(home);
        $stateProvider.state(blogs);
        $stateProvider.state(blogdetail);
        $stateProvider.state(bloglist);


    }

})();