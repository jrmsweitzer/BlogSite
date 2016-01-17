(function () {
    'use strict';

    angular
        .module('app.blog')
        .controller('BlogController', BlogController);

    BlogController.$inject = ['blogService'];

    /* @ngInject */
    function BlogController(blogService) {
        var vm = this;

        vm.blogs = [];
        vm.blogsloaded = false;
        vm.getBlogs = getBlogs;
        vm.predicate = 'createDate';
        vm.reverse = true;
        vm.order = order;

        activate();

        function activate() {
            return getBlogs();
        }

        //////////////////

        function getBlogs() {
            return blogService.getBlogs().then(function (response) {
                vm.blogs = response.data;
                vm.blogsloaded = true;
                return vm.blogs;
            });
        }

        function order(predicate) {
            vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
            vm.predicate = predicate;
        }
    }
})();