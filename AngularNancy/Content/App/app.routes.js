(function () {

    angular.module('app')
        .config(appConfig)
        .run(['$state', function ($state) {
            //666021963500583 // Facebook App ID
            $state.transitionTo('home');
        }]);

    function appConfig($stateProvider, $locationProvider) {

        var home = {
            name: 'home',
            url: '/',
            templateUrl: 'Content/App/Layout/landing.html',
        };

        var _404 = {
            name: '404',
            url: '/404',
            templateUrl: 'Content/App/Layout/404.html'
        };

        $stateProvider.state(home);
        $stateProvider.state(_404);
    }

})();