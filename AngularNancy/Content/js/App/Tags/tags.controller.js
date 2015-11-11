(function () {
    'use strict';

    angular
        .module('app.tags')
        .controller('TagsController', TagsController);

    TagsController.$inject = ['$location'];

    function TagsController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'tags';

        activate();

        function activate() { }
    }
})();
