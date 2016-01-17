(function () {
    'use strict';

    angular
        .module('app')
        .controller('AuthenticationController', AuthController);

    AuthController.$inject = ['accountService', '$state', '$scope'];

    function AuthController(accountService, $state, $scope) {
        var authCtrl = this;
        authCtrl.user = {};

        activate();

        function activate() {
            authCtrl.user = accountService.getUser();
            return;
        }

        ///////////////////
    }
})();