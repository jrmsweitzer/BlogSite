(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['accountService'];

    function LoginController(accountService) {
        var loginCtrl = this;

        loginCtrl.submit = submit;

        activate();

        function activate() {
            return;
        }

        //////////////////////

        function submit() {
            if (loginCtrl.user.username && loginCtrl.user.password) {
                return accountService.attemptLogin(
                    loginCtrl.user.username,
                    loginCtrl.user.password);
            }
        }
    }
})();