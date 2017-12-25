var app = angular.module("ApplicationModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

//Showing Routing   
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    //debugger;
    $routeProvider.when('/ShowNums',
                        {
                            templateUrl: 'NumTable/ShowNums',
                            controller: 'ShowNumsController'
                        });
    $routeProvider.when('/AddNewNum',
                        {
                            templateUrl: 'NumTable/AddNewNum',
                            controller: 'AddNumController'
                        });
    $routeProvider.when("/editnum",
                         {
                             templateUrl: 'NumTable/NumView',
                             controller: 'EditNumController'
                         });
    $routeProvider.when('/guestnum',
                       {
                           templateUrl: 'NumTable/ViewGuest',
                           controller: 'GuestNumController'
                       });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });

    $locationProvider.html5Mode({ 
        enable:true, 
        requireBase:false}).hashPrefix('!')
}]);
