(function () {
    'use strict';

    angular
        .module('app.users')
        .controller('UserProfileController', UserProfileController);

    UserProfileController.$inject = ['userService', 'blogService', '$stateParams'];

    /* @ngInject */
    function UserProfileController(userService, blogService, $stateParams) {
        var vm = this;

        vm.user = {};
        vm.blogs = [];
        vm.predicate = 'createDate';
        vm.reverse = true;
        vm.order = order;

        activate();

        function activate() {
            getUserProfile();
            return getUserBlogs();
        }

        ////////////////////////

        function getUserProfile() {
            return userService.getUser($stateParams.userName).then(function (response) {
                vm.user = response.data;
            });
        }

        function getUserBlogs() {
            return blogService.getBlogsByUser($stateParams.userName).then(function (response) {
                vm.blogs = response.data;
                return vm.blogs;
            });
        }

        function order(predicate) {
            vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
            vm.predicate = predicate;
        }
    }
})();