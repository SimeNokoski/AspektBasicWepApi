# Aspect-Basic Web API
## Introduction
##### Instruction tekst

## Technologies Used
### Backend
##### Pojaznuvanje za ovaa tehnologia
### Frontend
##### Tekst za ovaj del



## Controllers

### CompanyController

Handles operations related to companies.

#### Endpoints:

- `GET /api/company`
  - Retrieves all companies.
  - **Request:** None
  - **Response:** 
    ```json
    [
        {
            "id": 1,
            "name": "Company A",
            "address": "123 Street, City",
            ...
        },
        ...
    ]
    ```
  - **404 Not Found Response:** 
    ```json
    {
        "statusCode": 404,
        "message": "No companies found."
    }
    ```
  - **500 Internal Server Error Response:** 
    ```json
    {
        "statusCode": 500,
        "message": "Internal server error occurred."
    }
    ```

- `GET /api/company/{id}`
  - Retrieves a company by ID.
  - **Request:** `/api/company/1`
  - **Response:** 
    ```json
    {
        "id": 1,
        "name": "Company A",
        "address": "123 Street, City",
        ...
    }
    ```
  - **404 Not Found Response:** 
    ```json
    {
        "statusCode": 404,
        "message": "Company with id 1 not found."
    }
    ```
  - **500 Internal Server Error Response:** 
    ```json
    {
        "statusCode": 500,
        "message": "Internal server error occurred."
    }
    ```

- `POST /api/company`
  - Creates a new company.
  - **Request:** 
    ```json
    {
        "name": "New Company",
        "address": "456 Street, City",
        ...
    }
    ```
  - **Response:** 201 Created
  - **404 Not Found Response:** Not applicable
  - **500 Internal Server Error Response:** 
    ```json
    {
        "statusCode": 500,
        "message": "Internal server error occurred."
    }
    ```

- `PUT /api/company`
  - Updates an existing company.
  - **Request:** 
    ```json
    {
        "id": 1,
        "name": "Updated Company A",
        "address": "456 Street, City",
        ...
    }
    ```
  - **Response:** 200 OK
  - **404 Not Found Response:** 
    ```json
    {
        "statusCode": 404,
        "message": "Company with id 1 not found."
    }
    ```
  - **500 Internal Server Error Response:** 
    ```json
    {
        "statusCode": 500,
        "message": "Internal server error occurred."
    }
    ```

- `DELETE /api/company/{id}`
  - Deletes a company by ID.
  - **Request:** `/api/company/1`
  - **Response:** 200 OK
  - **404 Not Found Response:** 
    ```json
    {
        "statusCode": 404,
        "message": "Company with id 1 not found."
    }
    ```
  - **500 Internal Server Error Response:** 
    ```json
    {
        "statusCode": 500,
        "message": "Internal server error occurred."
    }
    ```

