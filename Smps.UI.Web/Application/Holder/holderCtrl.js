//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
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
               .controller('holderCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', 'auth', holderCtrl]);
    //This controller method instantiation of holder user info i.e holder info for the CRUD operation.
    /*This controller method instantiation of holder user info i.e holder info for the CRUD operation.*/
    /*Control method start*/
    function holderCtrl($scope, $rootScope, $http, userAccountService, auth) {
        $scope.isReleased = false;
        $scope.userProfile = auth;
        if ($scope.userProfile.UserType==='Seeker')
        {
            /*flag to display seeker page info*/
            $scope.isReleased = true;
            $scope.seekerMessage = 'Seeker page under construction';
        }
        // The below method will fetches the user data to populate on the views.
        /*The below method will fetches the user data to populate on the views.*/
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
        /*This function is relase the slot based on the request*/
        $scope.releaseSlot = function () {
            /*condition to display success message*/
            $scope.isReleased = true;
            $scope.successMessage = 'Thank you!! Slot released successfully';
        };
    }
}());
// End of holder controller.
/*End of holder controller.*/
