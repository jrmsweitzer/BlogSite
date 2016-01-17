(function () {
    'use strict';

    angular
        .module('app.users')
        .factory('userService', userService);

    userService.$inject = ['$http'];

    function userService($http) {

        var service = {
            getUsers: getUsers,
            getUser: getUser,
            toggleActive: toggleActive,
        };
        return service;

        //////////////////

        function getUsers() {

            return $http({
                url: '/api/v1/users',
                method: "GET",
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });

        }

        function getUser(userName) {

            return $http({
                url: '/api/v1/user/' + userName,
                method: "GET",
                data: { userName: userName }
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });
        }

        function toggleActive(userID) {
            return $http({
                url: '/api/v1/user/toggleActive/' + userID,
                method: "POST",
                data: { userID: userID }
            })
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                alert(data);
            });
        }
    }

})();