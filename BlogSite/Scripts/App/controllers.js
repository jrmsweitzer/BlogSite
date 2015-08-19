'use strict';

/* Controllers */

var blogControllers = angular.module('blogControllers', []);

blogControllers.controller('BlogListCtrl', ['$scope', 'Blog',
  function ($scope, Blog) {
      $scope.blogs = Blog.query();
      $scope.orderProp = 'age';
  }]);

blogControllers.controller('BlogDetailCtrl', ['$scope', '$routeParams', 'Blog',
  function ($scope, $routeParams, Blog) {
      $scope.phone = Blog.get({ blogId: $routeParams.blogId }, function (blog) {
          $scope.mainImageUrl = blog.images[0];
      });

      $scope.setImage = function (imageUrl) {
          $scope.mainImageUrl = imageUrl;
      };
  }]);
