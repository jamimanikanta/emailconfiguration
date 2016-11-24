// <copyright file="UserAccountService" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
// </copyright>
//<summary>This is the User account Service.</summary>
// should be able to communicate eith web api for crud opration.
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp').factory('userAccountService', ['$http', '$rootScope', '$q', '$window', userAccountService]);
    /* To validate the entred user emailid and password   */
    /* This method calls service to validate the given credntials */
    function userAccountService($http, $rootScope, $q, $window) {
        var userProfile;
        function authenticateUser(userObject) {
            var deferred = $q.defer();
            $http(
                    {
                        method: 'GET',
                        url: $rootScope.apiURL + 'UserAccount/ValidateUser?userId='
                                + userObject.userName + '&password='
                                + userObject.password
                    })
               .then(
               function (response) {
                   if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                       $window.sessionStorage["userInfo"] = JSON.stringify(response.data);
                       userProfile = response.data;
                       deferred.resolve(userProfile);
                   }
                   else {
                       deferred.resolve(userProfile);
                   }
               }, function (error) {

                   deferred.reject(error);
               });
            return deferred.promise;
        }
        function getUserInfo() {
            return userProfile;
        }
        function init() {
            if ($window.sessionStorage["userInfo"]) {
                userProfile = JSON.parse($window.sessionStorage["userInfo"]);
            }
        }
        init();
        return {
            authenticateUser: authenticateUser,
            getUserInfo: getUserInfo
        };
    }
})();
// End of User Account Service.
