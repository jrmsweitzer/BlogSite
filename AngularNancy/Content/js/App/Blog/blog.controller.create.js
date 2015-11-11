(function () {
    'use strict';

    angular
        .module('app.blog')
        .controller('BlogCreateController', BlogCreateController);

    BlogCreateController.$inject = ['blogService'];

    function BlogCreateController(blogService) {

        var vm = this;
        vm.blog = {

        };
        vm.submit = submit;

        activate();

        function activate() {
            return vm.blog;
        }

        //////////////////////

        function submit() {
            if (isValid(vm.blog)) {
                return blogService.addBlog(vm.blog);
            }
        }

        function isValid() {
            return vm.blog &&
                    vm.blog.title &&
                    vm.blog.post &&
                    vm.blog.postPreview;
        }
    }
})();
