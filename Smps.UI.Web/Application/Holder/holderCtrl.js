//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
// </copyright>
//<summary>This is holder controller.</summary>
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp')
               .controller('holderCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', holderCtrl]);

    //This controller method instantiation of holder user info i.e holder info for the CRUD operation. 
    function holderCtrl($scope, $rootScope, $http, userAccountService) {
        $scope.isReleased = false;
        $scope.userProfile = userAccountService.userProfile;
        if ($rootScope.userProfile === null || $rootScope.userProfile === 'undefined') {
            $state.go('login');
        }

        // The below method will fetches the user data to populate on the views.
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

        //This function is relase the slot based on the request
        $scope.releaseSlot = function () {
            $scope.isReleased = true;
            $scope.successMessage = 'Thank you!! your slot release successfully';
        };
    }
}());