(function () {
    'use strict';

    angular
        .module('app')
        .controller('ToggleUserActiveModalController', ToggleUserActiveModalController);

    ToggleUserActiveModalController.$inject = ['$http', 'userService', '$uibModalInstance', 'isActive'];

    function ToggleUserActiveModalController($http, userService, $uibModalInstance, isActive) {
        var vm = this;

        if (isActive) {

        } else {

        }

        vm.ok = ok;
        vm.cancel = cancel;

        activate();
        
        function activate() {
            return;
        }

        ///////////////////////////

        function ok() {
            $uibModalInstance.close(true);
        }

        function cancel() {
            $uibModalInstance.close(false);
        }
    }
})();