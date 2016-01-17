(function () {
    'use strict';

    angular
        .module('app.tags')
        .controller('BlogTagController', BlogTagController);

    BlogTagController.$inject = ['blogTagService'];

    /* @ngInject */
    function BlogTagController(blogTagService) {
        var vm = this;

        vm.getTags = getTags;

        activate();

        function activate() {
            return this;
        }

        ///////////////////////

        function getTags(blogId) {
            return blogTagService.getTags(blogId).then(function (response) {
                return response.data;
            });
        }


    }
})();