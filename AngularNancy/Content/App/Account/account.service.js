(function () {
    angular.module('app')
           .factory('accountService', accountService);

    accountService.$inject = ['$http', '$state'];

    function accountService($http, $state) {

        var user = {
            username: "",
            password: "",
            isAuthenticated: false
        };

        var service = {
            attemptLogin: attemptLogin,
            getUser: getUser
        };
        return service;

        /////////////////////

        function getUser() {
            return user;
        }

        function attemptLogin(username, password) {
            return $http({
                url: '/api/v1/account/login',
                method: "Post",
                data: {
                    Username: username,
                    Password: password,
                }
            }).then(function successCallback(response) {
                user = response.data;
                user.isAuthenticated = true;
                $state.go('home');
            }, function errorCallback(response) {

            });
        }

        //function registerAccount(username, password, profileimage) {
        //    return $http({
        //        url: '/api/v1/account/register',
        //        method: "POST",
        //        data: {
        //            Username: username,
        //            Password: password,
        //            ProfileImage: profileimage
        //        }
        //    }).then(function successCallback(response) {
        //        authenticatedUser = response.data;
        //        isAuthenticated = true;
        //    }, function errorCallback(response) {

        //    });
        //}

        //function changePassword(oldPassword, newPassword) {
        //    return $http({
        //        url: '/api/v1/account/changePassword',
        //        method: "POST",
        //        data: {
        //            OldPassword: oldPassword,
        //            NewPassword: newPassword,
        //            Username: authenticatedUser.username
        //        }
        //    });
        //}

        //function isAdmin() {
        //    if (authenticatedUser &&
        //        (authenticatedUser.role == 'Admin' ||
        //        authenticatedUser.role == 'God')) {
        //        return true;
        //    } else {
        //        return false;
        //    }
        //}
    }

})();