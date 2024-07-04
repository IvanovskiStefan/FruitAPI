# FruitAPI

This application allows you to fetch information about fruits from the Fruityvice API and manage metadata.

## Setup Instructions

1. Clone the repository.
2. Navigate to the project directory.
3.Start the FruityAPI solution.
4. Restore dependencies using `dotnet restore`.
5. Build the project using `dotnet build`.
6. Run the application using `dotnet run`.

## API Endpoints

- `GET /api/fruits/{name}`: Fetch fruit information by name.
- `PUT /api/fruits/{name}/metadata`: Update metadata on a fruit.
  *Due to the limitations of the Fruityvice API, the remove, add and delete metadata are in the same endpoint(the PUT endpoint is used for this purpose.)

## Error Handling

The API will return appropriate error messages for incorrect inputs or API connectivity issues.
