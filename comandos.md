# Comandos Kbr4

En los comandos:
- `<...>` indica un parámetro **obligatorio**.  
- `[...]` indica un parámetro **opcional**.

---

### Kbr4 agregarEtiqueta

- **Uso genérico:**  
  `Kbr4 agregarEtiqueta <idCliente> <nombreEtiqueta> [color] [descripcion]`

- **Ejemplo:**  
  `Kbr4 agregarEtiqueta 1 VIP rojo "Cliente con alto volumen de compras"`

---

### Kbr4 asignarCliente

- **Uso genérico:**  
  `Kbr4 asignarCliente <idCliente> <idVendedorDestino>`

- **Ejemplo:**  
  `Kbr4 asignarCliente 3 2`

---

### Kbr4 buscarClientes

- **Uso genérico:**  
  `Kbr4 buscarClientes <criterio>`

- **Ejemplo:**  
  `Kbr4 buscarClientes "García"`

---

### Kbr4 buscarPorEtiqueta

- **Uso genérico:**  
  `Kbr4 buscarPorEtiqueta <nombreEtiqueta>`

- **Ejemplo:**  
  `Kbr4 buscarPorEtiqueta VIP`

---

### Kbr4 clientesSinInteraccion

- **Uso genérico:**  
  `Kbr4 clientesSinInteraccion [dias]`

- **Ejemplo:** (clientes sin interacción en los últimos 30 días)  
  `Kbr4 clientesSinInteraccion 30`

---

### Kbr4 crearAdmin

- **Uso genérico:**  
  `Kbr4 crearAdmin <nombre> <apellido> <mail> <telefono> <nombreUsuario> <password>`

- **Ejemplo:**  
  `Kbr4 crearAdmin Ana López ana.lopez@ejemplo.com 099123456 analopez Secreta123`

---

### Kbr4 crearCliente

- **Uso genérico:**  
  `Kbr4 crearCliente <nombre> <apellido> <mail> <telefono>`

- **Ejemplo:**  
  `Kbr4 crearCliente Juan Pérez juan.perez@ejemplo.com 098765432`

---

### Kbr4 crearEtiqueta

- **Uso genérico:**  
  `Kbr4 crearEtiqueta <nombre> [color] [descripcion]`

- **Ejemplo:**  
  `Kbr4 crearEtiqueta Prioritario amarillo "Responder en menos de 24 horas"`

---

### Kbr4 crearVendedor

- **Uso genérico:**  
  `Kbr4 crearVendedor <nombre> <apellido> <mail> <telefono> <nombreUsuario> <password>`

- **Ejemplo:**  
  `Kbr4 crearVendedor Lucas Díaz lucas.diaz@ejemplo.com 091234567 lucasdiaz Ventas2025`

---

### Kbr4 dashboard

- **Uso genérico:**  
  `Kbr4 dashboard [diasInteracciones] [cantidadInteracciones]`

- **Ejemplo:** (dashboard de los últimos 7 días, mostrando 20 interacciones)  
  `Kbr4 dashboard 7 20`

---

### Kbr4 contactosPendientes

- **Uso genérico:**  
  `Kbr4 contactosPendientes [dias]`

- **Ejemplo:** (contactos pendientes en los últimos 14 días)  
  `Kbr4 contactosPendientes 14`

---

### Kbr4 eliminarCliente

- **Uso genérico:**  
  `Kbr4 eliminarCliente <id>`

- **Ejemplo:**  
  `Kbr4 eliminarCliente 5`

---

### Kbr4 eliminarUsuario

- **Uso genérico:**  
  `Kbr4 eliminarUsuario <id>`

- **Ejemplo:**  
  `Kbr4 eliminarUsuario 3`

---

### Kbr4 listarEtiquetas

- **Uso genérico:**  
  `Kbr4 listarEtiquetas`

- **Ejemplo:**  
  `Kbr4 listarEtiquetas`

---

### Kbr4 listarVendedores

- **Uso genérico:**  
  `Kbr4 listarVendedores`

- **Ejemplo:**  
  `Kbr4 listarVendedores`

---

### Kbr4 login

