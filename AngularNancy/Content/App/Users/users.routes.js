(function () {
    angular.module('app')
    .config(userConfig);

    function userConfig($stateProvider) {
        var users = {
            name: 'users',
            url: '/users',
            template: "'<div ui-view></div>'"
        };
        var usersprofile = {
            name: 'users.profile',
            url: '/profile/:userName',
            templateUrl: 'Content/App/Users/profile.html',
            controller: 'UserProfileController',
            controllerAs: 'vm'
        };

        $stateProvider
            .state(users)
            .state(usersprofile);
    };
})();