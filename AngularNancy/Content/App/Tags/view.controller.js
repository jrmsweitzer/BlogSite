(function () {
    'use strict';

    angular
        .module('app.tags')
        .controller('TagDetailController', TagDetailController);

    TagDetailController.$inject = ['tagService', '$stateParams'];

    /* @ngInject */
    function TagDetailController(tagService, $stateParams) {
        var vm = this;

        vm.tag = {};
        activate();

        function activate() {
            return getTag();
        }

        /////////////////

        function getTag() {
            return tagService.getTag($stateParams.tagName).then(function (response) {
                vm.tag = response.data;
            });
        }
    }
})();