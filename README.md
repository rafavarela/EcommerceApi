# Senior Full-Stack Developer Exercise

## Overview
This exercise evaluates your ability to build a full-stack application with a .NET backend API and Angular frontend.

## Project Structure
- `/Backend` - .NET Web API
- `/Frontend` - Angular application

## Prerequisites
- .NET 8.0 SDK or later
- Node.js 18.x or later
- Angular CLI

## Setup Instructions

### Backend (.NET API)
```bash
cd backend/ProductAPI
dotnet restore
dotnet run
```
The API will run on `http://localhost:5xxx` (check console output)

### Frontend (Angular)
```bash
cd frontend/productUI
npm install
ng serve
```
The app will run on `http://localhost:4200`

---------------------------------------
Overview
Implement a simple Product Listing Feature for an e-commerce platform.
Two phases: Phase 1 — Backend and Phase 2 — Frontend.
Include unit tests for both backend service logic and frontend data retrieval.
You are encouraged to use an AI assistant.

Phase 1: Backend (API and Data Access) - 30 min
Use Entity Framework Core with the In-Memory or local Database Provider (transient store) to represent your data store.
Define a Product entity with the following properties

Id — int (Primary Key)
Name — nvarchar(255)
Description — nvarchar(max)
Price — decimal(10,2)
StockQuantity — int
IsActive — bool / bit


Implement Database Seeding to ensure at least 5 sample Products are created and available every time the application starts (since the in-memory or local database is transient)
Create an endpoint (GET /api/products) that retrieves all active products from the Products table.
Endpoint: GET /api/products
Behavior: retrieve all active products (IsActive == true).
DTO / Mapping
Create a Product DTO (e.g., ProductDto) with the fields to return.
Use AutoMapper to map Product → ProductDto.
Write a basic xUnit unit test to ensure the API's service layer correctly filters for IsActive = true products.
Test the backend service layer (not necessarily the controller) to assert that:
Only products with IsActive = true are returned.
Mock or use the EF In-Memory provider for the test.