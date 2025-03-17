create database Supervision_Unicah 
go

use Supervision_Unicah 
go

set nocount on

create table Nombres_Completos (
	ID_Empleado int identity primary key,
	Nombre1 varchar(9),
	Nombre2 varchar(11),
	Apellido1 varchar(13),
	Apellido2 varchar(11)
)
--Recuerden que son cuatro actores
go

CREATE TABLE Empleados (
    ID_Empleado int foreign key references Nombres_Completos(ID_Empleado),
    rol VARCHAR(50) NOT NULL,
    codigo_empleado VARCHAR(4) unique NOT NULL,
    contraseña VARCHAR(255)
)
go

alter table tabla1$
add ID_Empleado int foreign key references Nombres_Completos (ID_Empleado)
	
UPDATE T
SET T.ID_Empleado = NC.ID_Empleado
FROM Tabla1$ T
JOIN Nombres_Completos NC
  ON UPPER(LTRIM(RTRIM(T.Nombre1))) = UPPER(LTRIM(RTRIM(nc.Nombre1)))
  AND UPPER(LTRIM(RTRIM(T.Nombre2))) = UPPER(LTRIM(RTRIM(nc.Nombre2)))
  AND UPPER(LTRIM(RTRIM(Nombre3))) = UPPER(LTRIM(RTRIM(Apellido1)))
  and (
          (Nombre4 is null and Apellido2 is null)
          or UPPER(LTRIM(RTRIM(Nombre4))) = UPPER(LTRIM(RTRIM(Apellido2)))
	  )

INSERT INTO Empleados (ID_Empleado, rol, codigo_empleado)
SELECT 
    T.ID_Empleado,                           
    'docente' AS rol,                  
    T.Cod_Empleado                         
FROM Tabla1$ T
JOIN Nombres_Completos nc
    ON UPPER(LTRIM(RTRIM(T.Nombre1))) = UPPER(LTRIM(RTRIM(nc.Nombre1)))
   AND UPPER(LTRIM(RTRIM(T.Nombre2))) = UPPER(LTRIM(RTRIM(nc.Nombre2)))
   AND UPPER(LTRIM(RTRIM(Nombre3))) = UPPER(LTRIM(RTRIM(Apellido1)))
   AND (
         (Nombre4 IS NULL AND Apellido2 IS NULL)  -- Ambos nulos se consideran iguales
         OR UPPER(LTRIM(RTRIM(Nombre4))) = UPPER(LTRIM(RTRIM(Apellido2)))
       )
group by T.ID_Empleado, T.Cod_Empleado

create table Clases 
(
	Cod_Asignatura varchar(6) primary key,
	Cod_Facultad varchar (6), 
	Asignatura varchar(55)
)
go
	
create table Sitio
(
	ID_Sitio int identity primary key,
   	Edificio char,
	Num_Aula int,
	Seccion varchar (5)    
)

create table Asistencia
(
	ID_Asistencia int identity primary key,
	Cod_Asignatura varchar(6) foreign key references Clases (Cod_Asignatura),
	ID_Sitio int foreign key references Sitio (ID_Sitio),
        codigo_empleado varchar(4) foreign key references Empleados(codigo_empleado),
	Fecha date,
	Observacion nvarchar(150), 
	Fecha_Reposicion date
)
go
	
create table Toma_Asistencia
(
	ID_Asistencia int unique not null,
	foreign key (ID_Asistencia) references Asistencia(ID_Asistencia),
	Lunes bit,
	Martes bit, 
	Miercoles bit, 
	jueves bit, 
	Viernes bit,
	Sabado bit
)
	
-- Procedimientos Almacenados
create PROCEDURE PA_Login
@usuario VARCHAR(4)
--@contrasena VARCHAR(255)
with encryption
AS
BEGIN
	SELECT nombre1, apellido1, rol 
	FROM Empleados E	
	join Nombres_Completos NC on E.ID_Empleado = NC.ID_Empleado 
	WHERE codigo_empleado = @usuario --AND contraseña = @contrasena
END
GO

create proc PA_Formato_Asistencia -- Para el Admin
-- Declarar variables ___ para usarlas en el...
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
	join Sitio S
	on A.ID_Sitio = S.ID_Sitio
	join Empleados E
	on A.codigo_empleado = E.codigo_empleado
	join Toma_Asistencia TA
	on A.ID_Asistencia = TA.ID_Asistencia
end
go

create proc PA_Asistencia_Superv -- Toma de Asistencia para supervisor
-- Declarar variables ___ para usarlas en el...
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
	join Sitio S
	on A.ID_Sitio = S.ID_Sitio
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

	--Datos a DGVADMIN
create procedure PA_Admin
with encryption 
as
begin
	select
	(C.Cod_Facultad + ' ' + A.Cod_Asignatura) AS Referencia, 
        C.Asignatura AS Curso, 
        S.Seccion, 
        (S.Edificio + ' - ' + CAST(S.Num_Aula AS VARCHAR)) AS Aula, 
        TA.Lunes AS L, 
        TA.Martes AS M, 
        TA.Miercoles AS M, 
        TA.Jueves AS J, 
        TA.Viernes AS V, 
        TA.Sabado AS S
	from 
	Asistencia A
    INNER JOIN 
        Clases C ON A.Cod_Asignatura = C.Cod_Asignatura
    INNER JOIN 
        Sitio S ON A.ID_Sitio = S.ID_Sitio
    INNER JOIN 
        Empleados E ON A.codigo_empleado = E.codigo_empleado
    INNER JOIN 
        Toma_Asistencia TA ON A.ID_Asistencia = TA.ID_Asistencia;
END
GO

	
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
