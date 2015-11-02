(function () {
    'use strict';

    angular
        .module('app')
        .controller('BlogController', BlogController);

    BlogController.$inject = ['blogService'];

    /* @ngInject */
    function BlogController(blogService) {
        var vm = this;

        vm.blogs = [];
        vm.getBlogs = getBlogs;
        vm.mostRecent = {};
        vm.mostLiked = {};

        activate();

        function activate() {
            return getBlogs();
        }

        //////////////////

        function getBlogs() {
            return blogService.getBlogs().then(function (response) {
                vm.blogs = response.data;
                vm.mostRecent = getMostRecent();
                return vm.blogs;
            });
        }

        function getMostRecent() {
            var sortedBlogs = vm.blogs.sort(function (a, b) {
                return a.CreateDate - b.CreateDate;
            }).reverse();
            return sortedBlogs[0];
        }
    }
})();