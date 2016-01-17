(function () {
    angular.module('app')
        .config(accountConfig);

    function accountConfig($stateProvider) {
        var account = {
            name: 'account',
            url: '/account',
            template: "'<div ui-view></div>'"
        };
        var register = {
            name: 'account.register',
            url: '/register',
            templateUrl: 'Content/App/account/register/register.html'
        };
        var login = {
            name: 'account.login',
            url: '/login',
            templateUrl: 'Content/App/account/login/login.html',
            controller: 'LoginController',
            controllerAs: 'loginCtrl'
        };
        var manage = {
            name: 'account.manage',
            url: '/manage',
            templateUrl: 'Content/App/account/manage/manage.html'
        };

        $stateProvider
            .state(account)
            .state(register)
            .state(login)
            .state(manage);
    }
})();