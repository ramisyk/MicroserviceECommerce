
# ECommerce With Microservice

This repo is being developed within the scope of training in order to understand the fundamentals of microservice architecture and to improve the perspective. 

## Services & Technologies

### Catalog
This service carries out the operations for product management.

**Entities:**
- Category
- Product
- Product Detail
- Product Image

**Architecture:** Single-tier web API project (for now)

**Database:** MongoDb

**Mapper:** AutoMapper

### Discount
This service carries out the operations for discount coupons management.

**Entities:**
- Coupon

**Architecture:** Single-tier web API project (for now)

**Database:** MS SQL Server

**ORM:** Dapper

### Order
This service carries out the operations for order management.

**Entities:**
- Address
- OrderDetail
- Ordering

**Architecture:** Onion Architecture

**Patterns:** Repository, CQRS, Mediator

Address and OrderDetail manages with CQRS pattern without Mediator. 

Ordering entity manages with CQRS pattern with Mediator.

**Layers:**
- Domain
- Application
- Persistence
- Presentation (WebAPI)

**Database:** MS SQL Server

**ORM:** Entity Framework Core

### Identity Server
This service carries out the operations for all identity and user management.

**Entities:**
- ApplicationUser

**Architecture:** Single-tier web API project (for now)

**Database:** MS SQL Server

**Identity Management:** ASP.NET Core Identity and Identity Server 4 is used together. Identity Server 4 is used for now but it will be migrated to Duende Identity Server in the future.


### Cargo
This service carries out the operations for cargo management.

**Entities:**
- CargoDetail
- CargoOperation
- CargoCompany
- CargoCustomer

**Architecture:** N-Tier Application

**Patterns:** Repository Design Pattern

**Layers:**
- EntityLayer
- BusinessLayer
- DataAccessLayer
- DtoLayer
- PresentationLayer (WebAPI)

**Database:** MS SQL Server

**ORM:** Entity Framework Core

### Basket
This service carries out the operations for basket management.

**Dtos:**
- BasketItemDto
- BasketTotalDto

**Architecture:** Single-tier web API project (for now)

**Database:** Redis