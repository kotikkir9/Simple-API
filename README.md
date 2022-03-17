# Simple-API
This is a simple backend API server, and it can be used for frontend AJAX practice/learning.

This project is configured to use LocalDB, which is only available on Windows machines.
Before you can use this API, you need to apply the migration to the database, using the command:
  > dotnet ef database update Initial

## Documentation
This API is working with "product" entities, that you can read, create, update and delete.

Product entity consists of: <br>
>Name: string (required) <br>
>Price: double (required) <br>
>Category: string (required) <br>
>Description: string (optional) <br>

### GET
To get a JSON collection of all products, use the following method:
> GET /api/products

You can filter the products by adding "search" query in the URL, like in following example (your seach query will be compared against product name, category and description):
> GET /api/products?search=ball

To get JSON object for one single product, use following method:
> GET /api/products/{productId:GUID}

### POST
To create a new product, use the following method:
> POST /api/products

with request body (example): 
>{ <br>
>&nbsp;"name": "Ball", <br>
>&nbsp;"price": 123, <br>
>&nbsp;"category": "Sport", <br>
>&nbsp;"description": "Round ball" <br>
>}

Response will be a JSON object of the new product with an unique ID.

### PUT
To update an existing product, use the following method: 
> PUT /api/products

with request body (example): 
>{ <br>
>&nbsp;"id": "8dba1425-e5ea-4581-8294-a52f794a51a7",<br>
>&nbsp;"name": "Ball", <br>
>&nbsp;"price": 100, <br>
>&nbsp;"category": "Sport", <br>
>&nbsp;"description": "This field is optional, and is allowed to be null" <br>
>}

Response will be a JSON object of the updated product.

### DELETE
To delete a product from the database, use the following method:
> DELETE /api/products/{productId:GUID}
