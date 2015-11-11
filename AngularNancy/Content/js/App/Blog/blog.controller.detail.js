(function () {
    'use strict';

    angular
        .module('app')
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
                vm.blog = setTags();
            });
        }

        function setTags() {
            vm.blog.tagsCS = vm.blog.Tags.split(', ');
            return vm.blog;
        }
    }
})();