(function () {
    angular.module('SMPSapp').factory('userAccountService', ['$http', '$rootScope',userAccountService])
    
    function userAccountService($http, $rootScope) {
        debugger
        var userProfile = {};
        //// Used Closers to absracting the method
        return {
            authenticateUser: function (userObject) {
                return $http(
                         {
                             method: 'GET',
                             url: $rootScope.apiURL + "UserAccount/ValidateUser?userId="
                                     + userObject.userName + "&password="
                                     + userObject.password
                         });
            },
            userProfile: userProfile
        }

    };
})();