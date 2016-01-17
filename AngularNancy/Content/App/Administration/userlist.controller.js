(function () {
    'use strict';

    angular
        .module('app.administration')
        .controller('UserListController', UserListController);

    UserListController.$inject = ['userService', '$uibModal'];

    function UserListController(userService, $uibModal) {
        var vm = this;

        vm.users = [];
        vm.usersloaded = false;
        vm.toggleActive = toggleActive;

        vm.predicate = 'joinDate';
        vm.reverse = true;
        vm.order = order;

        activate();

        function activate() {
            return getUsers();
        }

        ///////////////////////////

        function getUsers() {
            return userService.getUsers().then(function (response) {
                vm.users = response.data;
                vm.usersloaded = true;
                return vm.users;
            })
        }

        function toggleActive(user) {
            var modalInstance = $uibModal.open({
                templateUrl: 'Content/App/Administration/toggleUserActiveModal.html',
                controller: 'ToggleUserActiveModalController',
                controllerAs: 'vm',
                resolve: {
                    isActive: function () {
                        return user.isActive;
                    }
                }
            });

            modalInstance.result.then(function (toggle) {
                if (toggle)
                {
                    return userService.toggleActive(user.ID);
                }
            });
        }

        function order(predicate) {
            vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
            vm.predicate = predicate;
        }
    }
})();
