<h1 align="center">CoderHouse Final Project</h1>

Coderhouse's final project is about creating an API which allows user registration and logging, in addition to the sale of different products.

## :hammer:Functionalities

- `Login`: The user name and password are passed as parameters, search the database if the user exists and if it matches the password it returns it.
- `CreateUser`: Receives a User-type json and must immediately register the user in the database
- `ModifyUser`: All user data will be received by a json and it must be modified with the new data.
- `GetUser`:  It must receive a user's name in the URL, look it up in the database and return a User object.
- `DeleteUser`: Receives the ID of the user to delete in the URL and must delete it from the database.
- `CreateProduct`: Receives a Product object in the request body and creates a new user in the database.
- `ModifyProduct`: Receives a Product object in the request body and must be modified in the database.
- `DeleteProduct`:Receives the Id number of a product to delete as a URL parameter and must delete it from the database.
- `LoadSale`: Receives a list of products and the UserID number of the person who made it, first load a new sale in the database, then load the received products in the ProductSold base one by one on one side, and discount the stock in the product base on the other.
- `GetProducts`: Brings all the products loaded into the base by a User. The userid comes as a parameter of the URL.
- `GetSoldProducts`: Brings all the products sold by a User. Returns a List of SoldProduct objects.
- `GetSales`: Brings all the sales of the base that a User has made. It receives the User id as a URL parameter and returns a list of Sale objects.

## :wrench:Configuration and execution

To start the server, you have to run the file `final_project.csproj`.

Inside the resources folder, there is a file called `script.sql` that contains the database structure. We must run it in our database manager to create the database and its tables, and thus be able to perform the queries.

Keep in mind that we must create the `DATABASE_CONNECTION_STRING` environment variable with the connection string to be able to establish the connection to the database.