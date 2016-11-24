//-----------------------------------------------------------------------
// <copyright file="UserAccountService" company="EPAM">
//     EPAM copyright .
// </copyright>
//<summary>This is the User account Service.</summary>
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp').factory('userAccountService', ['$http', '$rootScope', userAccountService])
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