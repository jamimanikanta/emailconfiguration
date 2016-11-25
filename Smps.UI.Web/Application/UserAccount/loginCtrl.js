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
        /* To validate the entered user emailid and password   */
        /* This method calls service to validate the given credntials */
        $scope.login = function () {
            $scope.errorFlag = false;
            /* This method calls service to validate the given credntials */
            userAccountService.authenticateUser($scope.userObject)
                .then(function (result) {
                    $scope.userObject = result;
                    $state.go('home');
                }, function () {
                    $scope.message = 'Incorrect email id or password entered. Please try again';});
        };
    }]);
})();
