# Entrega Final
Estudiantes: 
* **Renzo Beretta**
* **Joaquín Díaz**
* **Ignacio Silva**

Universidad Católica

Asignatura: Programación II

Docente: Jorge Martínez

Fecha: 1 de diciembre de 2025

# PII 2025-2 - Equipo 29: [Kbr4 - Tu CRM de confianza]

Hemos aplicado diversos Patrones de Diseño clave a lo largo del sistema:

* **GoF Command:** Utilizado en el módulo de comandos (`Program/Handler.cs`, `ICommand.cs` y clases concretas) para encapsular cada solicitud como un objeto, permitiendo la inyección y el despacho de comandos de manera desacoplada.
* **GoF Singleton:** Implementado en los repositorios específicos (`RepoAdmin.cs`, `RepoVendedor.cs`) para asegurar una única instancia de la colección de datos en memoria.
* **Fachada (Facade):** La clase `Library/Core/Interfaz.cs` actúa como una fachada, centralizando el acceso a los casos de uso del dominio y ocultando la complejidad de las capas de persistencia (repositorios).

### Principios de Programación (SOLID y GRASP)
El código sigue las siguientes directrices de diseño:

| Principio/Concepto | Aplicación Clave |
| :--- | :--- |
| **SRP** (Single Responsibility) | `Program/Bot.cs` (solo gestión de conexión); clases `*Command.cs` (una acción por clase); repositorios (una clase por agregado). |
| **OCP** (Open/Closed) | El `Handler.cs` y `ICommand.cs` permiten agregar nuevos comandos sin modificar el código de despacho. |
| **DIP** (Dependency Inversion) | Las clases de dominio (ej: comandos) dependen de abstracciones (`Interfaz`) en lugar de implementaciones concretas. |
| **ISP** (Interface Segregation) | Interfaz `IRespondible.cs` para interacciones que requieren respuesta. |
| **GRASP Controller** | `Program/Bot.cs` y `Program/Handler.cs` son puntos de entrada que delegan la lógica a las capas inferiores; `Interfaz.cs` actúa como un controlador de dominio. |
| **GRASP Expert** | Clases de modelos (ej: `Vendedor.cs`) y repositorios (ej: `RepoVendedor.cs`) contienen la información y lógica asociadas a su propia responsabilidad. |

---

##  Puesta en Marcha

Para iniciar el bot y el sistema, sigue los pasos de instalación y ejecución.

### Uso del Bot y Comandos
Para una guía completa sobre cómo interactuar con el bot y los comandos disponibles (ej: `Kbr4 crearCliente`, `Kbr4 registrarLlamada`), consulta la documentación específica:

### Cheat Sheet de comando [Aquí](comandos.md)

