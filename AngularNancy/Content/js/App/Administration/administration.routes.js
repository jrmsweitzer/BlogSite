(function () {
    angular.module('app.administration')
    .config(administrationConfig);

    function administrationConfig($stateProvider) {
        var administration = {
            name: 'administration',
            url: '/administration',
            templateUrl: 'Content/html/administration/base.html'
        };

        $stateProvider
            .state(administration);
    };


})();