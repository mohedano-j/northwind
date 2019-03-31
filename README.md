# Northwind

This is a sample .NET Core application suite.

    --- BEGIN WARNING ---

    ALL OF THIS IS FOR EDUCATIONAL PURPOSES ONLY
    THIS DOCUMENT, AND ALL CODE WITHIN, IS A WORK IN PROGRESS

    --- END WARNING ---

## Setup

1. Restore the Northwind database locally.

Under the ./Source/Northwind.Support/ projects there is a file called Northwind.zip.
This zip contains a backup of the Northwind database.
You should be able to create a new "Northwind" database locally and restore this backup on top of it.

2. Build and publish the Northwind.Web application to a local folder.

- In Visual Studio, publish to a local folder.
- For example: C:\_publish\northwind.web\

3. Configure the Northwind.Web application to run under IIS.

At the end of the day this URL should work: http://localhost/northwind.web/products/

- Create a new web application called "northwind.web" under your default web site.
- Point this application at the published application you setup above.

4. In Visual Studio, run the Northwind.Angular.Web application.
