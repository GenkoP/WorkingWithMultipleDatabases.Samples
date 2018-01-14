# Store same data in multiple databases

### The case which this project solve
 - to store same data in multiple databases when we use GUID as Primary key in tables
 - to extend currently working business logic without to change any code in it

### The goal of this project is to show
 - how powerful is dependency injection
 - how to use adapter and composite patterns
 - how easy is to extend and to maintain currently working business logic

### Databases are divided by 3 categories
 - SQL databases: MS SQL, SQLite
 - SQL In memory database: Apache Ignite
 - NoSQL databases: MongoDB
  
### Used libraries
 - Simple Injector v4.0.12 for dependency injection - https://simpleinjector.readthedocs.io/en/latest/index.html
 - Entity Framework v6.2.0 for data manipulation in MS SQL Server - https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx
 - Dappper v1.50.4 for data manipulation in SQLite - http://dapper-tutorial.net/dapper
 - Apache.Ignite v2.3.0 for distributed in-memory database - https://apacheignite-net.readme.io/docs/
 - MongoDB.Driver v2.5.0 for for data manipulation in MongoDB - https://docs.mongodb.com/ecosystem/drivers/csharp/
