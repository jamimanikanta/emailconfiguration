// <copyright file="UserAccountService" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
// </copyright>
//<summary>This is the User account Service.</summary>
// should be able to communicate eith web api for crud opration.
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp').factory('userAccountService', ['$http', '$rootScope', userAccountService]);

    /* To validate the entred user emailid and password   */
    /* This method calls service to validate the given credntials */
    function userAccountService($http, $rootScope) {
        var userProfile;
        return {
            userProfile: userProfile,
            authenticateUser: function (userObject) {
                return $http(
                         {
                             method: 'GET',
                             url: $rootScope.apiURL + 'UserAccount/ValidateUser?userId='
                                     + userObject.userName + '&password='
                                     + userObject.password
                         });
            }
        };
    };
})();
// End of User Account Service.