- **Uso genérico:**  
  `Kbr4 login <usuario> <contraseña>`

- **Ejemplo:**  
  `Kbr4 login analopez Secreta123`

---

### Kbr4 logout

- **Uso genérico:**  
  `Kbr4 logout`

- **Ejemplo:**  
  `Kbr4 logout`

---

### Kbr4 modificarCliente

- **Uso genérico:**  
  `Kbr4 modificarCliente <id> <campo> <nuevoValor>`

- **Ejemplo:** (cambiar el teléfono del cliente 4)  
  `Kbr4 modificarCliente 4 telefono 092000111`

---

### Kbr4 mostrarMisClientes

- **Uso genérico:**  
  `Kbr4 mostrarMisClientes`

- **Ejemplo:**  
  `Kbr4 mostrarMisClientes`

---

### Kbr4 registrarCotizacion

- **Uso genérico:**  
  `Kbr4 registrarCotizacion <idCliente> <monto> <descripcion...>`

- **Ejemplo:**  
  `Kbr4 registrarCotizacion 2 1500 "Cotización de paquete de servicios premium"`

---

### Kbr4 registrarDatosExtra

- **Uso genérico:**  
  `Kbr4 registrarDatosExtra <idCliente> <genero> <fechaNacimiento:dd/MM/yyyy>`

- **Ejemplo:**  
  `Kbr4 registrarDatosExtra 2 masculino 15/08/1990`

---

### Kbr4 registrarLlamada

- **Uso genérico:**  
  `Kbr4 registrarLlamada <idCliente> <entrante/saliente> <duracionSeg> <si/no> <descripcion...>`

- **Ejemplo:**  
  `Kbr4 registrarLlamada 1 entrante 180 si "Consulta sobre precios del servicio"`

---

### Kbr4 registrarMail

- **Uso genérico:**  
  `Kbr4 registrarMail <idCliente> <entrante/saliente> <asunto> <destinatarios> <descripcion>`

- **Ejemplo:**  
  `Kbr4 registrarMail 3 saliente "Propuesta comercial" cliente@empresa.com "Envío de propuesta detallada"`

---

### Kbr4 registrarMensaje

- **Uso genérico:**  
  `Kbr4 registrarMensaje <idCliente> <entrante/saliente> <asunto> <destinatarios> <descripcion>`

- **Ejemplo:**  
  `Kbr4 registrarMensaje 3 entrante "Consulta por WhatsApp" +59899111222 "Cliente pregunta por métodos de pago"`

---

### Kbr4 registrarReunion

- **Uso genérico:**  
  `Kbr4 registrarReunion <idCliente> <fecha:dd/MM/yyyy-HH:mm> <duracionMin> <ubicacion> <descripcion>`

- **Ejemplo:**  
  `Kbr4 registrarReunion 2 10/12/2025-15:30 60 "Oficina central" "Reunión para cierre de contrato"`

---

### Kbr4 registrarVenta

- **Uso genérico:**  
  `Kbr4 registrarVenta <idCliente> <idCotizacion> <producto>`

- **Ejemplo:**  
  `Kbr4 registrarVenta 2 5 "Plan Empresarial Anual"`

---

### Kbr4 suspenderUsuario

- **Uso genérico:**  
  `Kbr4 suspenderUsuario <id>`

- **Ejemplo:**  
  `Kbr4 suspenderUsuario 4`

---

### Kbr4 totalVentas

- **Uso genérico:**  
  `Kbr4 totalVentas <fechaDesde:dd/MM/yyyy> <fechaHasta:dd/MM/yyyy>`

- **Ejemplo:**  
  `Kbr4 totalVentas 01/11/2025 30/11/2025`

---

### Kbr4 verInteracciones

- **Uso genérico:**  
  `Kbr4 verInteracciones <idCliente> [tipo] [fechaDesde:dd/MM/yyyy] [fechaHasta:dd/MM/yyyy]`

- **Ejemplos:**  

  - Todas las interacciones del cliente 1:  
    `Kbr4 verInteracciones 1`

  - Solo llamadas del cliente 1 en noviembre de 2025:  
    `Kbr4 verInteracciones 1 llamada 01/11/2025 30/11/2025`
