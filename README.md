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


## Setup/Installation Requirements

Download .NET Core 2.1.3 SDK and .NET Core Runtime 2.0.9 and install them. Download Mono and install it.

* Clone this repository: $ git clone https://github.com/hwisoo/CsharpHairSalon.Solution.git
* Change into the work directory:: $ cd CsharpHairSalon.Solution
To edit the project, open the project in your preferred text editor.

* To run the program, first navigate to the location of the Program.cs file then run these commands: $ dotnet restore $ dotnet build $ dotnet run

* To run the tests, use these commands: $ cd WordCounter.Tests $ dotnet test




## Known Bugs

no known bugs

## Support and contact details

_James Cho - hwisoocho@gmail.com or visit my Github at https://github.com/hwisoo_

## Technologies Used

C#, MSTest, .NET Core, Bootstrap, CSS, Google Fonts

### License

*MIT License*

Copyright (c) 2018 **_James Cho_**