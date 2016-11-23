(function () {
    angular.module('SMPSapp').factory('userAccountService', ['$http', '$rootScope', function ($http, $rootScope) {

        //// Used Closers to absracting the method
        return {
            authenticateUser: function (userObject) {
                return $http(
                         {
                             method: 'GET',
                             url: $rootScope.apiURL + "UserAccount/IsUserValid?userId="
                                     + userObject.userName + "&password="
                                     + userObject.password
                         });
            }
        }

    }]);
})();