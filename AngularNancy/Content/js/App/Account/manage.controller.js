(function () {
    'use strict';

    angular
        .module('app.account')
        .controller('AccountManageController', AccountManageController);

    AccountManageController.$inject = ['accountService'];

    function AccountManageController(accountService) {

        var vm = this;

        vm.user = {
            oldpassword: "",
            newpassword: "",
            confirmnewpassword: "",
        };
        vm.submit = submit;

        activate();

        function activate() {
            return vm.user;
        }

        //////////////////////

        function submit() {
            if (vm.user && vm.user.oldpassword && vm.user.newpassword && 
                vm.user.newpassword === vm.user.confirmnewpassword) {
                return accountService.changePassword(vm.user.oldpassword, vm.user.newpassword).then(function (response) {
                    vm.user = response.data;
                });
            }
        }
    }
})();
