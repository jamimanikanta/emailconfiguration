﻿angular.module('SMPSapp').controller("loginCtrl", ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {
    $scope.userObject = { userName: "", password: "" };


    $scope.login = function () {
        $scope.errorFlag = false;
        $scope.userObject;
        $http(
                {
                    method: 'GET',
                    url: $rootScope.apiURL + "UserAccount/IsUserValid?userid="
                            + $scope.username + "&password="
                            + $scope.password
                })
                .then(
                        function (response) {
                            /*$rootScope.userObject = response.data;*/
                            $scope.userObject = response.data;
                            $state.go('home');
                        }).catch(function (response, status) {
                            $scope.errorFlag = true;
                            // $state.go('login');
                        });

    };

}]);