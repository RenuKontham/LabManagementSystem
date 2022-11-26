LabManagementSystem- Capstone project details

This is the repo for .Net Core 6 Web API with all CRUD operations for Author, Category and Lab.

This API is connected to a SQL database "Capstone-rk" in SQL server "socgensqlserver".
Deployed this API to App service "capstone-rk-webapp", resource group is capstone-rk-rg.
Created Azure key vault "capstone-rk-dbkey" which has a secret "db-conn-string" to store connectionstring.
API is connected to Azure key vault to retrive the connectionstring, instead of storing it.

Website url: https://capstone-rk-webapp.azurewebsites.net/
A swagger is enabled for this website and the link is https://capstone-rk-webapp.azurewebsites.net/swagger/index.html

