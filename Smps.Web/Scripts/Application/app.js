/*
 * AngularJS is a structural framework for
 * dynamic web apps. It lets you use HTML as your
 * template language and lets you extend HTML's syntax
 * to express your application's components clearly and
 * succinctly. Angular's data binding and dependency injection 
 * eliminate much of the code you currently have to write. And it all 
 * happens within the browser, making it an ideal partner with
 *  any server technology.
 */


/*
 * this is our angular module which have some dependancies 
 */
var app = angular.module('CAP', [ "ui.router", "ngMessages","ui.bootstrap","multipleDatePicker",
                                  "LocalStorageModule",'ngMaterial', 'material.svgAssetsCache',
                                  "angular-growl", "ngAnimate","ngSanitize",
                                  'ui.grid', 'ui.grid.cellNav', 'ui.grid.selection', 'ui.grid.exporter', 'ng-fusioncharts']);
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
app.config(function($stateProvider, $urlRouterProvider/*$locationProvider*/) {
	$urlRouterProvider.otherwise('login');
	$stateProvider
	.state('registered', {
		url : '/registered',
		views: {
			'': {
				templateUrl : '/CAP/views/cap_registered.html',
				controller : 'registeredCtrl'
			},
			'header@registered': { 
				templateUrl : '/CAP/views/header/header.html',
				controller : 'registeredCtrl'
			},
			'footer@registered':{
				templateUrl: '/CAP/views/footer/footer.html',
				controller : 'registeredCtrl'
			}
		}
	})
	.state('unregistered', {
		url : '/unregistered',
		views: {
			'': {
				templateUrl : '/CAP/views/cap_unregistered.html',
				controller : 'unregisteredCtrl'
			},
			'header@unregistered': { 
				templateUrl : '/CAP/views/header/header.html',
				controller : 'unregisteredCtrl'
			},
			'footer@unregistered':{
				templateUrl: '/CAP/views/footer/footer.html',
				controller : 'unregisteredCtrl'
			}
		}
	})
	.state('facilitator', {
		url : '/facilitator',
		views: {
			'': {
				templateUrl : '/CAP/views/cap_facilitator.html',
				controller : 'facilitatorCtrl'
			},
			'header@facilitator': { 
				templateUrl : '/CAP/views/header/header.html',
				controller : 'facilitatorCtrl'
			},
			'navbar@facilitator':{
				templateUrl: '/CAP/views/navbar/navbar.html',
				controller : 'facilitatorCtrl'
			},
			'footer@facilitator':{
				templateUrl: '/CAP/views/footer/footer.html',
				controller : 'facilitatorCtrl'
			}, 
			'home@facilitator':{
				templateUrl:'/CAP/views/facilitator/home.html',
			    controller:'facilitatorCtrl'
			},
			'reg@facilitator':{
				templateUrl: '/CAP/views/facilitator/f_reg.html',
				controller : 'facilitatorCtrl'
			}, 
			'unreg@facilitator':{
				templateUrl: '/CAP/views/facilitator/f_unreg.html',
				controller : 'facilitatorCtrl'
			}, 
			'temp@facilitator':{
				templateUrl: '/CAP/views/facilitator/f_temp.html',
				controller : 'facilitatorCtrl'
			}, 
			'report@facilitator':{
				templateUrl: '/CAP/views/facilitator/f_report.html',
				controller : 'reportCtrl'
			} 
		}
	})
	
	.state("login", {
		url : '/login',
		templateUrl : '/CAP/views/cap_login.html',
		controller : 'loginCtrl'
	});

/*
 * it consists of the datepicker used in registered user page
 * helps to select the dates for which the registered user will 
 * vacate the lots for unregistered user
 */
app.config(['datepickerConfig', 'datepickerPopupConfig', function(datepickerConfig, datepickerPopupConfig) {
	datepickerConfig.startingDay = 0;
    datepickerPopupConfig.showButtonBar = false;
    datepickerPopupConfig.datepickerPopup = "dd.MM.yyyy";
}]);
app.config(['growlProvider', function(growlProvider) {
	  growlProvider.onlyUniqueMessages(false);
	}]);

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
 *   states aka nested states.
 */
app.run([ '$rootScope', '$state', '$stateParams','localStorageService', function($rootScope, $state, $stateParams,localStorageService) {
     
    $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams){  
    	if(!localStorageService.get('userObject') && toState.name !== 'login') {
    	    $state.go("login");
    	    event.preventDefault();
    	  }
    	else if((localStorageService.get('userObject')!=null) && ((toState.name =='login'))) {
    		 $state.go(fromState);
    	  }
    	else if ((localStorageService.get('userObject')!=null) && ((toState.name !='login'))){
   		 $state.go(fromState);
   	  }    	

    });

}]);

