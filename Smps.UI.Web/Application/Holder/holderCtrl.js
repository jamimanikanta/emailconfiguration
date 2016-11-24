//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
// </copyright>
//<summary>This is holder controller.</summary>
//As a Holder, I want to release my parking slot for multiple days
//so that any seeker who is in need of the parking slot can get the slot for that day.
//
//As a Holder/Seeker, I want to search by Car Number / Parking Slot / Mobile Number 
// So that Car Owner can be reached for emergency
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
// End of holder controller.