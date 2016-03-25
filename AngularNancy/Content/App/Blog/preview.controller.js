(function () {
    'use strict';

    angular
        .module('app.blog')
        .controller('BlogPreviewController', BlogPreviewController);

    preview.$inject = ['blogService', 'categoryService'];

    function BlogPreviewController(blogService, categoryService) {

        var vm = this;

        

        activate();

        function activate() { }
    }
})();
