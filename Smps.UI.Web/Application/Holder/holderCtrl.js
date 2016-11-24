//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
// </copyright>
//<summary>This is holder controller.</summary>
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp')
               .controller('holderCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', holderCtrl]);

    function holderCtrl($scope, $rootScope, $http, userAccountService) {
        $scope.isReleased = false;
        $scope.userProfile = userAccountService.userProfile;
        if ($rootScope.userProfile === null || $rootScope.userProfile === 'undefined') {
            $state.go('login');
        }
        $scope.getProfile = function () {
            $http({
                method: 'GET',
                url: $rootScope.apiURL + 'useraccount/GetUserProfile?userid=' + userAccountService.userProfile.userName
            }).then(function (response) {
                userAccountService.userProfile = response.data;
            }, function () {
                $scope.userProfile = 'No data found for specified user';
            });
        };

        $scope.releaseSlot = function () {
            $scope.isReleased = true;
            $scope.successMessage = 'Thank you!! your slot release successfully';
        };
    }
}());