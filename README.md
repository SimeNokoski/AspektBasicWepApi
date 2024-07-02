# BasicWepAPI
## Overview

The Application is a .NET 6-based solution developed to streamline the management of contacts associated with companies and countries. It provides a centralized platform for efficiently storing, organizing, and accessing contact information within the context of business relationships and geographic locations.

## Technologies Used

- **Programming Language and Platform:** .NET 6
- **Integrated Development Environment (IDE):** Visual Studio
- **Database:** Microsoft SQL Server
- **Object-Relational Mapping (ORM):** Entity Framework with NuGet packages
- **Validation:** Fluent Validation with NuGet packages
- **Unit Testing:** Moq for mocking in unit tests
- **Architecture:** Onion Architecture
- **Dependency Injection:** .NET Core Dependency Injection
- **API Documentation:** Swagger
- **Logging:** Serilog for structured logging

### Features

- **ORM (Entity Framework):** Simplified data access using Entity Framework for seamless integration with Microsoft SQL Server.
- **Validation (Fluent Validation):** Implemented Fluent Validation to ensure accurate and secure data validation.
- **Unit Testing (Moq):** Utilized Moq framework for effective unit testing with mocked dependencies.
- **Architecture (Onion Architecture):** Followed Onion Architecture principles to organize the application into layers for maintainability and scalability.
- **Dependency Injection:** Leveraged .NET Core’s Dependency Injection for managing object dependencies and promoting modularity.

## Controllers

### CompanyController

Handles operations related to companies.

#### Endpoints:

- `GET /api/Company`
  - Retrieves all companies.
  - **Request:** None
  - **Response:** 
    ```json
    [
        {
          "id": 1,
          "companyName": "string"
        },
        {
          "id": 2,
          "companyName": "Samsung"
        }
    ]
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `GET /api/Company/{id}`
  - Retrieves a company by ID.
  - **Request:** `/api/company/1`
  - **Response:** 
    ```json
    {
        "id": 1,
        "companyName": "Aspekt"
    }
    ```
  - **404 Not Found Response:** 
    ```json
    "Company with 1 was not found"
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `POST /api/Company`
  - Creates a new company.
  - **Request:** 
    ```json
    {
        "companyName": "Aspekt",
    }
    ```
  - **Response:** 201 Created
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `PUT /api/Company`
  - Updates an existing company.
  - **Request:** 
    ```json
    {
        "id": 1,
        "companyName": "Aspekt"
    }
    ```
  - **Response:** 200 OK
  - **404 Not Found Response:** 
    ```json
    "Company with id 1 not found."
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `DELETE /api/Company/{id}`
  - Deletes a company by ID.
  - **Request:** `/api/Company/1`
  - **Response:** 200 OK
  - **400 Bad Request**
    ```json
    "Invalid id"
    ```
  - **404 Not Found Response:** 
    ```json
    "Company with id 1 not found."
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

### ContactController

Manages operations related to contacts.

#### Endpoints:

