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
