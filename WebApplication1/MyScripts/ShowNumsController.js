app.controller('ShowNumsController', function ($scope, $location, SPACRUDService, ShareData) {   
        loadAllNumTablesRecords();   
       
        function loadAllNumTablesRecords()
        {
            var promiseGetNums = SPACRUDService.getNumTables($("#year").val(), $("#PageSize").val());
                   
            promiseGetNums.then(function (pl) { $scope.NumTables = pl.data },
                      function (errorPl) {   
                              $scope.error =  errorPl;   
                          });   
            }   
        //To Load data Information   
        $scope.loadNums = function () {
            loadAllNumTablesRecords();
        }


        //To Edit Student Information   
        $scope.editNumTable = function (ID) {
            ShareData.value = ID;
                $location.path("/editnum");
            }   
       
        //To Delete a Student   
        $scope.deleteNumTable = function (ID) {   
            ShareData.value = ID;
                $location.path("/deletenum");
            }   
    });  
