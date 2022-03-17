# Simple-API
This is a simple backend API server, and it can be used for frontend AJAX practice/learning.

This project is configured to use LocalDB, which is only available on Windows machines.
Before you can use this API, you need to apply the migration to the database, using the command:
  > dotnet ef database update Initial

## Documentation
This API is working with "product" entities, that you can get, add, update and delete.

Product entity consists of: <br>
>Name: string (required) <br>
>Price: double (required) <br>
>Category: string (required) <br>
>Description: string (optional) <br>

### GET
To get a JSON collection of all products, use following method:
> GET /api/products

To get JSON object for one single product, use following method:
> GET /api/products/{productId:GUID}

### POST
To create a new product, use following method:
> POST /api/products

with request body (example): 
>{ <br>
>&nbsp;"name": "Ball", <br>
>&nbsp;"price": 123, <br>
>&nbsp;"category": "Sport", <br>
>&nbsp;"description": "Round ball" <br>
>}

Response will be a JSON object of the new product with an unique ID.

