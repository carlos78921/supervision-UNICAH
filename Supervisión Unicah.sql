create database Supervision_Unicah 
go

use Supervision_Unicah 
go
--Primero ejecutar los dos comandos para importar, luego coméntenlo para ejecutar todo

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

insert into Nombres_Completos
select Nombre1, Nombre2, Nombre3, Nombre4
from Empleo$
go

CREATE TABLE Empleados (
    ID_Empleado int foreign key references Nombres_Completos(ID_Empleado),
    rol VARCHAR(50) NOT NULL,
    codigo_empleado VARCHAR(4) unique NOT NULL,
    contraseña VARCHAR(255)
)
go

alter table Migración$DatosExternos_3
add ID_Empleado int foreign key references Nombres_Completos(ID_Empleado)
go

-- ¿Qué es esto?
UPDATE M
SET M.ID_Empleado = NC.ID_Empleado
FROM Migración$DatosExternos_3 M
JOIN Nombres_Completos NC
  ON UPPER(LTRIM(RTRIM(M.Nombre1))) = UPPER(LTRIM(RTRIM(nc.Nombre1)))
  AND UPPER(LTRIM(RTRIM(M.Nombre2))) = UPPER(LTRIM(RTRIM(nc.Nombre2)))
  AND UPPER(LTRIM(RTRIM(Nombre3))) = UPPER(LTRIM(RTRIM(Apellido1)))
  and (
          (Nombre4 is null and Apellido2 is null)
          or UPPER(LTRIM(RTRIM(Nombre4))) = UPPER(LTRIM(RTRIM(Apellido2)))
	  )
go

-- ¿Qué es esto?
INSERT INTO Empleados (ID_Empleado, rol, codigo_empleado)
SELECT 
    M.ID_Empleado,                           
    'docente' AS rol,                   
    M.Cod_Empleado                         
FROM Migración$DatosExternos_3 M
JOIN Nombres_Completos nc
    ON UPPER(LTRIM(RTRIM(M.Nombre1))) = UPPER(LTRIM(RTRIM(nc.Nombre1)))
   AND UPPER(LTRIM(RTRIM(M.Nombre2))) = UPPER(LTRIM(RTRIM(nc.Nombre2)))
   AND UPPER(LTRIM(RTRIM(Nombre3))) = UPPER(LTRIM(RTRIM(Apellido1)))
   AND (
         (Nombre4 IS NULL AND Apellido2 IS NULL)  -- Ambos nulos se consideran iguales
         OR UPPER(LTRIM(RTRIM(Nombre4))) = UPPER(LTRIM(RTRIM(Apellido2)))
       )
group by M.ID_Empleado, M.Cod_Empleado

create table Clases 
(
	ID_Clase int identity primary key,
	Cod_Asignatura varchar(7),
	Cod_Facultad varchar (6), 
	Asignatura varchar(70)
)
go

insert into Clases 
select Codigo_Asignatura, Codigo_Facultad, Curso
from Clase$
go

alter table Migración$DatosExternos_3
add ID_Clase int foreign key references Clases (ID_Clase)
go

UPDATE M
SET M.ID_Clase = C.ID_Clase
FROM Migración$DatosExternos_3 M
JOIN Clases C
  ON Codigo_Asignatura = Cod_Asignatura and
     Codigo_Facultad = Cod_Facultad and
	 Curso = Asignatura
go

create table Sitio
(
	ID_Sitio int identity primary key,
        Edificio char,
	Aula varchar(25),
	Seccion varchar (6)    
)
go

insert into Sitio
select *
from Lugares$
go

alter table Migración$DatosExternos_3
add ID_Sitio int foreign key references Sitio(ID_Sitio)
go

UPDATE M
SET M.ID_Sitio = S.ID_Sitio
FROM Migración$DatosExternos_3 M
JOIN Sitio S
  ON M.Aula = S.Aula and
     M.Edificio = S.Edificio and
	 M.Seccion = S.Seccion
go 

