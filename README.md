# TableBookingSystem
## Overview
The Table Booking System is a RESTful API designed to manage restaurant operations, including customer management, menu management, and table reservations. This system allows restaurants to efficiently handle their booking and customer management needs. Still work in progress and is subject to change.

## Features
Customer Management: Create, update, view, and delete customer information.
Menu Management: Manage menu items including adding, updating, and retrieving details about available dishes.
Reservation Management: Handle table reservations, including checking availability, booking tables, and managing existing reservations.

The application uses an appsettings.json file for configuration. Ensure that you have set up your database connection strings and other settings correctly.

## API Endpoints
### Customer Endpoints
GET /api/customers
Retrieves a list of all customers.

GET /api/customers/{id}
Retrieves details of a specific customer by ID.

POST /api/customers
Adds a new customer.

PUT /api/customers/{id}
Updates an existing customer by ID.

DELETE /api/customers/{id}
Deletes a customer by ID.

### Menu Endpoints
GET /api/menu
Retrieves a list of all menu items.

GET /api/menu/{id}
Retrieves details of a specific menu item by ID.

POST /api/menu
Adds a new menu item.

PUT /api/menu/{id}
Updates an existing menu item by ID.

DELETE /api/menu/{id}
Deletes a menu item by ID.

### Reservation Endpoints
GET /api/reservations
Retrieves a list of all reservations.

GET /api/reservations/{id}
Retrieves details of a specific reservation by ID.

POST /api/reservations
Creates a new reservation.

PUT /api/reservations/{id}
Updates an existing reservation by ID.

DELETE /api/reservations/{id}
Cancels a reservation by ID.

## Technologies Used
.NET 8.0
ASP.NET Core
Entity Framework Core
AutoMapper
SQL Server/MySQL
Contributing
Contributions are welcome! Please feel free to submit a Pull Request or open an issue.

