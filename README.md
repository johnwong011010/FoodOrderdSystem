# This is a exsample domain driven design pattern
## FoodOrdedSystem
All forward endpoint is defined here,It's highly recommend using identity server for backend authenication and authrozation
## FoodOrdedSystem.Application
The imperment of business logic go on here,you can add any service as you want.
## FoodOrdedSystem.Domain
The thing related to business is stored here,including business item,logic of CRUD.
## FoodOrdedSystem.EntiityFrameworkCore
Imperment the connection and CRUD for DB using Entity Framework Core(EF core),A ORM for better control
## FoodOrdedSystem.Infrastruture
All the basic item using in solution is define here
--- 
In API,Application and EntityFramewordCore layer,they have a folder call dependencyInjection.This is response to doing to DI things.so you don't need to configure all the thing in to Program.cs.Just remember when you add a new repository and service,you need to add into application and entityframework layer.