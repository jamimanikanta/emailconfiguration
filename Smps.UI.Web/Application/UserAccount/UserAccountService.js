//-----------------------------------------------------------------------
// <copyright file="UserAccountService" company="EPAM">
//     EPAM copyright .
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