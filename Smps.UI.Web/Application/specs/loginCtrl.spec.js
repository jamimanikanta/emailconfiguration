describe("Login Controller Test", function () {
    var controller, usersController,scope,$rootscope;

    //// Load our api.users module
    beforeEach(module('SMPSapp','ui.router'));

    //// Inject the $controller service to create instances of the controller (UsersController) we want to test
    beforeEach(inject(function ($controller, $rootScope, userAccountService) {
        scope = $rootScope.$new();
        $rootscope = $rootScope;
        
        controller = $controller;
        usersController = controller('loginCtrl', { $scope: scope, $rootScope: $rootScope, userAccountService: userAccountService });
    }));

    it("Validate Login", function () {
        scope.login();
       ////expect(scope.Text).toBe("Hello");
        expect(scope.errorFlag).toBe(true);
    });
});