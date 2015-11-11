(function () {

    angular.module('app')
        .config(appConfig)
        .run(['$state', function ($state) {
            $state.transitionTo('home');
        }]);

    function appConfig($stateProvider) {

        var home = {
            name: 'home',
            url: '/',
            templateUrl: 'Content/html/home/landing.html',
            controller: 'LayoutController',
            controllerAS: 'layout'
        };

        var _404 = {
            name: '404',
            url: '/404',
            templateUrl: 'Content/html/shared/404.html'
        };

        $stateProvider.state(home);
        $stateProvider.state(_404);
    }

})();