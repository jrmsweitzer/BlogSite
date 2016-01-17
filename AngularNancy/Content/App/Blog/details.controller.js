(function () {
    'use strict';

    angular
        .module('app.blog')
        .controller('BlogDetailController', BlogDetailController);

    BlogDetailController.$inject = ['blogService', '$stateParams'];

    /* @ngInject */
    function BlogDetailController(blogService, $stateParams) {
        var vm = this;

        vm.blog = {};
        activate();

        function activate() {
            return getBlog();
        }

        //////////////////

        function getBlog() {
            return blogService.getBlog($stateParams.blogTitle).then(function (response) {
                vm.blog = response.data;
                vm.blog.Url = "http://localhost:12008/#/blogs/view/" + vm.blog.Title;
            });
        }
    }
})();