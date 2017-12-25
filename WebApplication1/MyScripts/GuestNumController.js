app.controller('GuestNumController', function ($scope, $location, SPACRUDService, ShareData) {
    GuestRecords();

    function GuestRecords() {
        var promiseGetNums = SPACRUDService.GuestNumbers();

        promiseGetNums.then(function (pl) { $scope.CalResult = pl.data },
                  function (errorPl) {
                      $scope.error = errorPl;
                  });
    }

    //To Edit Student Information   
    $scope.DeleteLast = function () {        
        var promisePost = SPACRUDService.delete(1);
        promisePost.then(function (pl) {
            alert("Deleted Last Number Successfully.");
        },
                function (errorPl) {
                    $scope.error = 'failure Delete Last Number', errorPl;
                });
    }

    //To Load data Information   
    $scope.RunGuest = function () {
        GuestRecords();
    }

    //To Load data Information   
    $scope.Restore = function () {
        var promisePost = SPACRUDService.delete(0);
        promisePost.then(function (pl) {
            alert("Restore Number Successfully.");
        },
                function (errorPl) {
                    $scope.error = 'failure Restore Number', errorPl;
                });
    }

});


