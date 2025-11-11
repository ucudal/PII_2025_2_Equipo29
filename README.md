
# Proyecto Final Programación 2 (CRM)

Estudiantes: Beretta, Renzo. Diaz, Joaquin. Silva, Ignacio

Universidad Católica

Asignatura: Programación 2

Docente: Jorge Martínez


## Entrega 1
En la primer entrega, no realizamos tarjetas crc y saltamos directo al uml. A las malas nos dimos cuenta que son una herramienta muy útil para no saltearse aspectos importantes del programa

## Entrega 2
Para esta entrega, decidimos realizar un rework de todo el proyecto. Desde la creación de las tarjetas crc, adaptación de nuestro primer UML hasta llegar a la fachada y posterior implementación de las historias de usuario.

### Tarjetas CRC

Fijandonos en las historias de usuario, creamos un total de 19 tarjetas CRC, en el siguiente link se pueden verlas. 
https://drive.google.com/file/d/1HgPTBo7R0nbqg5wY4_O6P7QR8r6Q9BZw/view?usp=sharing

### UML
La primera versión de nuestro UML era [esta](https://drive.google.com/file/d/18jnsAp_aIeipy-V0-e6ILUxsPYaJEkLY/view?usp=drive_link). Era un sistema inconexo en donde el sistema estaba por partes. Ahora nuestro uml es el siguiente: 
https://drive.google.com/file/d/1E5TTA1M9lbhbToEqYyp3kpdIJIr12PXt/view?usp=sharing

En cuanto a las relaciones, podemos realizar un resumen de lo que se puede apreciar en el uml: 

```txt
Cliente ◇─ Interaccion (agragación)
Cliente ◇─ Etiqueta (agregación)
Vendedor ◇─ Cliente (agregación)
Interaccion ◇─  Notas (agregación)
SistemaCRM ◆─ Repositorios (composición)
Repositorios ◇─ Entidades (agregación)
Cotizaciones ---▷ Venta (dependencia)
```

#### Patrones aplicados
1. Expert: Por ejemplo, en RepoClientes, es esta clase la que se encarga de buscar clientes según x filtro, ya que es ella misma la que tiene una lista con los clientes y es la más adecuada para poder realizar esta tarea.
2. SRP: En todas las clases se manteiene una única responsabilidad.
3. Creator: Una clase es creadora de otra, por ejemplo. En nuestro UML Vendedor se encarga de crear clientes y Administrador se encarga de crear usuarios (Vendedores y administradores). También cabe aclarar que no supimos representar creator en el UML. 
4. Composición: El SistemaCRM está compuesto por los repositorios.
5. Agregación: Un ejemplo claro es que puedo agregar etiquetas al cliente.
6. Dependencia: Las ventas depende de antes haber enviado una cotización.

#### Clases
* Persona {Abstracta}
    * Usuario {Abstracta}
        * Vendedor
        * Administrador
    * Cliente 
* Interacción 
    * Mail
    * Mensaje
    * Cotización
    * Venta
    * Reuniones 
    * Llamada 
* Nota
* Etiqueta
* Repositorio {Abstracta}
    * repoClientes
    * repoAdministradores
    * repoVendedores

Una de las partes de nuestra solución es el haber creado estos "repositorios" ya que al no tener una base de datos a la cual consultar, decidimos generar clases que almacenen todos estos usuarios y clientes que se generarán.

### Fachada
Luego de terminar la parte de diseño, nos dedicamos a realizar commits en la fachada, eso lo hicimos en el main directamente. 

### Implementar historias de usuario
Una vez la fachada estaba actualizada, nos dividimos las historias de usuario y empezamos a realizar sus respectivas implementaciones que de antemano ya se ven reflejadas en el uml. 
Para trabajar de manera mas ordenada decidimos dividir en branchs diferentes nuestro trabajo y una vez pusheado cada una de las historias de usuario, mergear con el main.
