var BlogApp = angular.module('BlogApp', []);

BlogApp
    .controller('BlogController', ['$rootScope', '$scope', 'BlogService',
    function ($rootScope, $scope, BlogService) {
        $scope.BlogService = BlogService;
    }])
    .controller('BlogListController', ['$scope', '$http', 'getBlogs',
    function ($scope, $http, getBlogs) {
        $scope.getBlogs = getBlogs;
    }])
    .controller('BlogDetailsController', ['$rootScope', '$scope', 'BlogService',
    function ($rootScope, $scope, BlogService) {
        $scope.BlogService = BlogService;
    }]);

blogApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/blog/:blogId', {
                templateUrl: '/Blog/Blogs/',
                controller: 'BlogController'
            })
    }
])


BlogApp
    .service('BlogService', BlogService);


BlogApp
    .directive('ckeditor', function () {
        return {
            require: '?ngModel',
            link: function ($scope, elm, attr, ngModel) {
                var ck = CKEDITOR.replace(elm[0]);

                if (!ngModel) return;

                ck.on('instanceReady', function () {
                    ck.setData(ngModel.$viewValue);
                });

                function updateModel() {
                    $scope.$apply(function () {
                        ngModel.$setViewValue(ck.getData());
                    });
                }

                ck.on('change', updateModel);
                ck.on('key', updateModel);
                ck.on('dataReady', updateModel);

                ngModel.$render = function (value) {
                    ck.setData(ngModel.$viewValue);
                };
            }
        };
    })