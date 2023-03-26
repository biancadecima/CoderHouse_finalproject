# CoderHouse FINAL PROJECT
------------------------------------ ENG ------------------------------------

STATEMENT CODERHOUSE FINAL PROJECT:

Create an API that follows the instructions below:

Login: The user name and password are passed as parameters, search the database if the user exists and if it matches the password it returns it.
Create User: Receives a User-type json and must immediately register the user in the database (Optional to validate that the same username is not repeated)
Modify User: All user data will be received by a json and it must be modified with the new data (Do not create a new one).
Get User: It must receive a user's name in the URL, look it up in the database and return a User object.
Delete User: Receives the ID of the user to delete in the URL and must delete it from the database.
Create Product: Receives a Product object in the request body and creates a new user in the database.
Modify Product: Receives a Product object in the request body and must be modified in the database.
Delete Product: Receives the Id number of a product to delete as a URL parameter and must delete it from the database.
Load Sale: Receives a list of products and the UserID number of the person who made it, first load a new sale in the database, then load the received products in the ProductSold base one by one on one side, and discount the stock in the product base on the other.
Bring Products: You must bring all the products loaded into the base by a User. The userid comes as a parameter of the URL.
Bring Sold Products: Bring all the products sold by a User. Returns a List of SoldProduct objects.
Bring Sales: You must bring all the sales of the base that a User has made. It receives the User id as a URL parameter and returns a list of Sale objects.

------------------------------------ ESP ------------------------------------

CONSIGNA PROYECTO FINAL CODERHOUSE:

Crear una API que siga las siguientes instrucciones:

Inicio de sesión: Se le pasa como parámetro el nombre del usuario y la contraseña, buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve.
Crear Usuario: Recibe un json tipo Usuario y debe dar un alta inmediata del usuario en la base de datos (Opcional validar que no se repita el mismo nombre de usuario)
Modificar Usuario: Se recibirán todos los datos del usuario por un json y se deberá modificar el mismo con los datos nuevos (No crear uno nuevo).
Traer Usuario: Debe recibir un nombre del usuario en la URL, se debe buscarlo en la base de datos y devolver un objeto Usuario.
Eliminar Usuario: Recibe el ID del usuario a eliminar en la URL y lo deberá eliminar de la base de datos.
Crear Producto: Recibe un objeto Producto en el cuerpo de la solicitud y crea un nuevo usuario en la base de datos.
Modificar Producto: Recibe un objeto Producto en el cuerpo de la solicitud y se lo debe modificar en la base de datos.
Eliminar Producto: Recibe el número de Id de un producto a eliminar como parámetro URL y debe eliminarlo de la base de datos.
Cargar Venta: Recibe una lista de productos y el número de IdUsuario de quien la efectuó, primero cargar una nueva venta en la base de datos, luego debe cargar los productos recibidos en la base de ProductosVendidos uno por uno por un lado, y descontar el stock en la base de productos por el otro.
Traer Productos: Debe traer todos los productos cargados en la base por un Usuario. El idUsuario viene como parámetro de la URL.
Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario. Devuelve un Lista de objetos ProductoVendido.
Traer Ventas: Debe traer todas las ventas de la base que ha efectuado un Usuario. Recibe como parámetro URL el id de Usuario y devuleve una lista de objetos Venta.
