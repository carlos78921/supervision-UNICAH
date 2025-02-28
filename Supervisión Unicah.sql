create database Supervision_Unicah 
go

use Supervision_Unicah 
go

set nocount on

CREATE TABLE docentes (
    codigo_docente varchar (4) primary key,
    nombre_docente VARCHAR(50) NOT NULL,
    apellido_docente VARCHAR(50) NOT NULL,
    rol VARCHAR(50) NOT NULL,
    usuario VARCHAR(50) UNIQUE NOT NULL,
    contrase�a VARCHAR(255) NOT NULL
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
	A�o date
)
go

create table Asistencia
(
	Cod_Asignatura varchar(6) foreign key references Clases (Cod_Asignatura),
    codigo_docente varchar(4) foreign key references docentes(codigo_docente),
	Fecha date,
	Presente bit,
	Observacion nvarchar(150), 
	Fecha_Reposicion date
)
go

INSERT INTO docentes VALUES 
('0000', 'Juan', 'P�rez', 'supervisor', 'juan.perez', 'contrase�a123');

INSERT INTO docentes values
('0001', 'Mar�a', 'L�pez', 'decano', 'maria.lopez', 'contrase�a101');

INSERT INTO docentes VALUES 
('0002', 'Carlos', 'Ram�rez', 'docente', 'carlos.ramirez', 'contrase�a456');

INSERT INTO docentes VALUES
('0003', 'Mar�a', 'L�pez', 'docente', 'maria.lopez1', 'contrase�a789');

select * from docentes

/*-- Procedimientos Almacenados
create PROCEDURE PA_Reponer_Deca
AS
BEGIN
    SELECT 
        Asignatura, 
        Fecha [Fecha_Asistencia], 
        Seccion [Seccion_Asistencia], 
        Nombre_Empleado [Docente],
        Fecha_Reposicion [Fecha_Reposici�n]
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
        Observacion_Especifica [Observaci�n_Justificada]
    FROM Asistencia A
    JOIN Clases C ON A.Cod_Asignatura = C.Cod_Asignatura 
    JOIN Usuarios U ON C.Cod_Cargo = U.Cod_Cargo 
    WHERE A.Observacion_Especifica IS NOT NULL
END
GO

create proc PA_Profe_Asiste -- Toma de Asistencia
as 
begin
select Asignatura, Nombre_Empleado, Secci�n, Fecha, Presente [L], Presente [M], Presente [M], Presente [J], Presente [V], Presente [S]
from Asistencia A
join Clases C
on A.Cod_Asignatura = C.Cod_Asignatura
join Usuarios U
on C.Cod_Cargo = U.Cod_Cargo
end
*/

