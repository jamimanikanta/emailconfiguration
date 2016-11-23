(function(){
    angular.module("SMPSapp")
           .controller("HolderCtrl", ['$scope', '$rootScope', '$http', HolderCtrl]);

    function HolderCtrl($scope, $rootScope, $http) {
        $scope.getProfile = function () {
            $http({
                method: "GET",
                url: $rootScope.apiURL + "useraccount/GetUserProfile?userid=" + $scope.userName
            }).then(function mySuccess(response) {
                $scope.userProfile = response.data;
            }, function myError(response) {
                $scope.userProfile = response.statusText;
            });
        }

    }
}());