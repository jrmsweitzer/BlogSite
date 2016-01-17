(function () {
    'use strict';

    angular
        .module('app.account')
        .controller('AccountRegisterController', AccountRegisterController);

    AccountRegisterController.$inject = ['accountService'];

    function AccountRegisterController(accountService) {

        var vm = this;

        vm.user = {
            username: "",
            password: "",
            confirmpassword: "",
            profileimage: ""
        };
        vm.submit = submit;
        vm.updateImage = updateImage;

        activate();

        function activate() {
            return vm.user;
        }

        //////////////////////

        function submit() {
            if (vm.user && vm.user.password && vm.user.password === vm.user.confirmpassword) {
                return accountService.registerAccount(vm.user.username, vm.user.password, vm.profileimage);
            }
        }

        function encodeImageFileAsURL(cb) {
            return function () {
                var file = this.files[0];
                var reader = new FileReader();
                reader.onloadend = function () {
                    cb(reader.result);
                }
                reader.readAsDataURL(file);
            }
        }

        function updateImage() {
            encodeImageFileAsURL(function (base64Img) {
                vm.user.profileimage = base64Img
            });
        }
    };
})();