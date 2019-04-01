# Northwind

This is a sample .NET Core application suite.

    --- BEGIN WARNING ---

    ALL OF THIS IS FOR EDUCATIONAL PURPOSES ONLY
    THIS DOCUMENT, AND ALL CODE WITHIN, IS A WORK IN PROGRESS

    --- END WARNING ---

## Overview

The included solution contains several projects:

- Northwind - This library contains all of the code that is sharable amongst all projects. This could be thought of as the "Contracts" or "Client" library.
- Northwind.Services - This contains all of the contract implementations and data access code.
- Northwind.ConsoleApp - This is a very basic console application primarily used to provde that Northwind.Services is working.
- Northwind.Web - This is a Web API project that provides access to your local "Northwind" database over HTTP.
- Northwind.Web.Store - This is a Angular 7 application that acts as the customer-facing front-end.
- Northwind.Support - Contains solution support files. This is _not_ compiled.

## Setup

1. Restore the "Northwind" database locally.

   - There is a Northwind database backup located here: ./Source/Northwind.Support/Northwind.zip.
   - You should be able to create a new "Northwind" database locally and restore this backup on top of it.

2. Configure both the Northwind.Web and Northwind.Web.Store projects to run under their named configurations:
	- In Visual Studio at the top of the screen select the "Northwind.Web" project.
	- Once this project has been selected, its name should appear next to the green play button.
	- To the right of the play button there is a down-arrow.
	- Click the down arrow and change from "IIS Express" to "Northwind.Web".
	- Repeat for "Northwind.Web.Store".

3. Setup the solution to run multiple projects simulateously.
	- Right-click on the Northwind solution and select properties.
	- The "Startup Project" item on the left should be selected.
	- Click the radio button next to "Multiple startup projects".
	- For both "Northwind.Web" and "Northwind.Web.Store" change the action to "Start".

You should now be able to debug both the web API project as well as the client application in Visual Studio.

## To Do

- Continue to expand on the Angular application

  - Create a "app-product" component that represents a single product.
  - Create service methods for updating and creating products.

- Continue to expand the the Northwind.Web Web API surface (e.g. Add a /categories/ endpoint).

- Create a Northwind.Web.Admin project that uses React.