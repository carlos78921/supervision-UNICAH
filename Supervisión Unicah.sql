create database Supervision_Unicah 
go

use Supervision_Unicah 
go

set nocount on

CREATE TABLE Empleados (
    codigo_empleado varchar (4) primary key,
    nombre_empleado VARCHAR(50) NOT NULL,
    apellido_empleado VARCHAR(50) NOT NULL,
    rol VARCHAR(50) NOT NULL,
    usuario VARCHAR(50) UNIQUE NOT NULL,
    contraseña VARCHAR(255) NOT NULL
)

create table Facultad
(
	Cod_Facultad varchar (6) primary key,
	Facultad varchar (40)
)
go

create table Clases 
(
	Cod_Asignatura varchar(6) primary key,
	Cod_Facultad varchar (6) foreign key references Facultad (Cod_Facultad),
	Asignatura varchar(55),
	Edificio char,
	Num_Aula int,
	Seccion varchar (4),
	Periodo int,
	Año date
)
go

create table Asistencia
(
	Cod_Asignatura varchar(6) foreign key references Clases (Cod_Asignatura),
        codigo_empleado varchar(4) foreign key references Empleados(codigo_empleado),
	Fecha date,
	Presente bit,
	Observacion nvarchar(150), 
	Fecha_Reposicion date
)
go
	
select * from Empleados

-- Procedimientos Almacenados
create PROCEDURE PA_Login
@usuario VARCHAR(50),
@contrasena VARCHAR(255)
with encryption
AS
BEGIN
	SELECT nombre_empleado, apellido_empleado, rol 
	FROM Empleados 
	WHERE usuario = @usuario AND contraseña = @contrasena	
END
GO

create proc PA_Formato_Asistencia
as 
begin
	select (Cod_Facultad + ' ' + A.Cod_Asignatura) [Referencia], 
	Asignatura [Curso], 
	Seccion, (Edificio + ' - ' + Num_Aula) [Aula], 
	Presente [L], Presente [M], Presente [M], Presente [J], Presente [V], Presente [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
end

create proc PA_Asistencia_Superv -- Toma de Asistencia para supervisor
as 
begin
	select Asignatura, 
	(nombre_empleado + ' ' + apellido_empleado) [Docente], 
	Seccion, 
	Presente [L], Presente [M], Presente [M], Presente [J], Presente [V], Presente [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
end
go

create proc PA_Asistencia_Doc -- Toma de Asistencia para docente
as 
begin
	select Asignatura, Seccion, Presente [L], Presente [M], Presente [M], Presente [J], Presente [V], Presente [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
end
go

CREATE PROCEDURE PA_Justificaciones
AS
BEGIN
    SELECT 
        Asignatura, 
        Fecha [Fecha de Ausencia], 
        Seccion, 
        (nombre_empleado + ' ' + apellido_empleado) [Docente],
        Justificacion
    FROM Asistencia A
    JOIN Clases C ON A.Cod_Asignatura = C.Cod_Asignatura 
    JOIN Empleados E ON A.codigo_empleado = E.codigo_empleado
    WHERE A.Justificacion IS NOT NULL
END
GO

create PROCEDURE PA_Reponer_Deca
AS
BEGIN
    SELECT 
        Asignatura, 
        Fecha [Fecha de Ausencia], 
        Seccion, 
        (nombre_empleado + ' ' + apellido_empleado) [Docente],
        Fecha_Reposicion [Fecha de Reposición]
    FROM Asistencia A
    JOIN Clases C ON A.Cod_Asignatura = C.Cod_Asignatura 
    JOIN Empleados E ON A.codigo_empleado = E.codigo_empleado
    WHERE Fecha_Reposicion IS NOT NULL
END
