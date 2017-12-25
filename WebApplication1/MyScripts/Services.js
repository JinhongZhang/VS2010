app.service("SPACRUDService", function ($http) {   
      
        //Read all Students   
    this.getNumTables = function (year,PageSize) {   
                 
        return $http.get("/api/NumTables?year=" + year + "&iPageSize=" + PageSize);
            };   
    //Read all Students   
    this.GuestNumbers = function () {

        return $http.get("/api/NumTables");
    };
        //Fundction to Read Student by Student ID   
        this.getNumTable = function (id) {
            return $http.get("/api/NumTables/" + id);
            };   
       
        //Function to create new Student   
        this.post = function (NumTable) {   
                var request = $http({   
                        method: "post",   
                        url: "/api/NumTables",
                        data: NumTable
                });   
            return request;   
        };   
        
    //Edit Student By ID    
        this.put = function (id, NumTable) {
            var request = $http({   
                    method: "put",   
                    url: "/api/NumTables/" + id,
                data: NumTable
            });   
        return request;   
    };   
  
    //Delete Student By Student ID   
   this.delete = function (id) {   
           var request = $http({   
               method: "DELETE",
               url: "/api/NumTables/" + id
            });   
        return request;   
    };   
});  
