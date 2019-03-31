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
- Northwind.Web.Admin - This is a React+Redux staff-facing backend site.
- Northwind.Web.Admin2 - This is a React (no Redux) staff-facing backend.
- Northwind.Support - Contains solution support files. This is _not_ compiled.

## Setup

1. Restore the "Northwind" database locally.

   - There is a Northwind database backup located here: ./Source/Northwind.Support/Northwind.zip.
   - You should be able to create a new "Northwind" database locally and restore this backup on top of it.

2. Build and publish the Northwind.Web application to a local folder.

   - We want to publish the Web API in IIS, so that we can call it while debugging the Angular application.
   - In Visual Studio, publish to a local folder. For example: C:\_publish\northwind.web\

3. Configure the Northwind.Web application to run under IIS.

   - At the end of the day this URL should work: http://localhost/northwind.web/products/
   - Create a new web application called "northwind.web" under your default web site.
   - Point this application at the published application you setup above.
   - Locally, I created a new app pool called "northwind.web" that runs under my account. Ideally you would create a custom account and assign permissions accordingly.

4. In Visual Studio, run the Northwind.Angular.Web application.

## To Do

- Continue to expand on the Angular application

  - Create a "app-product" component that represents a single product.
  - Create service methods for updating and creating products.

- Continue to expand the the Northwind.Web Web API surface (e.g. Add a /categories/ endpoint).

- Create a Northwind.React.Web implementation.
