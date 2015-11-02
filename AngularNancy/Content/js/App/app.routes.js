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
        };
        var blogs = {
            name: 'blogs',
            url: '/blogs',
            templateUrl: 'Content/html/blogs/blogsbase.html'
        };
        var bloglist = {
            name: 'list',
            parent: blogs,
            url: '/list',
            templateUrl: 'Content/html/blogs/list.html',
            //controller: BlogController,
            //controllerAs: 'blogCtrl'
        };
        var blogdetail = {
            name: 'blogs.detail',
            //parent: blogs,
            url: '/:blogTitle/view',
            templateUrl: 'Content/html/blogs/detail.html',
            //controller: BlogDetailController,
            //controllerAs: 'blogCtrl',
        };

        $stateProvider.state(home);
        $stateProvider.state(blogs);
        $stateProvider.state(blogdetail);
        $stateProvider.state(bloglist);


    }

})();