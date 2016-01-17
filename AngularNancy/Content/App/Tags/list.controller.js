(function () {
    'use strict';

    angular
        .module('app.tags')
        .controller('TagsListController', TagsListController);

    TagsListController.$inject = ['tagService'];

    /* @ngInject */
    function TagsListController(tagService) {
        var vm = this;

        var tags = [];
        vm.getTags = getTags;
        vm.predicate = 'name';
        vm.reverse = false;
        vm.order = order;

        activate();

        function activate() {
            return getTags();
        }

        ////////////////////////

        function getTags() {
            return tagService.getTags().then(function (response) {
                vm.tags = response.data;
                return vm.tags;
            })
        }

        function order(predicate) {
            vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
            vm.predicate = predicate;
        }
    }
})();