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
go

create table DecanoFacultad -- Para esta tabla en los inserts puse que ID_Empleado de la decana, y las demás facultades al supervisor, esto para que realice filtro de registros por facultad
(
codigo_facu varchar(6) primary key,
ID_Empleado int foreign key references Nombres_Completos(ID_Empleado)
)
go 

create table Clases 
(
	ID_Clase int identity primary key,
	Cod_Asignatura varchar(7),
	Cod_Facultad varchar (6) foreign key references DecanoFacultad(codigo_facu), -- Esto funciona cuando las facultades sean iguales que el primario de DecanoFacultad
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
@usuario VARCHAR(4),
@contrasena varchar(255)
with encryption
AS
BEGIN
	SELECT nombre1, apellido1, rol 
	FROM Empleados E	
	join Nombres_Completos NC on E.ID_Empleado = NC.ID_Empleado 
	WHERE codigo_empleado = @usuario AND ltrim((rtrim(contraseña))) = @contrasena
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

create proc PA_Admin_Save
@Usuario varchar(4)
with encryption 
as
begin
	if (@Usuario =1) 
	begin
		select codigo_empleado 
		from Empleados
		where codigo_empleado = @Usuario
	end
	else	
	     return
end
go

create proc PA_Supervisor -- Tabla del supervisor
with encryption
AS
BEGIN
    DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

    SELECT distinct
        (NC.Nombre1 + ' ' + NC.Nombre2 + ' ' + NC.Apellido1 + ' ' + ISNULL(NC.Apellido2, '')) AS Docente,
        C.Asignatura,
        S.Seccion,
        S.Aula,
        S.Edificio,
        CASE 
            WHEN EXISTS (
                SELECT 1 FROM Asistencia A2
                WHERE A2.ID_Empleado = E.ID_Empleado
                  AND A2.ID_Clase = C.ID_Clase
                  AND A2.ID_Sitio = S.ID_Sitio
                  AND CAST(A2.Fecha AS DATE) = @Hoy
                  AND A2.Presente = 1
            ) THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS AsistenciaHoy
    FROM Clases C
    JOIN Asistencia A ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    WHERE E.codigo_empleado != '037'
END
go

create proc PA_Marcar_Asistencia 
	@Docente varchar(31),
	@Asigno varchar(70),
	@Seccion varchar(7),
	@Aula varchar(25),
	@Edificio char,
	@Fecha date,
    @Marca BIT
AS
BEGIN
    SET NOCOUNT ON;

	/*Para ID de asistencia:
    Obtener ID del empleado*/
	declare @ID_Empleado INT
	select @ID_Empleado = ID_Empleado
	from Nombres_Completos
	where (Nombre1 + ' ' + Nombre2 + ' ' + Apellido1 + ' ' + Apellido2) = @Docente

	declare @ID_Clase INT
 -- Obtener ID de la clase
	select @ID_Clase = ID_Clase
	from Clases
	where Asignatura = @Asigno

	declare @ID_Sitio INT
 -- Obtener ID de la clase
	select @ID_Sitio = ID_Sitio
	from Sitio
	where Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio

    DECLARE @ID_Asistencia INT
     -- Verificar si ya existe un de asistencia por los ID y la fecha
    SELECT @ID_Asistencia = ID_Asistencia
    FROM Asistencia 
    WHERE ID_Empleado = @ID_Empleado and ID_Sitio = @ID_Sitio and ID_Clase = @ID_Clase AND CAST(Fecha AS DATE) = CAST(@Fecha AS DATE);

	if (@ID_Empleado is null or @ID_Sitio is null or @ID_Clase is null)
		print('Problemas con el desarrollo del sistema')
    IF (@ID_Asistencia IS NULL) --si pusiera un "not exists para ahorrar código, igual da error de sintaxis
    BEGIN
        -- No existe, se inserta un nuevo registro
        INSERT INTO Asistencia (ID_Clase, ID_Sitio, ID_Empleado, Fecha, Presente)
        VALUES (@ID_Clase, @ID_Sitio, @ID_Empleado, @Fecha, @Marca);
		set @ID_Asistencia = scope_identity()
	end
    ELSE
    BEGIN
        -- Ya existe: se puede actualizar, por ejemplo
        UPDATE Asistencia
        SET Presente = @Marca
        WHERE ID_Asistencia = @ID_Asistencia;
    END
END;
go

create PROCEDURE PA_Buscar_Superv
    @Docente VARCHAR(50),
    @Clase VARCHAR(70),
    @Aula VARCHAR(25),
    @Seccion VARCHAR(7),
	@Edificio VARCHAR(1)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT 
        (Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) AS Docente, 
        Asignatura, Seccion, Aula, Edificio 
    FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE ((Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) LIKE '%' + @Docente + '%' OR @Docente = '')
      AND (Asignatura LIKE '%' + @Clase + '%' OR @Clase = '')
	  AND (@Seccion = '' OR Seccion = @Seccion)
      AND (@Aula = '' OR Aula = @Aula)
	  AND (@Edificio = '' OR Edificio = @Edificio)
END;
go

create proc PA_Admin -- Para tabla Admin
with encryption
as 
begin
	select distinct (Cod_Facultad + ' - ' + Cod_Asignatura) [Referencia], 
	Asignatura [Curso], 
	Seccion, (Edificio + ' - ' + Aula) [Aula], 
	(codigo_empleado + ' - ' + Nombre1 + ' ' + isnull(Nombre2,'') + ' ' + Apellido1 + ' ' + isnull(Apellido2,'')) [Empleado]
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

create proc PA_Asistencia_Admin --Calendario del admin
@Referencia varchar(16),
@Curso varchar (70),
@Seccion varchar(7),
@Aula varchar(29),
@Empleado varchar (38)
with encryption
as 
begin
	/*Para fila específica:
    Obtener ID del empleado*/
	declare @ID_Empleado INT
	select @ID_Empleado = NC.ID_Empleado
	from Nombres_Completos NC
	join Empleados E on NC.ID_Empleado = E.ID_Empleado
	where (codigo_empleado + ' - ' + Nombre1 + ' ' + isnull(Nombre2,'') + ' ' + Apellido1 + ' ' + isnull(Apellido2,'')) = @Empleado
	
	-- Obtener ID de la clase
	declare @ID_Clase INT
 	select @ID_Clase = ID_Clase
	from Clases
	where (Cod_Facultad + ' - ' + Cod_Asignatura) = @Referencia and Asignatura = @Curso

	declare @ID_Sitio INT
 -- Obtener ID de la clase
	select @ID_Sitio = ID_Sitio
	from Sitio
	where Seccion = @Seccion and (Edificio + ' - ' + Aula) = @Aula 

    SELECT Fecha FROM Asistencia WHERE Presente = 1 and ID_Clase = @ID_Clase and ID_Sitio = @ID_Sitio and ID_Empleado = @ID_Empleado;
end
go

create PROCEDURE PA_Justifica --Decano
@CodigoDecano varchar(4)
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @codigo_facu VARCHAR(6);

    SELECT @codigo_facu = codigo_facu
    FROM DecanoFacultad DF
    JOIN Nombres_Completos NC ON DF.ID_Empleado = NC.ID_Empleado
	join Empleados E on E.ID_Empleado = NC.ID_Empleado
    WHERE codigo_empleado = @CodigoDecano;

    SELECT DISTINCT 
           ID_Asistencia,
		   Cod_Facultad,
           Asignatura,
           Fecha AS [Fecha de Ausencia],
           (NC.Nombre1 + ' ' + ISNULL(NC.Nombre2, '') + ' ' + NC.Apellido1 + ' ' + ISNULL(NC.Apellido2, '')) AS [Docente],
           S.Seccion,
           A.Observacion AS [Justificacion]
    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    -- Filtrar por el código de facultad del decano:
    WHERE C.Cod_Facultad = @codigo_facu  
    AND A.Presente = 0;
end
go
select * from Empleados where ID_Empleado = 3
select * from DecanoFacultad
select * from Clases

CREATE PROCEDURE PA_Insertar_Justificacion
    @ID_Asistencia INT,
    @Justificacion NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Asistencia
    SET Observacion = @Justificacion
    WHERE ID_Asistencia = @ID_Asistencia;
END
go

create PROCEDURE PA_Buscar_Justo
    @Docente VARCHAR(50),
	@Edificio VARCHAR(9)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT ID_Asistencia,
          Asignatura, fecha 'Fecha de Ausencia', Seccion, (Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) AS Docente, 
          Aula, Edificio, Observacion
    FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE Presente = 0 and
	  ((Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) LIKE '%' + @Docente + '%' OR @Docente = '')
	  AND (@Edificio = '' OR Edificio = @Edificio)
END;
go

create PROCEDURE PA_Repone --Decano
AS
BEGIN
    SET NOCOUNT ON;
    SELECT distinct ID_Asistencia,
		   Asignatura,
           Fecha [Fecha de Ausencia],
           (Nombre1 + ' ' + isnull(Nombre2,'') + ' ' + Apellido1 + ' ' + isnull(Apellido2,'')) AS [Docente],
           Seccion,
           Fecha_Reposicion 'Fecha de Reposición'
    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    join DecanoFacultad DF on Cod_Facultad = codigo_facu
    WHERE A.Presente = 0 and Cod_Facultad = codigo_facu
END
go

CREATE PROCEDURE PA_Insertar_Reposicion --Decano
    @ID_Asistencia INT,
    @Fecha_Reposicion date
AS
BEGIN
    SET NOCOUNT ON;
 
    UPDATE Asistencia
    SET Fecha_Reposicion = @Fecha_Reposicion
    WHERE ID_Asistencia = @ID_Asistencia
END
go

create PROCEDURE PA_Buscar_Repo
@Repo varchar(80),	
@Edificio VARCHAR(9)
	
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT 
        ID_Asistencia, Asignatura, fecha 'Fecha de Ausencia', Seccion, (Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) AS Docente, 
        Fecha_Reposicion
    FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE Presente = 0 and ((@Repo = ''  
	  or ((Nombre1 + ' ' + ISNULL(Nombre2, '') + ' ' + Apellido1 + ' ' + ISNULL(Apellido2, '')) LIKE '%' + @Repo + '%')
	  or (Asignatura LIKE '%' + @Repo + '%')
	  or (Fecha like '%' + @Repo + '%')
	  or (Seccion like '%' + @Repo + '%'))
	  and (@Edificio = '' OR Edificio = @Edificio))
END;
go

create PROCEDURE PA_Asistencia_Doc -- Tabla del docente
    @CodigoDocente VARCHAR(4)
WITH ENCRYPTION
AS
BEGIN

    SELECT DISTINCT 
        Asignatura, 
        Seccion,
		Aula,
		Edificio
    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    WHERE E.Codigo_Empleado = @CodigoDocente;
END;
go

alter proc PA_Fecha_Doc -- Calendario del docente
@CodDocente varchar(4),
@Asigna varchar (70),
@Seccion varchar(7),
@Aula varchar(25),
@Edificio char
with encryption
as 
begin
	/*Para fila específica:
    Obtener ID del empleado*/
	declare @ID_Empleado INT
	select @ID_Empleado = ID_Empleado 
	from Empleados
	where codigo_empleado = @CodDocente

	-- Obtener ID de la clase
	declare @ID_Clase INT
 	select @ID_Clase = ID_Clase
	from Clases
	where Asignatura = @Asigna

	declare @ID_Sitio INT
 -- Obtener ID de la clase
	select @ID_Sitio = ID_Sitio
	from Sitio
	where Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio

    SELECT Fecha FROM Asistencia WHERE Presente = 1 and ID_Clase = @ID_Clase and ID_Sitio = @ID_Sitio and ID_Empleado = @ID_Empleado;
end
go

CREATE TRIGGER TGR_AdminContra
ON Empleados
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
	select * from Empleados
	--Busca al único administrador por su rol
    IF EXISTS (SELECT 1 FROM inserted WHERE rol = 'administrador')
    BEGIN
        -- Actualiza la contraseña con un valor predeterminado (por seguridad)
		UPDATE Empleados
		--Subconsulta para efecto de inserted en @contraseña, pues @contraseña se usa en visual, no en trigger
        SET contraseña = (SELECT Contraseña FROM inserted WHERE Rol = 'Administrador') 
        WHERE rol = 'Administrador';
    END
END;
go

CREATE TABLE Asistencia_Backup (
    BackupID INT IDENTITY(1,1) PRIMARY KEY,
    IDEmpleado INT,
    Fecha DATETIME,
    Presente BIT,
    BackupFecha DATETIME DEFAULT GETDATE()
)
go

CREATE TRIGGER _BackupAsistencia
ON Asistencia
AFTER INSERT
AS
BEGIN
    -- Verifica que las columnas existen en la tabla Asistencia
    INSERT INTO Asistencia_Backup (IDEmpleado, Fecha, Presente, BackupFecha)
    SELECT i.ID_Empleado, i.Fecha, i.Presente, GETDATE()
    FROM inserted i;
END;
