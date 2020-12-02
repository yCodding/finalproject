CREATE DATABASE PFCapas

USE PFCapas

----------------MÓDULO MANTENIMIENTO----------------
CREATE TABLE Cargos(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Cargo NVARCHAR(50) NOT NULL
)

CREATE TABLE Departamentos(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Codigo INT NOT NULL,
  Nombre NVARCHAR(50) NOT null
)

CREATE TABLE Empleados(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Codigo INT NOT NULL,
  Nombre NVARCHAR(50),
  Apellido NVARCHAR(50),
  Telefono BIGINT,
  fechaIngreso DATE,
  Salario DECIMAL,
  Estatus NVARCHAR(15),
  Departamento INT NOT NULL FOREIGN KEY REFERENCES Departamentos(ID),  
  Cargo int NOT NULL FOREIGN KEY REFERENCES Cargos(ID)  
)

  SELECT * from Empleados WHERE MONTH(fechaIngreso) = 11

SELECT e.ID, e.Codigo AS 'Código', e.Nombre, e.Apellido, e.Telefono AS 'Teléfono', e.fechaIngreso AS 'Fecha de Ingreso', e.Salario, e.Estatus, d.Nombre AS 'Nombre Departamento', c.Cargo AS 'Cargo' FROM Empleados e
  JOIN departamentos d ON e.ID = d.ID_E
  JOIN cargos c ON e.ID = c.ID_E

----------------MÓDULO PROCESOS----------------


CREATE TABLE CNomina(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Año NVARCHAR(5),
  Mes NVARCHAR(3),
  montoTotal decimal
)
--
--INSERT INTO CNomina (Año, Mes) VALUES ('2001', '11')
--
--SELECT c.ID, c.Año, c.Mes, e.Salario AS 'Monto Total' FROM CNomina c
--  JOIN empleados e ON c.ID_E = e.ID 
--  ORDER BY c.ID

CREATE TABLE Salida(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Empleado NVARCHAR(50),
  tipoSalida NVARCHAR(50),
  Motivo NVARCHAR(MAX),
  fechaSalida  date
)

CREATE PROCEDURE Entradas
@nombre VARCHAR(20)
AS
BEGIN  
  SELECT e.ID, e.Codigo AS 'Código', e.Nombre, e.Apellido, e.Telefono AS 'Teléfono', e.fechaIngreso AS 'Fecha de Ingreso', e.Salario, e.Estatus, d.Nombre AS 'Nombre Departamento', c.Cargo AS 'Cargo' FROM Empleados e 
    JOIN departamentos d ON e.Departamento = d.ID
    JOIN cargos c ON e.Cargo = c.ID
    WHERE MONTH(fechaIngreso) = @nombre AND Estatus = 'Activo'
END
EXEC empEntrada 11
GO 

CREATE PROCEDURE Salidas
@nombre VARCHAR(20)
AS
BEGIN  
  SELECT e.ID, e.Codigo AS 'Código', e.Nombre, e.Apellido, e.Telefono AS 'Teléfono', e.fechaIngreso AS 'Fecha de Ingreso', e.Salario, e.Estatus, d.Nombre AS 'Nombre Departamento', c.Cargo AS 'Cargo' FROM Empleados e 
    JOIN departamentos d ON e.Departamento = d.ID
    JOIN cargos c ON e.Cargo = c.ID
    WHERE MONTH(fechaIngreso) = @nombre AND Estatus = 'Inactivo'
END
  EXEC empEntradas '11'

CREATE TABLE Vacaciones(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Empleado NVARCHAR(50),
  Desde DATE,
  Hasta DATE,
  Correspondiente NVARCHAR(4),
  Comentarios NVARCHAR(MAX)
  )

CREATE TABLE Permisos(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Empleado NVARCHAR(50),
  Desde DATE,
  Hasta DATE,
  Comentarios NVARCHAR(MAX)
)

CREATE TABLE Licencias(
  ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Empleado NVARCHAR(50),
  Desde DATE,
  Hasta DATE,
  Motivo NVARCHAR(MAX),
  Comentarios NVARCHAR(MAX)
)


CREATE PROCEDURE Permiso
@nombre VARCHAR(20)
AS
BEGIN  
  SELECT * FROM Permisos WHERE Empleado = @nombre
END
  EXEC Permiso 'Bryan Evans'

  create trigger salidaEmpleado
on Salida AFTER insert AS
BEGIN
     UPDATE Empleados SET Estatus = 'Inactivo' WHERE Nombre = ((SELECT Empleado FROM INSERTED))
END

  create trigger nominaEmpleados
on Empleados
after insert    
AS
BEGIN
     UPDATE CNomina SET montoTotal = ((SELECT SUM(Salario) FROM Empleados WHERE Estatus = 'Activo')) 
    END


  create trigger nominaEmpleadox
on Salida
after insert    
AS
BEGIN
    UPDATE CNomina SET montoTotal = ((SELECT SUM(Salario) FROM Empleados WHERE Estatus = 'Activo')) 
    END
  