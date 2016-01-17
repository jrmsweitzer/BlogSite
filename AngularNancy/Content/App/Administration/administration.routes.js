(function () {
    angular.module('app.administration')
    .config(administrationConfig);

    function administrationConfig($stateProvider) {
        var administration = {
            name: 'administration',
            url: '/administration',
            template: "'<div ui-view></div>'"
        };

        var userlist = {
            name: 'administration.list',
            url: '/users',
            templateUrl: 'Content/App/Administration/userlist.html',
            controller: 'UserListController',
            controllerAs: 'vm'
        };

        $stateProvider
            .state(administration)
            .state(userlist);
    };


})();