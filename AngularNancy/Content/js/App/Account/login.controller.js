(function () {
    'use strict';

    angular
        .module('app.account')
        .controller('AccountLoginController', AccountLoginController);

    AccountLoginController.$inject = ['accountService'];

    function AccountLoginController(accountService) {

        /* jshint validthis:true */
        var vm = this;

        vm.user = {
            username: "",
            password: "",
        };

        vm.submit = submit;

        activate();

        function activate() {
            return vm.user;
        }

        /////////////////////

        function submit() {
            if (vm.user && vm.user.username && vm.user.password) {
                return accountService.attemptLogin(vm.user.username, vm.user.password);
            }
        }
    }
})();
