(function () {
    angular.module('SMPSapp')
               .controller('SeekerCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', 'auth', '$window', '$state', seekerCtrl]);
   // ['$scope', '$rootScope', '$http', 'userAccountService', 'auth', '$window', '$state', seekerCtrl]
    //This controller method instantiation of holder user info i.e holder info for the CRUD operation.
    /*This controller method instantiation of holder user info i.e holder info for the CRUD operation.*/
    /*Control method start*/
    function seekerCtrl($scope, $rootScope, $http, userAccountService, auth, $window, $state)
    {
        debugger;
        $scope.isReleased = false;
        $scope.userProfile = auth;

        //$rootScope.Seekerdetails = $state.params.obj;



        

        
         
        
        $scope.details = $rootScope.inputdata;

        
           
        
       

        //if ($scope.userProfile.UserType == 'Seeker') {
        //    debugger;
        //    /*flag to display seeker page info*/
        //    $scope.isReleased = true;
        //    $scope.seekerMessage = 'Seeker page under construction';
        //}
        // The below method will fetches the user data to populate on the views.
        /*The below method will fetches the user data to populate on the views.*/
        $scope.RequestSlot = function ()
        {
            debugger;
            $http({
                method: 'GET',
                url: $rootScope.apiURL + 'useraccount/RequestSlot?Empno=' + $scope.userProfile.EmpNo
            }).then(function (response) {
                debugger;
                var resultdata = response.data;
                
                $rootScope.inputdata = response.data;
                


               

                var type = response.data.Type;
                debugger;
                switch (type) {
                    case '6':
                        //Hello FirstName LastName You had Allocated having slot Number:ParkingSlotNumber with Reference Number output;   

                        $state.go('SeekerSN&RN', { obj: resultdata });

                        break;


                    case '7':
                        //  sorry FirstName LastName You already raised a Request Today and Your Slot Number is ParkingSlotNumber;

                        $state.go('SeekerSN', { obj: resultdata });
                        break;
                    case '8':
                        //Hello FirstName LastName Thank you for request a slot You are Under waiting list with Reference Number:output;

                        $state.go('SeekerRN', { obj: resultdata });
                        break;

                    case '9':
                        //HelloFirstNameLastNameThank you for request a slot You are Under waiting list with Reference Number:SeekerDetailId;

                        $state.go('SeekerRN&Rep', { obj: resultdata });
                        break;
                    case '10':
                        // sorryFirstNameLastNameYou already raised a Request Today and Your Slot Number is ParkingSlotNumber;


                        $state.go('SeekerPN&Rep', { obj: resultdata });
                        break;
                    case '404':
                        //"there is no that type of user";
                        $state.go('SeekerError');
                        break;
                    default: $state.go('SeekerError');
                }



            }, function () {

                $scope.userProfile = 'No data found for specified user';
            });
        };
        //This function is relase the slot based on the request
        /*This function is relase the slot based on the request*/
        $scope.releaseSlotoutput = function (holder) {
            /*holder code for relasing slot*/



            debugger;
            $http({
                method: 'Post',
                url: $rootScope.apiURL + 'useraccount/Releaseslot',
                data: JSON.stringify(holder),
                headers: { 'Content-Type': 'application/json' }
            }).then(function () {
                debugger;
                alert("sucess");
                $scope.isReleased = true;
                $scope.successMessage = 'Thank you!! Slot released successfully';
            }, function () {
                debugger;
                $state.go('HolderErrorpage');
                //alert("Sorry Your Slot Already released");
                //$scope.Noneedto = true;
                //$scope.userProfile = 'No data found for specified user';
            });



            /*condition to display success message*/

        };
    }
}());
// End of holder controller.
/*End of holder controller.*/
