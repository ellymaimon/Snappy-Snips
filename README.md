# Snappy Snips Salon Management Tool

#### Epicodus C# Code Review, July 20, 2018

#### By Elly Maimon

## Description

Snappy Snipts Salon Management Tool is a .NET web application that allows a user to add, update, and delete stylists, clients, and specialties and view or edit those categories.

## How to Recreate Database

* To recreate the main database, enter the following commands into terminal:
    * > mysql -uroot -proot;
    * > CREATE DATABASE eliran_maimon;
    * > USE eliran_maimon;
    * > CREATE TABLE Stylists (StylistId serial PRIMARY KEY, StylistFirstName VARCHAR(255), StylistLastName VARCHAR(255)));
    * > CREATE TABLE Clients (ClientsId serial PRIMARY KEY, ClientFirstName VARCHAR(255), ClientLastName VARCHAR(255));
    * > CREATE TABLE StylistClients (StylistClientId serial PRIMARY KEY, ClientId INT, StylistID INT);
    * > CREATE TABLE StylistSpecialties (StyliesSpecialtyId serial PRIMARY KEY, SpecialtyId INT, StylistID INT);
* To recreate the test database, enter the following commands into terminal:
    * > mysql -uroot -proot;
    * > CREATE DATABASE eliran_maimon_test;
    * > USE eliran_maimon_test;
    * > CREATE TABLE Stylists (StylistId serial PRIMARY KEY, StylistFirstName VARCHAR(255), StylistLastName VARCHAR(255)));
    * > CREATE TABLE Clients (ClientsId serial PRIMARY KEY, ClientFirstName VARCHAR(255), ClientLastName VARCHAR(255));
    * > CREATE TABLE StylistClients (StylistClientId serial PRIMARY KEY, ClientId INT, StylistID INT);
    * > CREATE TABLE StylistSpecialties (StyliesSpecialtyId serial PRIMARY KEY, SpecialtyId INT, StylistID INT);

    dotnet ef migrations add Initial
    dotnet ef database update

## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Download and install MAMP 4.5
* Clone the repo
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet ef migrations add Initial` from project directory
* Run `dotnet ef database update` from project directory to run database migration
    * Alternately, import provided databases.
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to start the server
* Alternatively, run `dotnet watch run` to start the server with the watcher tool

## Technologies Used

* .Net Core 1.1.4
* Entity Framework Core 1.1.2
* MAMP 4.5
* MySQL
* Bootstrap 4
* jQuery 3.3.1

## Links

* Repository: https://github.com/ellymaimon/Snappy-Snips

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Elly Maimon**
