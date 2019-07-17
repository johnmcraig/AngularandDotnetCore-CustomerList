# Customer List
> A demo using Angular 8 and ASP.Net Core 2.2 

A testable API with a functional web form designed from the Angular CLI template. This application implements API versioning and testing endpoints with Swagger and Api Versioning 3.0.1 packages. An abstract data layer contains an in-memory database to store and fetch data.

## Prerequisites
You will need the following in order to use this project for development:
- Node.js v8 or greater.
- ASP.Net Core 2.2 with the [.Net Core SDK](https://dotnet.microsoft.com/download).
- A text editor or IDE, such as [VS Code](https://code.visualstudio.com/).
- Angular 8: use `npm install @anular/cli` to isntall the latest version.
- An Operating System with an integrated terminal or command prompt.

## Project Scope
This project was created to demonstrate Api versioning, testing of controller endppoints in an MVC application, and create a single page application with input form with the latest version of Angular.

## Project Structure
The project root file consist of three directories: CustomerApi, CustomerClient, and CustomerTests. 

Our server side files are stored in the CustomerApi, which consists of ASP.Net MVC assets, folders, and files. Additional packages for Swagger and Api Versioning are stored within the `CustomerApi.csproj` file. You may have to install them seperately either via the `dotnet cli` or NuGet package manager.

The client side (front-end) files are stored in the CustomerClient. This contains all of the Angular 7 assets. A `package.json` file that provides the necessary node packages to install once and a few xUnit tests reside in the CustomerTests directory.

Fianlly, a few test classes can be located in the CustomerTests directory. These classes tests the functionality of the controllers of the Api. A `.csproj` and solution file have a reference to the 

## Setup
Download and extract the file or clone the repo. Then install the dependencies within the project directory via:
 ```sh
 $ git clone https://github.com/.../AngularandDotnetCore-CustomerList
 $ cd AngularAndDotNetCore-CustomerList
```
Change into the client folder (Amgular front-end files) and isntall node packages:
```sh
 $ cd CustomerClient
 $ npm install
```
After the node_modules file has completed installation, run the `dotnet restore` command inside the Api directory:
```sh
$ dotnet restore
```
The dependencies should now be installed. Test the application for a completed build via `dotnet run` command:
```sh
$ dotnet run
```
If there are no issues, the application should launch in a local enviroment at port 5001 within your choice of broswer. 

## TODO
Comming Soon(tm)
## Meta

Your Name – [@YourTwitter](https://twitter.com/dbader_org) – YourEmail@example.com

Distributed under the XYZ license. See ``LICENSE`` for more information.

[https://github.com/yourname/github-link](https://github.com/dbader/)

## Contributing

1. Fork it (<https://github.com/yourname/yourproject/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request