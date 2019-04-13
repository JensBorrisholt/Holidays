# Holidays

**Canculation of National Holidays**

Based on the Easter calculation this library calculates a lot of national holidays. 

And even better: Included are also a program that can generate a holiday file for a country based on the informations found on  https://www.officeholidays.com/.  Both a  Delphi and C# version will be generated. 

The library supports calculation of both the regular Easter and the Ortodox Easter. 

## How to use?

Say you want a list of Danish holidays for 2019 you simply write the following: 

`Holidays := THolidays<Dainsh>.Construct(2019, false, true);`

First parameter is the yesr, second where to include sundays or not, third parameter is where to include holidays or not. 

![Danish Holidays 2019](https://github.com/JensBorrisholt/Holidays/blob/master/DanishHolidays2019.png "Danish Holidays 2019")

##Techniques
In this solution, different techniques have been Implemented.

- Delphi Console
- Dependency Injection
- TEnumerable
- Interfaces

##National holidays:

This initial includes holidays for the following countries:

- Anguilla
- Antigua And Barbuda
- Argentina
- Armenia
- Aruba
- Austria
- Bahamas
- Barbados
- Belarus
- Belgium
- Belize
- Bermuda
- Brazil
- Bulgaria
- Cayman Islands
- Chile
- Cyprus
- Danish
- Germany
- Gibraltar
- Greenland
- Liechtenstein
- Norway
- Sweden
- Usa

