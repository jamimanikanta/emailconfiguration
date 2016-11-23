(function () {
    angular.module('SMPSapp').controller("loginCtrl", ['$scope', '$rootScope', 'userAccountService', '$state', function ($scope, $rootScope, userAccountService, $state) {
        $scope.userObject = { userName: "", password: "" };
        $scope.message = "";
       
        $scope.login = function () {
            $scope.errorFlag = false;
            $scope.userObject;

            ////To call Service
            userAccountService.authenticateUser($scope.userObject)
            .then(
                    function (response) {
                        //// To be uncomment if api results the user object $scope.userObject = response.data;
                        if (response.data == true) {
                            $scope.message = "";
                            $state.go('home');
                        }
                        else {
                            $scope.message = "Incorrect email id or password entered. Please try again";
                        }

                    }).catch(function (response, status) {
                        $scope.message = "Login Failed.Due to server not responding";
                    });
        };


    }]);
})();
