//-----------------------------------------------------------------------
// <copyright file="application javascr" company="EPAM">
//     EPAM copyright @2016.
//     This application is built during Build-A-Thon and is copy righted to SNL team
//     This object to be used only in SMPS application started by SNL team, usage in any other project or team to be informed earlier.
// </copyright>
/* AngularJS is a structural framework for
 * dynamic web apps. It lets you use HTML as your
 * template language and lets you extend HTML's syntax
 * to express your application's components clearly and
 * succinctly. Angular's data binding and dependency injection
 * eliminate much of the code you currently have to write. And it all
 * happens within the browser, making it an ideal partner with
 *  any server technology. */
/*
 * this is our angular module which have some dependancies
 */
//-----------------------------------------------------------------------
(function () {
    var app = angular.module('SMPSapp', ['ui.router']);
    /*
     * this part contains routing with the help of
     * url route provider which is very useful if we have nested views
     * state.go will take us to the diffrent state
     */
    /*
     * The UI-Router is a routing framework for AngularJS built by the
     * AngularUI team. It provides a different approach than ngRoute in
     * that it changes your application views based on state of the
     * application and not just the route URL.
     */
    app.config(function ($stateProvider, $urlRouterProvider/*$locationProvider*/) {
        // Gets the user information from the service.
        function oAuth($q, userAccountService) {
            var userInfo = userAccountService.getUserInfo();
            if (userInfo) {
                return $q.when(userInfo);
            } else {
                return $q.reject({ authenticated: false });
            }
        }
        $urlRouterProvider.otherwise('login');
        $stateProvider.state('login', {
            url: '/login',
            templateUrl: 'Views/UserAccount/login.html',
            controller: 'loginCtrl'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'Views/Holder/Holder.html',
            controller: 'holderCtrl',
            resolve: {
                auth: oAuth
            }
        });
    });
    /*
     * The new $stateProvider works similar to Angular's v1 router, but it
     * focuses purely on state.
     * A state corresponds to a "place" in the application in terms of the
     *  overall UI and navigation.
     *  A state (via the controller / template / view properties) describes
     *  what the UI looks like and does at that place.
     *  States often have things in common, and the primary way of factoring out
     *  these commonalities in this model is via the state hierarchy, i.e. parent/child
     *   states aka nested states.'localStorageService',,localStorageService
     */
    app.run(['$rootScope', '$state', 'userAccountService', function ($rootScope, $state, userAccountService) {
        $rootScope.apiURL = 'http://10.6.196.236/SMPS.WebAPI/api/';
        //On State change startsthe below block will executed
        $rootScope.$on('$stateChangeStart', function (event, toState) {
            // Comparing current state with login
            var isLogin = toState.name === 'login';
            if (isLogin) {
                return;
            }
            // Comparing userinfo object and on failure
            // this will re-direct to login page
            var userInfo = userAccountService.getUserInfo();
            // for successful login user info must have some user details
            if (userInfo === undefined) {
                // stop current execution
                event.preventDefault();
                // State changes to login page
                $state.go('login');
            }
        });
        //On State change if errors occers Then the below block will executed
        $rootScope.$on('$stateChangeError', function (event, current, previous, eventObj) {
            if (eventObj.authenticated === false) {
                // Changing the state from the current page to login page
                $state.go('login');
            }
        });
    }]);
})();
// End of the APP JS

