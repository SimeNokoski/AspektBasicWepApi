# Aspect-Basic Web API
## Introduction
##### Instruction tekst

## Technologies Used
### Backend
##### Pojaznuvanje za ovaa tehnologia




## CompanyControler
### Routes
#### All endpoints for the CompanyController are relative to /api/company.
### 1.GET /api/company
#### Retrieves all companies.
### 2.GET /api/company/{id}
####Retrieves a specific company by its id.
### 3.POST /api/company
#### Creates a new company.
### 4.PUT /api/company
#### Updates an existing company.
### 5.DELETE /api/company/{id}
#### Deletes a company by its id.

### Endpoints
#### 1. GetAllCompany
#### Request: GET /api/company
### Response (200 OK):[
  {
    "id": 1,
    "companyName": "Aspect"
  },
  {
    "id": 2,
    "companyName": "Samsung"
  },
  {
    "id": 3,
    "companyName": "Lidl"
  },
  {
    "id": 4,
    "companyName": "string2"
  },
  {
    "id": 5,
    "companyName": "string"
  },
  {
    "id": 6,
    "companyName": "string2"
  }
]

#### 2. GetBuId
#### Request: GET /api/Company/1
### Response (200 OK):{
  "id": 1,
  "companyName": "Aspect"
}
### Response (404 Not Found):{
Company with 21 was not found
}

 #### 3.CreateCompany
 #### Request: {
  "companyName": "Aspect"
}
 ### Response (201):{
Created company
}
### Response(400 Bad Request){Validation failed: -- CompanyName: Company name is required. Severity: Error}

 #### 4.UpdateCompany
 #### Request: {
  "id": 1,
  "companyName": "string"
}

 ### Response (201):{
Created company
}
### Response(400 Bad Request){Validation failed: -- CompanyName: Company name is required. Severity: Error}



