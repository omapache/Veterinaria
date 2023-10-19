# veterinaria

Este proyecto proporciona una API que permite gestionar todo el apartado de la administración de una veterinaria y gestion de los usuarios.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.
- Para cada controlador GET una version con paginacion y otra sin paginacion.

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

primero que todo, en los csv esta el administrador con el usuario:admin y la contraseña : 123
del cual nesecitaremos el token para el registro de usuarios ya que solo el administrador podra hacer todo con respecto al crud de los usuarios:

## POST de las entidades

**Citas**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/cita`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
            "IdMascotaFk":1,
            "Fecha":"2023-10-24",
            "Hora":"2023-10-24",
            "Motivo":"Vacunacion",
            "IdVeterinarioFk":1
      }  
      
**Detalle Movimiento**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/DetalleMovimiento`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
        "id": 4,
        "idMedicamentoFk": 1,
        "medicamento": null,
        "cantidad": 100,
        "idMovimientoMedicamentoFk": 1,
        "movimientoMedicamento": null,
        "precio": 144
      }
      
**Especie**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/especie`
       
       **Método**: `POST`
       
       **Payload**:
       
      {
        "Nombre":"Ave"
      }  
      
**Laboratorio**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/laboratorio`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
        "Nombre":"Ave",
        "Direccion":"Esmeralda",
        "Telefono":"321654"
      }  

**Mascota**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/mascota`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
        "IdPropietarioFk":1,
        "IdEspecieFk":1,
        "IdRazaFk":2,
        "Nombre":"pepito",
        "FechaNacimiento":"2023-01-12"
      }
      

      
**Medicamento**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/medicamento`
       
       **Método**: `POST`
       
       **Payload**:
       
      {
        "Nombre":"pepito",
        "CantidadDisponible":1,
        "Precio":2,
        "IdLaboratorioFk":2
      }
      

**MovimientoMedicamento**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/movimientoMedicamento`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Cantidad":1,
        "Fecha":"2023-07-12",
        "IdTipoMovimientoFk":2
      }


**Propietario**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/propietario`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Nombre":"Silvia",
        "Email":"correo@gmail.com",
        "Telefono":"123456"
      }


**Proveedor**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/proveedor`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Nombre":"Silvia",
        "Direccion":"Cabecera",
        "Telefono":"123456"
      }


**Raza**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/raza`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "IdEspecieFk":1,
        "Nombre":"Husky"
      }  


**Rol**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/rol`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Nombre":"Cliente"
      }     


**TratamientoMedico**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/tratamientoMedico`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "IdCitaFk":1,
        "IdMedicamentoFk": 3,
        "Dosis": 12,
        "FechaAdministracion": "2023-04-05",
        "Observacion": "Limitación"
      }    


**TipoMovimiento**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/tipoMovimiento`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "Descripcion": "Entrada"
      }    


**Veterinario**  

       **Endpoint**: `http://localhost:5165/api/veterinaria/veterinario`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "Nombre":"Owen",
        "Email":"correo@gmail.com",
        "Telefono":"123456",
        "Especialidad": "Cirujano"
      }          


## 1. Generación del token:

       **Endpoint**: `http://localhost:5165/api/veterinaria/token`
       
       **Método**: `POST`
       
       **Payload**:
       
       `{
           "Nombre": "<nombre_de_usuario>",
           "password": "<password>"
       }`
una vez que tenemos el token del administrador, ya podremos hacer el registro de usuario ingresandolo en el auth:
## 2. Registro de Usuarios

      **Endpoint**: `http://localhost:5165/api/veterinaria/register`
      
      **Método**: `POST`
      
      **Payload**:
      
      json
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>",
          "Email": "<Email>"
      }`

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token para poder ingresar a los demas controladores.

## 3. Refresh Token:

      **Endpoint**: `http://localhost:5165/api/veterinaria/refresh-token`
      
      **Método**: `POST`
      
      **Payload**:
      
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>"
      }`

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

      **Otros Endpoints**
      recordar que para todos los endpoints tenemos que tener el token de rol de administrador
      
      Obtener Todos los Usuarios: GET `http://localhost:5165/api/veterinaria/usuario`
      
      Obtener Usuario por ID: GET `http://localhost:5165/api/veterinaria/usuario/{id}`
      
      Actualizar Usuario: PUT `http://localhost:5165/api/veterinaria/usuario/{id}`
      
      Eliminar Usuario: DELETE `http://localhost:5165/api/veterinaria/usuario/{id}`
      

## Desarrollo de los Endpoints requeridos⌨️

Cada Endpoint tiene su versión 1.0 y 1.1, al igual que están con y sin paginación.

Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)


## 1. Visualizar los veterinarios cuya especialidad sea Cirujano vascular:

      **Endpoint**: `http://localhost:5165/api/veterinaria/veterinario/consulta1A`
      
      **Método**: `GET`


## 2. Listar los medicamentos que pertenezcan a el laboratorio Genfar:
      
      **Endpoint**: `http://localhost:5165/api/veterinaria/laboratorio/consulta2A`
      
      **Método**: `GET`


## 3. Mostrar las mascotas que se encuentren registradas cuya especie sea felina:

      **Endpoint**: `http://localhost:5165/api/veterinaria/mascota/consulta3A`
      
      **Método**: `GET`


## 4. Listar los propietarios y sus mascotas:

      **Endpoint**: `http://localhost:5165/api/veterinaria/propietario/consulta4A`
      
      **Método**: `GET`


## 5. Listar los medicamentos que tenga un precio de venta mayor a 50000:

      **Endpoint**: `http://localhost:5165/api/veterinaria/medicamento/consulta5A`
      
      **Método**: `GET`


## 6. Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023:

      **Endpoint**: `http://localhost:5165/api/veterinaria/mascota/consulta6A`
      
      **Método**: `GET`


## 7. Listar todas las mascotas agrupadas por especie:

      **Endpoint**: `http://localhost:5165/api/veterinaria/mascota/consulta1B`
      
      **Método**: `GET`


## 8. Listar todos los movimientos de medicamentos y el valor total de cada movimiento:

      **Endpoint**: `http://localhost:5165/api/veterinaria/movimientoMedicamento/consulta2B`
      
      **Método**: `GET`


## 9. Listar las mascotas que fueron atendidas por un determinado veterinario:

      **Endpoint**: `http://localhost:5165/api/veterinaria/mascota/consulta3B`
      
      **Método**: `GET`

## 10. Listar los proveedores que me venden un determinado medicamento:

      **Endpoint**: `http://localhost:5165/api/veterinaria/proveedor/consulta4B`
      
      **Método**: `GET`

## 11. Listar las mascotas y sus propietarios cuya raza sea Golden Retriver:

      **Endpoint**: `http://localhost:5165/api/veterinaria/propietario/consulta5B`
      
      **Método**: `GET`

## 12. Listar la cantidad de mascotas que pertenecen a una raza:

      **Endpoint**: `http://localhost:5165/api/veterinaria/mascota/consulta6B`
      
      **Método**: `GET`

## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Entity Framework Core para la ORM.
Patrón Repository y Unit of Work para la gestión de datos.
AutoMapper para el mapeo entre entidades y DTOs.

## Agradecimientos 🎁

A todas las librerías y herramientas utilizadas en este proyecto.

A ti, por considerar el uso de este sistema.

por Owen 🦝
![image](https://github.com/omapache/Veterinaria/assets/133465475/8ff4353b-89ed-4efa-9ae6-0b56f165343e)
