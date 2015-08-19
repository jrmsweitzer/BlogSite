
var BlogDetailsController = function ($scope, $http) {

    $scope.model = {

        blogId: 0,
        currentBlog: getBlog(blogId)

    };

    $scope.getBlog = function (blogId) {
        if (blogId != 0) {

        };
    }
}