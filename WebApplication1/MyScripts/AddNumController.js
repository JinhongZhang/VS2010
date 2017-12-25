app.controller('AddNumController', function ($scope, SPACRUDService) {   
       $scope.ID = 0;   
            
        $scope.save = function () {   
               var NumTable = {   
                   ID: $scope.ID,
                        Num1: $scope.Num1,   
                        Num2: $scope.Num2,   
                        Num3: $scope.Num3,
                        Num4: $scope.Num4,
                        Num5: $scope.Num5,
                        Num6: $scope.Num6,
                        NumSP: $scope.NumSP,
                        Seq: $scope.Seq,
                        StartDate: $scope.StartDate
                };   
       
               var promisePost = SPACRUDService.post(NumTable);
       
           promisePost.then(function (pl) {   
                    alert("Guest Numbers Saved Successfully.");   
                },   
                 function (errorPl) {   
                          $scope.error = 'failure loading Num', errorPl;   
                     });   
       
        };   
   
});  
