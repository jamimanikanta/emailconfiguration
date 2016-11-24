//-----------------------------------------------------------------------
// <copyright file="Login Controller" company="EPAM">
//     EPAM copyright @2016.
// </copyright>
//<summary>This is login controller.
//As a User, Login page with organization logo 
//should be available to access EPAM SMPS application
//</summary>
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp').controller("loginCtrl", ['$scope', '$rootScope', 'userAccountService', '$state', function ($scope, $rootScope, userAccountService, $state) {
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
                        if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                            $scope.message = ''
                            userAccountService.userProfile = response.data;
                            $state.go('home');
                        }
                        else {
                            $scope.message = 'Incorrect email id or password entered. Please try again';
                        }

                    }).catch(function () {
                        $scope.message = 'Login Failed: Invalid user';
                    });
        };
    }]);
})();
