(function () {
    var injectParams = ['$location', '$filter', '$window',
                        '$timeout', 'authService', 'blogsService', 'modalService'];

    var BlogsController = function ($location, $filter, $window,
        $timeout, authService, blogsService, modalService) {

        var vm = this;

        vm.blogs = [];
        vm.filteredBlogs = [];

        function init() {
            getBlogsSummary();
        }

        function getBlogsSummary() {
            blogsService.getBlogsSummary()
            .then(function (data) {
                vm.blogs = data.results;
            }, function (error) {
                $window.alert('Sorry, an error occurred: ' + error.data.message);
            });
        }

        init();
    };

    BlogsController.$inject = injectParams;

    angular.module('customersApp').controller('BlogsController', BlogsController);

}());