//-----------------------------------------------------------------------
// <copyright file="holder Controller" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
// </copyright>
//<summary>This is holder controller.</summary>
//As a Holder, I want to release my parking slot for multiple days
//so that any seeker who is in need of the parking slot can get the slot for that day.
//
//As a Holder/Seeker, I want to search by Car Number / Parking Slot / Mobile Number
// So that Car Owner can be reached for emergency
//-----------------------------------------------------------------------
(function () {
    angular.module('SMPSapp')
               .controller('holderCtrl', ['$scope', '$rootScope', '$http', 'userAccountService', 'auth', '$window', '$state', '$interval', holderCtrl]);
    //This controller method instantiation of holder user info i.e holder info for the CRUD operation.
    /*This controller method instantiation of holder user info i.e holder info for the CRUD operation.*/
    /*Control method start*/
    function holderCtrl($scope, $rootScope, $http, userAccountService, auth, $window, $state) {
         debugger;
        $scope.isReleased = false;
        $scope.userProfile = auth;
        $scope.name = $scope.userProfile.FirstName;
        $scope.$watch('model.StartDate', validateDates);
        $scope.$watch('model.EndDate', validateDates);
        $scope.display = false;
        
        $scope.AllSeekers = function () {
            debugger;
            $http.get($rootScope.apiURL + 'useraccount/GetAllSeekers').then(function(response) {
                
                $scope.Seekers = response.data;
                


            }, function(reason) {

                alert("failure");

            });


        }

        $scope.GetHoldersTabledetail = function () {

            debugger;

            $http.get($rootScope.apiURL + 'useraccount/GetHoldersTabledetail?id='+auth.EmpNo).then(function (response) {

                
                 $window.sessionStorage['Holdertabledata'] = JSON.stringify(response.data);

            }, function (reason) {

                alert("failure");

            });
            
        }





        $scope.checkSeekersElgibility = function () {
            debugger;
            $scope.message = "";
            var begindate = $scope.model.StartDate;
            var enddate = $scope.model.EndDate;
            var id = $scope.model.seeker;
            if (begindate !== enddate) {

                $http({
                    method: 'GET',
                    url: $rootScope.apiURL + 'useraccount/CheckSeekersElgibility',
                    params: { userid: id, begindate: begindate, enddate: enddate }
                    
                }).then(function (response) {
                      debugger;
                     var result = response.data;
                     $scope.display = true;
                     if (result.length >= 1)
                     {

                        var resultdates = "";
                        for (var i = 0, len = result.length; i < len; i++)
                        {
                            resultdates = resultdates + result[i].CreatedDate + ' , ';
                        }

                        resultdates = resultdates.replace(/T00:00:00/g,'');
                        $scope.message = "He was already allocated for these days  "+resultdates;
                        alert($scope.message);
                     } 



                }, function(reason) {
                    alert("fail");

                });


            }
            else
            {
                $scope.display = true;
                
                $scope.message = "You cannot relaese your slot for single day";

                
            }



        }


        function validateDates() {
            debugger;
            if (!$scope.model) return;
            if ($scope.form.startDate.$error.invalidDate || $scope.form.endDate.$error.invalidDate) {
                debugger;
                $scope.form.startDate.$setValidity("endBeforeStart", true);  //already invalid (per validDate directive)
               
            } else {
                //depending on whether the user used the date picker or typed it, this will be different (text or date type).  
                //creating a new date object takes care of that.  
                var endDate = new Date($scope.model.EndDate);
                var startDate = new Date($scope.model.StartDate);
                var todaydate = new Date();
                $scope.form.startDate.$setValidity("startdateshouldgreater", startDate >= todaydate.setHours(0,0,0,0));
                $scope.form.startDate.$setValidity("endBeforeStart", endDate >= startDate.setHours(0, 0, 0, 0));
                if ($scope.form.$valid) {
                    var arr = "";
                    if (startDate !== endDate)
                    {
                while (startDate <= endDate)
                {
                    $scope.Hdates = JSON.parse($window.sessionStorage['Holdertabledata']);

                    for (var i = 0; i < $scope.Hdates.length; i++) {
                        var dt = new Date($scope.Hdates[i].Startdate);
                            

                        if (dt.toDateString() === startDate.toDateString())
                        {
                            arr = arr + startDate + ",";
                           

                        }
                    }





                    var newDate = startDate.setDate(startDate.getDate() + 1);
                    startDate = new Date(newDate);


                }
            }


                    if (arr !== "" || startDate === endDate)
                    {
                        
                        arr = arr.replace(/00:00:00 GMT+0530/g,'');
                        arr = arr + "you cant release for the above days";
                        alert(arr);

                    }
                    





                
                    
                    alert("ok");
                }

            }
        }
        $scope.$watch('form.$valid', function ()
        {
            //$scope.valid = newVal;
            debugger;
            $scope.informationStatus = true;
        });

        if ($scope.userProfile.UserType === 'Seeker') {
            debugger;
            $state.go('Seeker');






        }
        // The below method will fetches the user data to populate on the views.
        /*The below method will fetches the user data to populate on the views.*/
        $scope.releaseSlot = function () {

            if ($scope.multiple)
            {
                if ($scope.form.$valid) {

                    call();


                }


            }
            else {
                call();

            }
            
            function call(){
                debugger;
                $http({
                    method: 'GET',
                    url: $rootScope.apiURL + 'useraccount/GetUserProfile?userid=' + $scope.userProfile.EmpNo
                }).then(function (response) {
                    debugger;
                    userAccountService.userProfile = response.data;
                    var holder = response.data;
                    
                    if ($scope.multiple)
                    {
                        holder.SeekerId = $scope.model.seeker;
                        holder.Startdate = $scope.model.StartDate;
                        holder.Enddate = $scope.model.EndDate;

                    } else
                    {
                        holder.Startdate =  null;
                        holder.Enddate =  null;
                    }
                    
                    $scope.releaseSlotoutput(holder);
                }, function () {

                    $scope.userProfile = 'No data found for specified user';
                });

            } 
  
            }

        
        //This function is relase the slot based on the request
        /*This function is relase the slot based on the request*/
        $scope.releaseSlotoutput = function (holder)
        {
            /*holder code for relasing slot*/



            debugger;
            $http({
                method: 'Post',
                url: $rootScope.apiURL + 'useraccount/Releaseslot',
                data: JSON.stringify(holder),
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                debugger;
                var res = response.data;

                if (res[0].OperationType===1) {

                    var resultdates = "";
                    for (var i = 0, len = res.length; i < len; i++) {
                        resultdates = resultdates + res[i].Startdate + " , ";
                    }
                    debugger;
                    alert("sucess");
                    $scope.dontshow = true;
                    $scope.isReleased = true;
                    if (res.length > 0) {

                        $scope.successMessage = 'Thank you!! Slot released successfully  for The ' + resultdates + ' days';
                    }
                    else
                    {
                        $scope.successMessage = 'Thank you!! Slot released successfully for ' + res[0].Startdate;

                    }
                   
                }
                else
                
                    if (res[0].OperationType === -1) {

                        var resulteddates="";
                        len = res.length;
                        for (var p = 0;  p < len; p++) {
                            resulteddates = resulteddates + res[p].Startdate + " , ";
                        }
                        $scope.dontshow = true;
                        $scope.isReleased = true;
                        
                        alert("sorry we are not able to release for " + resulteddates + "  days");
                        $scope.successMessage = "sorry we are not able to release for " + resulteddates + "  days and Remaining days got released";
                    }
                    else
                        if (res[0].OperationType === 0)
                   {
                    debugger;
                    $state.go('HolderErrorpage');

                   }

            }, function () {

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
