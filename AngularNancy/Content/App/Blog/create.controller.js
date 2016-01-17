(function () {
    'use strict';

    angular
        .module('app.blog')
        .controller('BlogCreateController', BlogCreateController);

    BlogCreateController.$inject = ['blogService', 'categoryService'];

    function BlogCreateController(blogService, categoryService) {

        var vm = this;

        vm.blog = {
            post: '<p>Hello World!</p>'
        };
        vm.categories = [];

        vm.submit = submit;

        activate();

        function activate() {
            getCategories();
            return vm.blog;
        }

        //////////////////////

        function getCategories() {
            categoryService.getCategories().then(function (response) {
                vm.categories = response.data;
                return vm.categories;
            })
        }

        function submit() {
            if (isValid(vm.blog)) {
                return blogService.addBlog(vm.blog);
            }
        }

        function isValid() {
            return vm.blog &&
                    vm.blog.title &&
                    vm.blog.post &&
                    vm.blog.postPreview
        }
    }
})();
