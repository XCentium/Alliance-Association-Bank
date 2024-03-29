# Alliance Association Bank CRM Project

## Framework
**Visual Studio 2017**  
**.NET Framework 4.7.2**  
**ASP.NET MVC 5**  

## Packages
**EntityFramework v6.2** - object-relational mapper  
**Unity.MVC v5.0.15** - IoC container ([more info](https://github.com/unitycontainer))  
**Serilog v2.7.1** - .NET logger ([more info](https://serilog.net/))  
**AutoMapper v7.0.1** - domain entity to view model object mapper ([more info](https://automapper.org/))  
**CsvHelper v7.1.1** - a library for writing CSV files ([more info](https://joshclose.github.io/CsvHelper/))       
**Bootstrap v4.1.3** - front-end component library  
**jQuery v3.3.1**  
**jQuery.UI v1.12.1** - autocomplete and datepicker widgets ([more info](https://jqueryui.com/))    
**Select2 v4.0.6** - searchable dropdown list ([more info](https://select2.org/))  
**ReportViewerForMvc v1.1.1** - Web Forms ReportViewer control adapter for MVC ([more info](https://github.com/chasoliveira/ReportViewerForMvc))  

## Config Files
#### Web.config
The connection string entry with name of **CrmApplicationDbConnection** needs to be updated to point to the correct SQL Server database.
#### UserAuthenticationSettings.config
Configurations for user authentication against Active Directory. Three AD security group names must be set in this file correctly for admin, read-write and read-only users.
#### DropDownListSettings.config
Configuration of possible values for some of the dropdown lists. However, some dropdown lists are controlled by SQL tables (Employees, Software/MigrateTo and ReformatAQ2).
#### LoggerSettings.config
Configurations for Serilog logging such as log files location and minimum logging level.
#### AppTextContent.config
The config file to specify various pieces of text content. At this point legal message copy can be set here.

