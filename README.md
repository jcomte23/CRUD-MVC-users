# Proyecto CRUD de Usuarios con .NET y Razor Pages

Este proyecto es una aplicación web sencilla que implementa un CRUD de usuarios utilizando .NET con Razor Pages y MySQL como base de datos.

## Características
- **Framework:** ASP.NET con Razor Pages
- **Base de datos:** MySQL
- **Alertas:** Implementación de notificaciones con Toast
- **Buenas prácticas:** Código organizado y estructurado

## Requisitos previos
Asegúrate de tener instalado lo siguiente en tu entorno de desarrollo:
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [MySQL Server](https://www.mysql.com/downloads/)
- [Visual Studio](https://visualstudio.microsoft.com/) o cualquier IDE compatible

## Configuración del Proyecto
1. **Clonar el repositorio**
   ```sh
   git clone https://github.com/jcomte23/CRUD-MVC-users.git
   cd CRUD-MVC-users
   ```
2. **Configurar la conexión a MySQL**
   Copia el archivo `.envexample` y renómbralo a `.env`, luego edítalo con los datos de tu base de datos:
   ```sh
   cp .envexample .env
   ```
   Rellena las variables necesarias en el archivo `.env` con la configuración de la base de datos.
3. **Aplicar las migraciones (si se usa Entity Framework Core)**
   ```sh
   dotnet ef database update
   ```
4. **Ejecutar el proyecto**
   ```sh
   dotnet run
   ```

## Uso de la Aplicación
- **Crear usuarios**: Ingresa los datos y presiona el botón "Registrar".
- **Listar usuarios**: Se muestra una tabla con los usuarios registrados.
- **Editar usuarios**: Opción para modificar los datos de un usuario existente.
- **Eliminar usuarios**: Opción para eliminar un usuario de la base de datos.

## Librerías y Tecnologías Usadas
- ASP.NET Core Razor Pages
- MySQL
- Entity Framework Core (si aplica)
- Bootstrap para diseño
- Toast Notifications para alertas

## Contribuciones
Si deseas contribuir a este proyecto, por favor realiza un **fork**, crea una nueva rama y envía un **pull request**.

## Autor
[Javier Cómbita Téllez](https://jcomte23.github.io)

## Licencia
Este proyecto está bajo la licencia [MIT](LICENSE).
