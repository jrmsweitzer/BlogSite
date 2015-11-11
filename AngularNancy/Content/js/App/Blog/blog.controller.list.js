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
                vm.blogs = setTags();
                return vm.blogs;
            });
        }

        function setTags() {
            var newList = [];
            for (var i = 0; i < vm.blogs.length; i++) {
                var newBlog = vm.blogs[i];
                newBlog.tagsCS = newBlog.Tags.split(', ');
                newList.push(newBlog);
            }
            return newList;
        }

        function getMostRecent() {
            var sortedBlogs = vm.blogs.sort(function (a, b) {
                return a.CreateDate - b.CreateDate;
            }).reverse();
            return sortedBlogs[0];
        }
    }
})();