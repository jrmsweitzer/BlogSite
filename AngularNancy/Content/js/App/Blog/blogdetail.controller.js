(function () {
    'use strict';

    angular
        .module('app')
        .controller('BlogDetailController', BlogDetailController);

    BlogDetailController.$inject = ['blogService', '$stateParams'];

    /* @ngInject */
    function BlogDetailController(blogService, $stateParams) {
        var vm = this;

        vm.blogTitle = $stateParams.Title;
        vm.blog = {};

        activate();

        function activate() {
            return getBlog();
        }

        //////////////////

        function getBlog() {
            return blogService.getBlog(vm.blogTitle).then(function (response) {
                vm.blog = response.data;
                return vm.blog;
            });
        }
    }
})();