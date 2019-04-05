# Northwind

Northwind provides a simple .NET Core Web API.

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
- Northwind.Support - Contains solution support files. This is _not_ compiled.

## Setup

- Restore the "Northwind" database locally.

   - There is a Northwind database backup located here: ./Source/Northwind.Support/Northwind.zip.
   - You should be able to create a new "Northwind" database locally and restore this backup on top of it.