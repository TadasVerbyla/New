## Launch

The project requires .NET6.0 SDK to be installed. It can be found following the provided link: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

After .NET 6.0 has been configured, open the project folder via cmd or the terminal of your prefered IDE. 

Then, execute the command `dotnet run`. 

After the project has been built, open `https://localhost:7056/swagger/index.html` in your browser. 

## General information:
                          

Our lab3 project was created using C# EntityFramework for a code-first design. 
                          

First, we have created the Models that would form the database, then used EF to create a database based on the models. 
                          

Second, we created Controller classes for the CRUD endpoints. These classes invoke ModelData methods that change the database.
                          

Initially, we have used the same Models of that form the database as parameters for API's, but later we created Data Transfer Object classes for this task instead. 
                          

 
                          

## Project structure:
                          

### Controllers
                          

Controllers for all the CRUD endpoints. A single controller class is created for each individual database table. 


### DataTranferObjects
                          

Stores DTO's for each type of data model class. These DTO's are used by POST and PATCH commands, where they get converted into the needed data model object. 
                          

### DB
                          

This folder stores the DBContext class, which, using EF, generates the database based on our data models. 
                          

### Migrations
                          

This folder stores migrations of our database which are used to generate it. 
                          

### ModelData
                          

Stores the methods that interface with the database to modify it. Individual folders for each type of model CRUD opperations. 
                          

### Models
Stores classes that forn the basis of our database. 

## CHANGELOG
### Details deviations from lab1 and lab2 specifications. 

The lab2 .yaml file that was provided lacked many important entities of the lab 1 datamodel. 
Our team reviewed the original lab1 datamodel and used it to create the data models for lab3. 

The following are data entities as specified by the lab2:

### Checkout -> Payment
Renamed to Payment in refrence to the entity from lab1 from which Checkout was derived in lab2. 
Added missing lab1 Payment fields that were missing in lab2 Checkout. 

### Complaint
This entity didn't exist in lab1 and in lab2 it has no connections, hence it was not implemented. 

### Employee
Implemented according to lab2. 

### Order
Order in .yaml was missing many of the lab1 Order fields, which we added for our data model. 

### Permission
Implemented according to lab2. 

### Review
Not implemented for the same reason as Complaint. 

### Shift
Field EmployeeId was removed and instead it is the Employee that has a ShiftId. 

### Support -> SupportRequest
Renamed to SupportRequest as was in lab1, added fields misssed from lab1. 

### User -> Customer
Renamed to Customer. 
Added username field that was missing in both lab1 and lab2. 


## Created new entities in accordance to lab1 because they were missing in lab2:

### Business
Created based on lab1 but without Logo ID field that we found to be unecessary

### OrderItem
Same as in lab1

### Item
Same as in lab1

Order item and Permission management fields from lab1 were used to represent n-to-n connections. We used List<> fields instead, thus these tables were not implemented


## LAB2 API'S
.yaml file of the lab2 did not define any non-CRUD api's for the system, thus we did not have a basis to make business API's. 
Because of this we chose to disregard lab2 almost entirely. Using the datamodel created from lab2 and lab1, we created CRUD endpoints for the Point of Sale system. 
We have decided not to implement any specific non-CRUD endpoints ourselves. We weren't provided these endpoints in lab2. 
Instead we have decided that PATCH commands, which can edit only specified fields, can be used instead of more specific endpoints. 
For instance, order status can be changed by calling a PATCH command and providing a JSON body of only the new status. 
