# _Hair_Salon

#### _C# Hair Salon App using C#, MSTest and .NET Core Dec 2018_

#### By _**James Cho**_

## Description

A C# program, that allows the user to input stylists into the database and add clients for each stylist.

## Specifications
  * The program takes the stylist info from user input including "name", "specialty" and "schedule".
    - Example User Input : ["Jess", "haircuts", "weekdays"]
    - The program then constructs a Stylist object and saves it to the database.
   
  * The program takes client info from user input including "name", and "number".
    - Example User Input : ["Mike", 1233456789]
    - The program then constructs a Client object with the corresponding Stylist and saves it to the database.

  * The program takes specialty info from user input including "name".
    - Example User Input : ["beard trim"]
    - The program then constructs a Specialty object and saves it to the database.

  * The program allows the user to add stylists to specialties and specialties to stylists
    - Example : [ specialty: ["beard trim"] , stylists: ["Mike", "Barbara"]]
    - Example : [ stylist: ["Jim"] , specialties: ["perm", "highlights"]]

    - The program adds connections to a JOIN table and saves it to the database.


## Setup/Installation Requirements

Download .NET Core 2.1.3 SDK and .NET Core Runtime 2.0.9 and install them. Download Mono and install it.

* Clone this repository: $ git clone https://github.com/hwisoo/CsharpHairSalon.Solution.git
* Change into the work directory:: $ cd CsharpHairSalon.Solution
To edit the project, open the project in your preferred text editor.
* Find james_cho.sql and james_cho_test.sql files in the top level of the project directory.
* Click on the 'Import' tab and follow instructions to import james_cho.sql and james_cho_test.sql files into the current server.

 To setup project database
* Setup and Run MAMP. On the Starting page, click on the 'Tools' tab and open 'PHPMYADMIN'.
* CREATE DATABASE james_cho;
* USE james_cho;
* CREATE TABLE clients (name VARCHAR(255), phone INT(11), stylist_id INT(11), id serial PRIMARY KEY));
* CREATE TABLE stylists (name VARCHAR(255), schedule VARCHAR(255), id serial PRIMARY KEY);
* CREATE TABLE specialties (name VARCHAR(255) id serial PRIMARY KEY);
* CREATE TABLE stylists_specialties (stylist_id INT(11), specialty_id INT(11), id serial PRIMARY KEY);

To setup test database
* For the test database, Setup and Run MAMP. On the Starting page, click on the 'Tools' tab and open 'PHPMYADMIN'.
* CREATE DATABASE james_cho_test;
* USE james_cho_test;
* CREATE TABLE clients (name VARCHAR(255), phone INT(11), stylist_id INT(11), id serial PRIMARY KEY));
* CREATE TABLE stylists (name VARCHAR(255), schedule VARCHAR(255), id serial PRIMARY KEY);
* CREATE TABLE specialties (name VARCHAR(255) id serial PRIMARY KEY);
* CREATE TABLE stylists_specialties (stylist_id INT(11), specialty_id INT(11), id serial PRIMARY KEY);


To run the program, first navigate to the location of the Program.cs file then run these commands: $ dotnet restore $ dotnet build $ dotnet run

To run the tests, use these commands: $ cd HairSalon.Tests $ dotnet test




## Known Bugs

no known bugs

## Support and contact details

_James Cho - hwisoocho@gmail.com or visit my Github at https://github.com/hwisoo_

## Technologies Used

C#, MSTest, .NET Core, Bootstrap, CSS, Google Fonts

### License

*MIT License*

Copyright (c) 2018 **_James Cho_**