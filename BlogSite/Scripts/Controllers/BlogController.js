
var BlogController = function ($scope, $http) {

    $scope.model = {
        //helloAngular: 'I work!'
    };

    $scope.sendForm = function () {
        $http({
            method: 'POST',
            url: '/Blog/Create',
            data: $scope.model
        }).success(function (data, status, headers, config) {

        }).error(function (data, status, headers, config) {

        });
    };

    $scope.reset = function () {
        $scope.model.Title = '';
        $scope.model.Post = '';
    }
}

BlogController.$inject = ['$scope', '$http'];