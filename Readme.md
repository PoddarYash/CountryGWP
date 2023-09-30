# GWP Calculator

## Project Notes


1. **Server Setup**: A self-hosted web API server as a console application has not been setup due to a lack of experience on the same, thus a WebAPI project was created.

2. **Potential Improvements**:
   - Implementing Fluent Validation.
   - Adopting a Clean Architecture approach.
   - Implementation of global exception handling.


## Running the .NET API

To run the .NET API, follow these steps:

1. **Prerequisites**: Ensure you have the following prerequisites installed on your system:
   - [.NET 6 SDK](https://dotnet.microsoft.com/download) for building and running .NET applications.

2. **Clone the Repository**: Clone the Git repository to your local machine using the `git clone` command.

3. **Navigate to the Project Directory**: Open a terminal or command prompt and navigate to the directory containing your .NET API project.

4. **Build the Project**: Run the following command to build the project:

```shell
dotnet build
```

5. **Run the API**: Once the build is successful, run the API with the following command:
```shell
dotnet run --project CountryGWP.API --launch-profile "CountryGWP.API"
```

6. **Access the API with Swagger**: Since you already have Swagger configured, you can utilize it to evaluate the API endpoints. Open your internet browser and navigate to this URL: [http://localhost:9091/swagger/index.html](http://localhost:9091/swagger/index.html)

These instructions should help you get your .NET API up and running for development and testing purposes.
