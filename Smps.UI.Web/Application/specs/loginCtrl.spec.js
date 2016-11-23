describe("Login Controller Test", function () {
    var controller, UsersController,scope,$rootscope,$http;

    //// Load our api.users module
    beforeEach(module('SMPSapp','ui.router'));

    //// Inject the $controller service to create instances of the controller (UsersController) we want to test
    beforeEach(inject(function (_$controller_, $rootScope, userAccountService) {
        scope = $rootScope.$new();
        $rootscope = $rootScope;
        userAccountService = userAccountService;

        controller = _$controller_;
       

        UsersController = controller('loginCtrl', { $scope: scope, $rootScope: $rootScope, userAccountService: userAccountService });
        
    }));

    it("Validate Login", function () {
        scope.login();
       ////expect(scope.Text).toBe("Hello");
        expect(scope.errorFlag).toBe(true);
      
    });
});