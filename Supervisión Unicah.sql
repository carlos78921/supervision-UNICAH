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

create proc PA_Asistencia -- Toma de Asistencia, afectado en supervisor y docente
as 
begin
	select Asignatura, nombre_empleado, Seccion, Presente [L], Presente [M], Presente [M], Presente [J], Presente [V], Presente [S]
	from Asistencia A
	join Clases C
	on A.Cod_Asignatura = C.Cod_Asignatura
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
end

/*create PROCEDURE PA_Reponer_Deca
AS
BEGIN
    SELECT 
        Asignatura, 
        Fecha [Fecha_Asistencia], 
        Seccion [Seccion_Asistencia], 
        Nombre_Empleado [Docente],
        Fecha_Reposicion [Fecha_Reposición]
    FROM Asistencia A
    JOIN Clases C ON A.Cod_Asignatura = C.Cod_Asignatura
    JOIN Usuarios U ON C.Cod_Cargo = U.Cod_Cargo 
    WHERE Fecha_Reposicion IS NOT NULL
END
GO

CREATE PROCEDURE PA_Justificado_Deca
AS
BEGIN
    SELECT 
        Asignatura, 
        Fecha [Fecha_Asistencia], 
        Seccion, 
        Nombre_Empleado [Docente],
        Observacion_Especifica [Observación_Justificada]
    FROM Asistencia A
    JOIN Clases C ON A.Cod_Asignatura = C.Cod_Asignatura 
    JOIN Usuarios U ON C.Cod_Cargo = U.Cod_Cargo 
    WHERE A.Observacion_Especifica IS NOT NULL
END
GO
*/

