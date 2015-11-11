(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('LayoutController', LayoutController);

    LayoutController.$inject = ['accountService'];

    function LayoutController(accountService) {
        /* jshint validthis:true */
        var vm = this;
        
        vm.authenticatedUser = {};
        vm.isAuthenticated = isAuthenticated;

        activate();

        function activate() { }

        ///////////////////////

        function isAuthenticated() {
            return accountService.isAuthenticated;
        }
    }
})();
