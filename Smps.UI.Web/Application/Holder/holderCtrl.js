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
                $scope.userProfile = "No data found for specified user";
            });
        }
        var isReleased = false;
        $scope.releaseSlot = function () {

            $scope.isReleased = true;
            $scope.successMessage = "Thank you!! your slot release successfully";
        }
    }
}());