drop table Clase$
drop table Lugares$
drop table Empleo$
alter table Migración$DatosExternos_3
drop column Curso
alter table Migración$DatosExternos_3
drop column Seccion
alter table Migración$DatosExternos_3
drop column Aula
alter table Migración$DatosExternos_3
drop column Cod_Empleado
alter table Migración$DatosExternos_3
drop column Edificio
alter table Migración$DatosExternos_3
drop column Codigo_Facultad
alter table Migración$DatosExternos_3
drop column Codigo_Asignatura
alter table Migración$DatosExternos_3
drop column Nombre1
alter table Migración$DatosExternos_3
drop column Nombre2
alter table Migración$DatosExternos_3
drop column Nombre3
alter table Migración$DatosExternos_3
drop column Nombre4
go

create table Asistencia -- ¿Habrá tantos inserts con un checkbox desmarcado?
( 
	ID_Asistencia int identity primary key,
	ID_Clase int foreign key references Clases (ID_Clase),
    	ID_Sitio int foreign key references Sitio (ID_Sitio),
	ID_Empleado int foreign key references Nombres_Completos(ID_Empleado),
	Fecha date,
	Observacion nvarchar(150), 
	Fecha_Reposicion date,
	Presente bit
) 
go

insert into Asistencia (ID_Empleado, ID_Clase, ID_Sitio)
select ID_Empleado, ID_Clase, ID_Sitio from Migración$DatosExternos_3
go

update Asistencia
set Presente = 0
go

update Asistencia
set Fecha = getdate()
go
	
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

create proc PA_Contra
@Usuario varchar(4),
@Contraseña varchar (255)
with encryption
as 
begin
	update Empleados
	set Contraseña = @Contraseña
	where codigo_empleado = @Usuario

    IF @@ROWCOUNT = 0 --Hace conteo de filas detectada de la acción dml
        RETURN 0;  -- Usuario no encontrado
    ELSE 
        RETURN 1;  -- Actualización exitosa
end
go

create proc PA_Supervisor -- Toma de Asistencia para supervisor
with encryption
as                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
begin  
	select (Nombre1 + ' ' + Nombre2 + ' ' + Apellido1 + ' ' + isnull(Apellido2,'')) [Docente], 
	Asignatura,
	Seccion, 
	Aula,
	Edificio
	from Asistencia A
	join Clases C
	on A.ID_Clase = C.ID_Clase
	join Sitio S
	on A.ID_Sitio = S.ID_Sitio
	join Empleados E 
	on A.ID_Empleado = E.ID_Empleado
	join Nombres_Completos NC
	on E.ID_Empleado = NC.ID_Empleado
	where codigo_empleado != '037'
end
go

create proc PA_Asistencia
@idEmpleado int
with encryption
as 
begin
	SELECT Fecha FROM Asistencia WHERE ID_Empleado = @idEmpleado 
end
go

--En asistencia insertan y luego actualizan
create proc PA_Admin -- Para el Admin
with encryption
as 
begin
	select (Cod_Facultad + ' - ' + Cod_Asignatura) [Referencia], 
	Asignatura [Curso], 
	Seccion, (Edificio + ' - ' + Aula) [Aula], 
	(codigo_empleado + ' - ' + Nombre1 + ' ' + Nombre2 + ' ' + Apellido1 + ' ' + isnull(Apellido2,'')) [Empleado]
	--isnull: comando de condición para insertar valor nulo como vacío o '' (este solo es de un valor y su reemplazo)
	from Asistencia A
	join Clases C
	on A.ID_Clase = C.ID_Clase
	join Sitio S
	on A.ID_Sitio = S.ID_Sitio
	join Empleados E
	on A.ID_Empleado = E.ID_Empleado
	join Nombres_Completos nc
	on E.ID_Empleado = nc.ID_Empleado
	where codigo_empleado != '037'
end
go
exec PA_Admin  

/*create proc PA_Asistencia_Doc -- Toma de Asistencia para docente
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
exec PA_Asistencia_Doc 'Clase1', '0701', 0, 0, 0, 0, 0, 0	
*/

/*
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
*/

/*create PROCEDURE PA_Reponer_Deca
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
*/
