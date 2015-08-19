'use strict';

/* App Module */

var blogApp = angular.module('blogApp', [
  'ngRoute',
  'blogAnimations',

  'blogControllers',
  'blogFilters',
  'blogServices'
]);

blogApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/blogs', {
            templateUrl: 'partials/blog-list.html',
            controller: 'BlogListCtrl'
        }).
        when('/blogs/:blogId', {
            templateUrl: 'partials/blog-detail.html',
            controller: 'BlogDetailCtrl'
        }).
        otherwise({
            redirectTo: '/blogs'
        });
  }]);
