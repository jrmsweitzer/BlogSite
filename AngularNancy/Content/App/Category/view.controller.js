(function () {
    'use strict';

    angular
        .module('app.category')
        .controller('CategoryViewController', CategoryViewController);

    CategoryViewController.$inject = ['categoryService', '$stateParams'];

    function CategoryViewController(categoryService, $stateParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'view';

        activate();

        function activate() { }
    }
})();
