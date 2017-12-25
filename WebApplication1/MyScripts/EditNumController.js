app.controller("EditNumController", function ($scope, $location, ShareData, SPACRUDService) {   
        getNumTable();   
       
        function getNumTable() {
            var promisegetNumTable = SPACRUDService.getNumTable(ShareData.value);
           
            promisegetNumTable.then(function (pl)
                    {   
                            $scope.NumTable = pl.data;   
                        },   
                              function (errorPl) {   
                                      $scope.error = 'failure loading Student', errorPl;   
                                  });   
               }   
           
        $scope.save = function () {   
            var NumTable = {
                ID: $scope.NumTable.id,
                Num1: $scope.NumTable.num1,
                Num2: $scope.NumTable.num2,
                Num3: $scope.NumTable.num3,
                Num4: $scope.NumTable.num4,
                Num5: $scope.NumTable.num5,
                Num6: $scope.NumTable.num6,
                NumSP: $scope.NumTable.numSP,
                Seq: $scope.NumTable.seq,
                StartDate: $scope.NumTable.startDate
            };
           
            var promisePutNum = SPACRUDService.put($scope.NumTable.id, NumTable);
            promisePutNum.then(function (pl)
                    {   
                $location.path("/ShowNums");
                        },   
                             function (errorPl) {   
                                      $scope.error = 'failure loading Geust Numbers', errorPl;   
                                 });   
                };   
           
        }); 
