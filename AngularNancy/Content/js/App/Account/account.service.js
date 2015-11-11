(function () {
    angular.module('app.account')
           .factory('accountService', accountService);

    accountService.$inject = ['$http'];

    function accountService($http) {

        var service = {
            authenticatedUser: {},
            isAuthenticated: false,
            registerAccount: registerAccount,
            attemptLogin: attemptLogin,
            changePassword: changePassword,
            isAdmin: isAdmin
        };
        return service;

        /////////////////////

        function registerAccount(username, password, profileimage) {
            return $http({
                url: '/api/v1/account/register',
                method: "POST",
                data: {
                    Username: username,
                    Password: password,
                    ProfileImage: profileimage
                }
            }).then(function successCallback(response) {
                authenticatedUser = response.data;
                isAuthenticated = true;
            }, function errorCallback(response) {

            });
        }

        function attemptLogin(username, password) {
            return $http({
                url: '/api/v1/account/login',
                method: "Post",
                data: {
                    Username: username,
                    Password: password,
                    ProfileImage: null
                }
            }).then(function successCallback(response) {
                authenticatedUser = response.data;
                isAuthenticated = true;
            }, function errorCallback(response) {

            });
        }

        function changePassword(oldPassword, newPassword) {
            return $http({
                url: '/api/v1/account/changePassword',
                method: "POST",
                data: {
                    OldPassword: oldPassword,
                    NewPassword: newPassword,
                    Username: authenticatedUser.username
                }
            });
        }

        function isAdmin() {
            if (authenticatedUser &&
                (authenticatedUser.role == 'Admin' ||
                authenticatedUser.role == 'God')) {
                return true;
            } else {
                return false;
            }
        }
    }

})();