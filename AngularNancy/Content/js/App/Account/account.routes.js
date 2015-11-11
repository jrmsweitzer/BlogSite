(function () {
    angular.module('app.account')
        .config(accountConfig);

    function accountConfig($stateProvider) {
        var account = {
            name: 'account',
            url: '/account',
            templateUrl: 'Content/html/account/base.html'
        };
        var register = {
            name: 'account.register',
            url: '/register',
            templateUrl: 'Content/html/account/register.html',
            controller: 'AccountRegisterController',
            controllerAs: 'registration'
        };
        var login = {
            name: 'account.login',
            url: '/login',
            templateUrl: 'Content/html/account/login.html',
            controller: 'AccountLoginController',
            controllerAs: 'login'
        };
        var manage = {
            name: 'account.manage',
            url: '/manage',
            templateUrl: 'Content/html/account/manage.html',
            controller: 'AccountManageController',
            controllerAs: 'manage'
        };

        $stateProvider
            .state(account)
            .state(register)
            .state(login)
            .state(manage);
    }
})();