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

insert Empleados values ('0000', 'El', 'Admin', 'administrador', '0000', 'admin1')
insert Empleados values ('0001', 'Señor', 'Dago', 'supervisor', '0001', 'super1')
insert Empleados values ('0002', 'Jocelynn', 'Andrade', 'decano', '0002', 'deca1')
insert Empleados values ('0003', 'Aracely', 'Rodríguez', 'docente','0003', 'doc1')
insert Empleados values ('0004', 'Jocelynn', 'Andrade', 'decano', '0004', 'deca1')

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
)
go

create table Asistencia
(
	ID_Asistencia int identity primary key,
	Cod_Asignatura varchar(6) foreign key references Clases (Cod_Asignatura),
    codigo_empleado varchar(4) foreign key references Empleados(codigo_empleado),
	Fecha date,
	Observacion nvarchar(150), 
	Fecha_Reposicion date
)
go

create table Toma_Asistencia
(
	ID_Asistencia int foreign key references Asistencia(ID_Asistencia),
	Lunes bit,
	Martes bit, 
	Miercoles bit, 
	jueves bit, 
	Viernes bit,
	Sabado bit
)

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

create proc PA_Formato_Asistencia -- Para el Admin
with encryption
as 
begin
	select (Cod_Facultad + ' ' + A.Cod_Asignatura) [Referencia], 
	Asignatura [Curso], 
	Seccion, (Edificio + ' - ' + Num_Aula) [Aula], 
	Lunes [L], Martes [M], Miercoles [M], Jueves [J], Viernes [V], Sabado [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
	join Toma_Asistencia TA
	on A.ID_Asistencia = TA.ID_Asistencia
end
go

create proc PA_Asistencia_Superv -- Toma de Asistencia para supervisor
with encryption
as 
begin
	select Asignatura, 
	(nombre_empleado + ' ' + apellido_empleado) [Docente], 
	Seccion, 
	Lunes [L], Martes [M], Miercoles [M], Jueves [J], Viernes [V], Sabado [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
	join Toma_Asistencia TA
	on A.ID_Asistencia = TA.ID_Asistencia
end
go

create proc PA_Asistencia_Doc -- Toma de Asistencia para docente
@Clase varchar(55),
@Seccion varchar (4),
@L bit,
@M bit, 
@X bit,
@J bit,
@V bit, 
@S bit
with encryption
as 
begin
	select Asignatura, Seccion, 
	Lunes [L], Martes [M], Miercoles [M], Jueves [J], Viernes [V], Sabado [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
	join Toma_Asistencia TA
	on A.ID_Asistencia = TA.ID_Asistencia
	where Asignatura = @Clase and Seccion = @Seccion and 
	Lunes = @L and Martes = @M and Miercoles = @X and Jueves = @J and Viernes = @V and Sabado = @S
end
go
exec PA_Asistencia_Doc 'Clase1', '0701', 0, 0, 0, 0, 0, 0	

CREATE PROCEDURE PA_Justificaciones
with encryption
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

drop PROCEDURE PA_Reponer_Deca
with encryption
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