**Documentación del Proyecto "Cert"**

**Introducción**

Este documento proporciona instrucciones para configurar, ejecutar y probar el proyecto "Cert". El proyecto está estructurado en varias capas y utiliza Entity Framework Core para la interacción con la base de datos.

**Requisitos Previos**

Antes de comenzar, asegúrese de tener instalados los siguientes componentes en su entorno de desarrollo:

- .NET 8 SDK
- PostgreSQL
- Visual Studio Code o Visual Studio
- Git

**Configuración del Proyecto**

1. **Clonar el Repositorio:**

Clonar el repositorio utilizando Git

**Restaurar Paquetes NuGet:**

Desde la raíz del proyecto, ejecute:

dotnet restore

1. **Compilar el Proyecto:**

Compile la solución con:

dotnet build

**Ejecutar el Proyecto**

Para iniciar la API, navegue al directorio del proyecto CertApi y ejecute:

dotnet run

La API estará disponible en http://localhost:5000.

**Configuración de la Base de Datos**

Antes de ejecutar el proyecto, asegúrese de que las tablas de la base de datos estén configuradas. Use el siguiente script SQL para crear las tablas en PostgreSQL:

El archivo que esta en la carpeta Script

Ejecute este script en su base de datos PostgreSQL.

**Ejecución de Pruebas**

Para ejecutar las pruebas, navegue al directorio Cert.Test y ejecute:

dotnet test

**Cambio de la Cadena de Conexión**

Para cambiar la cadena de conexión a la base de datos:

1. Abra el archivo appsettings.json o appsettings.Development.json en el proyecto CertApi.
1. Modifique el valor DefaultConnection en la sección ConnectionStrings.

Ejemplo:

"ConnectionStrings": {

`  `"Connection": "Host=localhost;Database=Cert;Username=usuario;Password=contraseña"

}

**Instrucciones para Ejecutar el Script de Base de Datos**

Ejecute el script SQL en su cliente de base de datos PostgreSQL para crear las tablas necesarias.

