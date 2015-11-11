(function () {
    'use strict';

    angular
        .module('app.administration')
        .controller('AdministrationController', AdministrationController);

    AdministrationController.$inject = ['$location'];

    function AdministrationController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'administration';

        activate();

        function activate() { }
    }
})();