- `GET /api/Contact`
  - Retrieves all contacts.
  - **Request:** None
  - **Response:** 
    ```json
    [
      {
        "id": 1,
        "contactName": "Sime Nokoski",
        "companyId": 1,
        "countryId": 2
      },
      {
        "id": 2,
        "contactName": "Bob Bobsky",
        "companyId": 2,
        "countryId": 2
      }
    ]
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `GET /api/Contact/{id}`
  - Retrieves a contact by ID.
  - **Request:** `/api/Contact/1`
  - **Response:** 
    ```json
    {
      "id": 1,
      "contactName": "Sime Nokoski",
      "companyId": 1,
      "countryId": 2
    }
    ```
  - **404 Not Found Response:** 
    ```json
    "Contact with 1 was not found"
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `POST /api/Contact`
  - Creates a new contact.
  - **Request:** 
    ```json
    {
      "contactName": "Sime Nokoski",
      "companyId": 1,
      "countryId": 2
    }
    ```
  - **Response:** 200 OK
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `PUT /api/Contact`
  - Updates an existing contact.
  - **Request:** 
    ```json
    {
      "id": 1,
      "contactName": "Sime Nokoski",
      "companyId": 1,
      "countryId": 2
    }
    ```
  - **Response:** 200 OK
  - **404 Not Found Response:** 
    ```json
    "Contact with 1 was not found"
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `DELETE /api/Contact/{id}`
  - Deletes a contact by ID.
  - **Request:** `/api/Contact/1`
  - **Response:** 200 OK
    - **400 Bad Request**
    ```json
    "Invalid id"
    ```
  - **404 Not Found Response:** 
    ```json
    "Contact with 1 was not found"
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `GET /api/Contact/getContacts`
  - Retrieves contacts with associated company and country information.
  - **Request:** None
  - **Response:** 
    ```json
    [
      {
        "contactId": 2,
        "countryId": 2,
        "companyId": 2,
        "contactName": "Sime Nokoski",
        "countryName": "Macedonia",
        "companyName": "Aspekt"
      },
      {
        "contactId": 1,
        "countryId": 1,
        "companyId": 2,
        "contactName": "Bob Bobsky",
        "countryName": "Croatia",
        "companyName": "Aspekt"
      },
    ]
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `GET /api/contact/filterContacts`
  - Filters contacts by country ID and/or company ID.
  - **Request with two parameters:** `/api/Contact/filterContacts?countryId=2&companyId=2`
  - **Response:** 
    ```json
    [
        {
          "contactId": 4,
          "countryId": 2,
          "companyId": 2,
          "contactName": "Smith",
          "countryName": "Macedonia",
          "companyName": "Aspekt"
        }
    ]
    ```
  - **Request with one parameter companyId:** `/api/Contact/filterContacts?companyId=2`
  - **Response:** 
    ```json
    [
        {
          "contactId": 4,
          "countryId": 1,
          "companyId": 2,
          "contactName": "Smith",
          "countryName": "Macedonia",
          "companyName": "Aspekt"
        },
                {
          "contactId": 3,
          "countryId": 4,
          "companyId": 2,
          "contactName": "Bob",
          "countryName": "Germany",
          "companyName": "Aspekt"
        }
    ]
    ```
  - **Request with one parameter countryId:** `/api/Contact/filterContacts?countryId=1`
  - **Response:** 
    ```json
    [
        {
          "contactId": 5,
          "countryId": 1,
          "companyId": 3,
          "contactName": "Smith",
          "countryName": "Macedonia",
          "companyName": "Aspekt"
        },
                {
          "contactId": 6,
          "countryId": 1,
          "companyId": 5,
          "contactName": "Jill",
          "countryName": "Germany",
          "companyName": "Aspekt"
        }
    ]
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `GET api/Contact/getCompanyStatisticsByCountryId?id={id}`
  - Retrieves statistics of companies by country ID.
  - **Request:** `api/Contact/getCompanyStatisticsByCountryId?id=1`
  - **Response:** 
    ```json
    {
      "Aspekt": 1,
      "Lidl": 1
    }
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

### CountryController

Manages operations related to countries.

#### Endpoints:

- `GET /api/Country`
  - Retrieves all countries.
  - **Request:** None
  - **Response:** 
    ```json
    [
        {
            "id": 1,
            "countryName": "Macedonia"
        },
        {
            "id": 2,
            "countryName": "Croatia"
        },
    ]
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```
- `GET /api/Country/{id}`
  - Retrieves a country by ID.
  - **Request:** `/api/Country/1`
  - **Response:** 
    ```json
    {
        "id": 1,
        "countryName": "Macedonia"
    }
    ```
  - **404 Not Found Response:** 
    ```json
    "Country with 1 was not found"
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `POST /api/Country`
  - Creates a new country.
  - **Request:** 
    ```json
    {
        "countryName": "Macedonia",
    }
    ```
  - **Response:** 201 Created
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `PUT /api/Country`
  - Updates an existing country.
  - **Request:** 
    ```json
    {
        "id": 1,
        "countryName": "Macedonia"
    }
    ```
  - **Response:** 200 OK
  - **404 Not Found Response:** 
    ```json
    "Country with id 1 not found."
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

- `DELETE /api/Country/{id}`
  - Deletes a company by ID.
  - **Request:** `/api/Country/1`
  - **Response:** 200 OK
  - **400 Bad Request**
    ```json
    "Invalid id"
    ```
  - **404 Not Found Response:** 
    ```json
    "Country with id 1 not found."
    ```
  - **500 Internal Server Error Response:** 
    ```json
    "System error occurred."
    ```

## Contact

For additional information or inquiries, please contact Sime Nokoski at simenokoski99@hotmail.com.
