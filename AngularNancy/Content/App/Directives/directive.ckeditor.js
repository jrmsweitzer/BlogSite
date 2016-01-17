(function () {
    'use strict';

    angular
        .module('app')
        .directive('ckEditor', ckEditor);

    function ckEditor() {
        return {
            require: '?ngModel',
            link: function ($scope, elm, attr, ngModel) {
                var ck = CKEDITOR.replace(elm[0]);

                ck.on('change', function () {
                    $scope.$apply(function () {
                        ngModel.$setViewValue(ck.getData());
                    });
                });

                ngModel.$render = function (value) {
                    ck.setData(ngModel.$modelValue);
                };

                $scope.$on("$destroy", function () {
                    ck.destroy();
                });
            }
        };
    }
})();