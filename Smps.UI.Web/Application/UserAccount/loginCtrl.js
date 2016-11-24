//-----------------------------------------------------------------------
//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
// </copyright>
//<summary>This is login controller.
//As a User, Login page with organization logo
//should be available to access EPAM SMPS application
//</summary>
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp').controller('loginCtrl', ['$scope', '$rootScope', 'userAccountService', '$state', function ($scope, $rootScope, userAccountService, $state) {
        $scope.userObject = { userName: '', password: '' };
        $scope.message = '';
        /* To validate the entred user emailid and password   */
        /* This method calls service to validate the given credntials */
        $scope.login = function () {
            $scope.errorFlag = false;
            $scope.userObject;
            /* This method calls service to validate the given credntials */
            userAccountService.authenticateUser($scope.userObject)
            .then(
                    function (response) {
                        //Based on the response redirect to the respective screen
                        if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                            //Start :  On successful login it will recire to home 
                            $scope.message = '';
                            userAccountService.userProfile = response.data;
                            $state.go('home');
                            //End : On successful login it will recire to home 
                        }
                        else {
                            $scope.message = 'Incorrect email id or password entered. Please try again';
                        }
                    }).catch(function () {
                        //On Error we have to handle error. 
                        $scope.message = 'Login Failed: Invalid user';
                    });
        };
    }]);
})();