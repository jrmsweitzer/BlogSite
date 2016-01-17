(function () {
    'use strict';

    angular
       .module('app', [

           // Angular Modules
           'ui.router',
           'ui.bootstrap',
           'ngAnimate',
           'ngSanitize',

           // Custom Modules
           'app.category',
           'app.blog',
           'app.administration',
           'app.users',
           'app.tags',

           // Third Party Modules
           'flow',
       ]);
})();