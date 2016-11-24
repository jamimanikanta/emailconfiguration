/*
 * AngularJS is a structural framework for
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

        $urlRouterProvider.otherwise('login');
        $stateProvider.state('login', {
            url: '/login',
            templateUrl: 'Views/UserAccount/login.html',
            controller: 'loginCtrl'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'Views/Holder/Holder.html',
            controller: 'holderCtrl'
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
        $rootScope.apiURL = 'http://10.71.12.108/SMPSWebAPI/api/';
        $rootScope.userProfile = {};
        $rootScope.$on('$stateChangeStart', function (e, toState) {
            var isLogin = toState.name === 'login';
            if (isLogin) {
                return;
            }
            if (userAccountService.userProfile === undefined || Object.getOwnPropertyNames(userAccountService.userProfile).length === 0) {
                e.preventDefault();
                $state.go('login');
            }
        });
    }]);
})();