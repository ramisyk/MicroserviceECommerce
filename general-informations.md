**Used Ports:**

The application uses the following ports:

| Port | Service								|
|------|----------------------------------------|
| 5000 | API Gateway							|
| 5001 | Identity Server						|
| 7070 | Catalog Service						|
| 7071 | Discount Service						|
| 7072 | Order Service							|
| 7073 | Cargo Service							|
| 7074 | Basket Service							|
| 7075 | Comment Service						|
| 1435 | Catalog Database (MS SQL Server)       |
| 1436 | Identity Database (MS SQL Server)      |
| 1437 | Cargo Database (MS SQL Server)         |
| 1438 | Comment Database (MS SQL Server)       |
| 27017| Catalog Database (MongoDB)             |
| 6379 | Basket Database (Redis)                |

**Docker Commands:**

For create and run the required databases, use the following Docker commands:

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa1234.!aA" -e "MSSQL_PID=Developer" -e "MSSQL_COLLATION=Turkish_100_CI_AS" -p 1435:1433 -v mssql_data:/var/opt/mssql -d --name mssql-dev mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa1234.!aA" -e "MSSQL_PID=Developer" -e "MSSQL_COLLATION=Turkish_100_CI_AS" -p 1436:1433 -v identity_data:/var/opt/mssql -d --name identity-db mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa1234.!aA" -e "MSSQL_PID=Developer" -e "MSSQL_COLLATION=Turkish_100_CI_AS" -p 1437:1433 -v cargo_data:/var/opt/mssql -d --name cargo-db mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa1234.!aA" -e "MSSQL_PID=Developer" -e "MSSQL_COLLATION=Turkish_100_CI_AS" -p 1438:1433 -v comment_data:/var/opt/mssql -d --name comment-db mcr.microsoft.com/mssql/server:2022-latest

docker run -d --name basket_db -p 6379:6379 redis:latest
