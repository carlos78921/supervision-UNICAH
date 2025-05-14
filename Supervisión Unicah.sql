--drop database Supervision_Unicah update Empleados set contraseña = 'administrador' where ID_Empleado = 1
--exec PA_Supervision_Unicah select * from Asistencia
create or alter proc PA_Supervision_Unicah 
with encryption 
as
begin 
	set nocount on 
	IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Supervision_Unicah')
	BEGIN
		EXEC('create database Supervision_Unicah');

		exec ('use Supervision_Unicah
		create table Nombres_Completos 
		(
		ID_Empleado int identity primary key,
		Nombre1 varchar(20),
		Nombre2 varchar(20),
		Apellido1 varchar(20),
		Apellido2 varchar(20)
		)	

		CREATE TABLE Empleados 
		(	
		ID_Empleado int foreign key references Nombres_Completos(ID_Empleado),
		rol VARCHAR(50),
		codigo_empleado VARCHAR(4) unique,
		contraseña varchar(150)
		)

		create table Periodo
		(
		ID_Periodo int identity primary key,
		FechaInicio date,
		FechaFin date
		)
	
		create table DecanoFacultad
		(
		codigo_facu varchar(6) primary key,
		ID_Empleado int foreign key references Nombres_Completos(ID_Empleado)
		)
	
		create table Clases 
		(
		ID_Clase int identity primary key,
		Cod_Asignatura varchar(7),
		Cod_Facultad varchar (6) foreign key references DecanoFacultad(codigo_facu), 
		Asignatura varchar(70),
		InicioDia TINYINT,     
		FinDia TINYINT,
		DiasPermitidos INT
		)
	
		create table Sitio
		(
		ID_Sitio int identity primary key,
		Edificio varchar(1),
		Aula varchar(25),
		Seccion varchar (6)    
		)
	
		create table Asistencia 
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
		')

--Procedimientos Almacenados	
		DECLARE @sql NVARCHAR(MAX)
		SET @sql = '
		create proc dbo.PA_Nombres_Completos
		@Nombre1 varchar(9),
		@Nombre2 varchar(11),
		@Nombre3 varchar(13),
		@Nombre4 varchar(11)
		with encryption
		as 
		begin
			SET NOCOUNT ON;

	    IF NOT EXISTS (
        SELECT 1 
        FROM Nombres_Completos 
        WHERE Nombre1 = @Nombre1
        AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''')
        AND Apellido1 = @Nombre3
        AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''')
	    )
		BEGIN
			INSERT INTO Nombres_Completos (Nombre1, Nombre2, Apellido1, Apellido2)
			VALUES (@Nombre1, @Nombre2, @Nombre3, @Nombre4);
		END
	end
		'
-- Ejecuta el CREATE proc en el contexto de la base de datos Supervision_Unicah
DECLARE @finalSQL NVARCHAR(MAX)
SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
exec (@finalSQL)

		SET @sql = '
		CREATE proc dbo.PA_Login
		@usuario VARCHAR(4),
		@contrasena VARCHAR(255)
		WITH ENCRYPTION
		AS
		BEGIN
			SELECT nombre1, apellido1, rol 
			FROM Empleados E
			JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
			WHERE codigo_empleado = @usuario 
			AND BINARY_CHECKSUM(LTRIM(RTRIM(contraseña))) = BINARY_CHECKSUM(LTRIM(RTRIM(@contrasena)))
		END 
		'

SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
EXEC(@finalSQL)

	SET @sql = '
CREATE PROc dbo.PA_No_Admin  
with encryption
AS
BEGIN
  SET NOCOUNT ON;

  SELECT CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END
  FROM Empleados
  where rol = ''administrador'';
END	
';
 
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Admin_Save
    @Usuario varchar(4)
with encryption 
as 
begin	
	select 1
	from Empleados
	where codigo_empleado = @Usuario   
	and rol = ''administrador''
end
'; 
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

		SET @sql = '
		create proc dbo.PA_Empleados
		@Nombre1 varchar(9),
		@Nombre2 varchar(11),
		@Nombre3 varchar(13),
		@Nombre4 varchar(11),
		@rol varchar(50),
		@codigo varchar(4)
		with encryption
		as
		begin 
			IF EXISTS (
			SELECT 1 
			FROM Nombres_Completos
			WHERE Nombre1 = @Nombre1
			AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''')
			AND Apellido1 = @Nombre3
			AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''')
			)	
			begin	
				if not exists (
				select E.ID_Empleado from Empleados E join Nombres_Completos NC on E.ID_Empleado = NC.ID_Empleado 
				WHERE Nombre1 = @Nombre1
				AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''')
				AND Apellido1 = @Nombre3
				AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''') 
				)
	   
				INSERT INTO Empleados (ID_Empleado, rol, codigo_empleado)
				select NC.ID_Empleado, @rol, @codigo
				from Nombres_Completos NC
				WHERE Nombre1 = @Nombre1
				AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''')
				AND Apellido1 = @Nombre3
				AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''') 
				print (''Cantidad de registros actualizados'')
			end
		end 
		'
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

		SET @sql = '
		create proc dbo.PA_DecanoFacultad
		@Codigo_Facu varchar(6),
		@ID int
		with encryption
		as
		begin 
			IF not EXISTS (
			SELECT 1 
			FROM DecanoFacultad
			WHERE codigo_facu = @Codigo_Facu AND ID_Empleado = @ID
			)	
			begin	
				INSERT INTO DecanoFacultad values (@Codigo_Facu, @ID)
			end
		end 
		'

SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
exec (@finalSQL)

		SET @sql = '
		create proc dbo.PA_Clases
		@Cod_Clase varchar(7),
		@Cod_Facu varchar(6),
		@Clase varchar (70),
		@inicio tinyint,
		@fin tinyint,
		@dia int
		with encryption
		as
		begin 
			IF not EXISTS (
			SELECT 1
			FROM Clases
			WHERE Cod_Asignatura = @Cod_Clase AND Cod_Facultad = @Cod_Facu and Asignatura = @Clase 
			and InicioDia = @inicio and FinDia = @Fin and DiasPermitidos = @dia
			)	
			begin	
				INSERT INTO Clases values (@Cod_Clase, @Cod_Facu, @Clase, @inicio, @fin, @dia)
			end
		end		
		'

		SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
		exec (@finalSQL)

		set @sql = '
		create proc dbo.PA_Lugares
		@Edificio varchar(1),
		@Aula varchar(25),
		@Seccion varchar(6)
		with encryption
		as
		begin 
			IF not EXISTS (
			SELECT 1
			FROM Sitio
			WHERE Edificio = @Edificio AND Aula = @Aula and Seccion = @Seccion 
			)	
			begin	
				INSERT INTO Sitio values (@Edificio, @Aula, @Seccion)
			end
		end
		'

		SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
		exec (@finalSQL)

		set @sql = '
		create proc dbo.PA_Asistencia
		@Clase varchar(70),
		@Aula varchar(25), 
		@Seccion varchar(6),
		@Edificio varchar(1),
		@Nombre1 varchar(9),
		@Nombre2 varchar(11),
		@Nombre3 varchar(13),
		@Nombre4 varchar(11)		
		as 
		begin 
			if not exists (select 1 from Asistencia A
			join Clases C on A.ID_Clase = C.ID_Clase
			join Sitio S on A.ID_Sitio = S.ID_Sitio
			join Nombres_Completos NC on A.ID_Empleado = NC.ID_Empleado 
			where 
			Asignatura = @Clase	and 
			Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio and
			Nombre1 = @Nombre1 AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''') AND 
			Apellido1 = @Nombre3 AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''')
			)	
							
			declare @ID_Clase int;
			select @ID_Clase = ID_Clase
			from Clases
			where Asignatura = @Clase;

			declare @ID_Sitio int;
			select @ID_Sitio = ID_Sitio
			from Sitio
			where Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio;

			declare @ID_Empleado INT;
			select @ID_Empleado = ID_Empleado
			from Nombres_Completos
			WHERE Nombre1 = @Nombre1
			AND ISNULL(Nombre2, '''') = ISNULL(@Nombre2, '''')
			AND Apellido1 = @Nombre3
			AND ISNULL(Apellido2, '''') = ISNULL(@Nombre4, '''')

			declare @fecha date
			set @fecha = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE)

			INSERT INTO Asistencia values (@ID_Clase, @ID_Sitio, @ID_Empleado, @fecha, ''Ignorar'', null, 0)
		end
		' 
		SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')'
		exec (@finalSQL)

SET @sql = '
create proc dbo.PA_Datos
	@Nombre1 varchar(9),
	@Nombre2 varchar(11),
	@Nombre3 varchar(13),
	@Nombre4 varchar(11),
	@rol varchar (30), 
	@usuario varchar(4),
    @Contraseña varchar(255),
	@ID int
with encryption
as 
begin
    update Nombres_Completos
    set Nombre1 = @Nombre1,
	Nombre2 = @Nombre2,
	Apellido1 = @Nombre3,
	Apellido2 = @Nombre4
	where ID_Empleado = @ID;

	update Empleados
	set rol = @rol,
	codigo_empleado = @usuario,
	contraseña = @contraseña
   	where ID_Empleado = @ID;
end
';

    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

		set @sql = '
	create proc dbo.PA_Respaldo
	with encryption
	as
	begin
	    SET NOCOUNT ON;
		SELECT 
        ID_Asistencia,
	    ID_Clase,
        ID_Sitio,
        ID_Empleado,
        Fecha,
        Observacion,
        Fecha_Reposicion,
        Presente
		FROM dbo.Asistencia;
	end
	'

	SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	set @sql = '
	create proc dbo.PA_CargaRespaldo
	@ID_Clase int,
	@ID_Sitio int, 
	@ID_Empleado int,
	@Fecha date,
	@Observa nvarchar(150),
	@Repone nvarchar(20),
	@Marca bit
	with encryption
	as
	begin
	    SET NOCOUNT ON;
		if not exists (select * from Asistencia where 
			ID_Clase = @ID_Clase and ID_Sitio = @ID_Sitio and ID_Empleado = @ID_Empleado and
			Fecha = @Fecha and Observacion = @Observa and Fecha_Reposicion = @Repone and Presente = @Marca)
		begin
			insert into Asistencia values (@ID_Clase, @ID_Sitio, @ID_Empleado, @Fecha, @Observa, @Repone, @Marca)
		end
    end
	'

	SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	set @sql = '
	create or alter proc dbo.PA_NoBDD
	@DatabaseName SYSNAME
	with encryption
	AS
	BEGIN
	  SET NOCOUNT ON;
	
	  -- Construye el script dinámico, usando QUOTENAME para evitar inyección
	  DECLARE @cmd NVARCHAR(MAX) =
      N''ALTER DATABASE '' + QUOTENAME(@DatabaseName)
      + N'' SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ''
      + N''DROP DATABASE '' + QUOTENAME(@DatabaseName) + N'';'';

	
	  -- Ejecuta el script
	  EXEC sp_executesql @cmd;
	END
	' 
    SET @finalSQL = 'USE master; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	set @sql = '
	create proc PA_Supervisor 
	WITH ENCRYPTION
	AS
	BEGIN
	DECLARE @Hoy DATE = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE);
    DECLARE @AHora CHAR(2) = RIGHT(''0'' + CAST(DATEPART(HOUR, DATEADD(HOUR, -6, SYSDATETIMEOFFSET())) AS VARCHAR(2)), 2);

    SET DATEFIRST 1; -- Asegura que lunes sea 1
    DECLARE @DiaSemana TINYINT = DATEPART(WEEKDAY, DATEADD(HOUR, -6, SYSDATETIMEOFFSET()));
    DECLARE @BitDiaSemana INT = POWER(2, @DiaSemana - 1);

    SELECT DISTINCT 
        (NC.Nombre1 + '' '' + NC.Nombre2 + '' '' + NC.Apellido1 + '' '' + ISNULL(NC.Apellido2, '''')) AS Docente,
        C.Asignatura,
        S.Seccion,
        S.Aula,
        S.Edificio,
        CASE 
            WHEN EXISTS (
                SELECT 1 
                FROM Asistencia A2
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
    WHERE 
        rol != ''decano''  
        AND LEFT(LTRIM(RTRIM(S.Seccion)), 2) = @AHora
        AND ( 
         -- Filtrado por rango de días (si existe)
            (@DiaSemana BETWEEN C.InicioDia AND C.FinDia)
            OR
            -- Filtrado por días específicos (si existe)
            (C.DiasPermitidos IS NOT NULL AND (C.DiasPermitidos & @BitDiaSemana) > 0)
        )
END
'
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	-- CAMBIAR WITH ENCRYPTION
	SET @sql = '
	create proc dbo.PA_Marcar_Asistencia 
	@Docente varchar(100),
	@Asigno varchar(70),
	@Seccion varchar(7),
	@Aula varchar(25),
	@Edificio varchar(1),
	@Fecha date,
    @Marca BIT
	with encryption
AS
BEGIN
    SET NOCOUNT ON;

	/*Para ID de asistencia:
    Obtener ID del empleado*/
	declare @ID_Empleado INT;
	select @ID_Empleado = ID_Empleado
	from Nombres_Completos
	where (Nombre1 + '' '' + Nombre2 + '' '' + Apellido1 + '' '' + Apellido2) = @Docente;

	declare @ID_Clase INT;
	-- Obtener ID de la clase
	select @ID_Clase = ID_Clase
	from Clases
	where Asignatura = @Asigno;

	declare @ID_Sitio INT;
	-- Obtener ID del sitio
	select @ID_Sitio = ID_Sitio
	from Sitio
	where Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio;

    DECLARE @ID_Asistencia INT;
    -- Verificar si ya existe una asistencia para los ID y la fecha
    SELECT @ID_Asistencia = ID_Asistencia
    FROM Asistencia 
    WHERE ID_Empleado = @ID_Empleado and ID_Sitio = @ID_Sitio and ID_Clase = @ID_Clase AND CAST(Fecha AS DATE) = CAST(@Fecha AS DATE);

	if (@ID_Empleado is null or @ID_Sitio is null or @ID_Clase is null)
		PRINT (''Problemas con el desarrollo del sistema'');
		
    IF (@ID_Asistencia IS NULL)
    BEGIN
        -- No existe, se inserta un nuevo registro
        INSERT INTO Asistencia (ID_Clase, ID_Sitio, ID_Empleado, Fecha, Presente)
        VALUES (@ID_Clase, @ID_Sitio, @ID_Empleado, @Fecha, @Marca);
		set @ID_Asistencia = scope_identity();
	end
    ELSE
    BEGIN
        -- Ya existe: se actualiza
        UPDATE Asistencia
        SET Presente = @Marca
        WHERE ID_Asistencia = @ID_Asistencia;
    END
END;
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Buscar_Superv
    @Docente VARCHAR(50),
    @Clase VARCHAR(70),
    @Aula VARCHAR(25),
	@Edificio VARCHAR(1),
	@Seccion varchar(7)
	with encryption
AS
BEGIN 
	DECLARE @Hoy DATE = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE);
    DECLARE @AHora CHAR(2) = RIGHT(''0'' + CAST(DATEPART(HOUR, DATEADD(HOUR, -6, SYSDATETIMEOFFSET())) AS VARCHAR(2)), 2);

    SET DATEFIRST 1; -- Asegura que lunes sea 1
    DECLARE @DiaSemana TINYINT = DATEPART(WEEKDAY, DATEADD(HOUR, -6, SYSDATETIMEOFFSET()));
    DECLARE @BitDiaSemana INT = POWER(2, @DiaSemana - 1);

    SET NOCOUNT ON;

    SELECT DISTINCT 
        (Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Apellido2, '''')) AS Docente, 
        Asignatura, 
        Seccion, 
        Aula, 
        Edificio,
        CASE 
            WHEN EXISTS (
                SELECT 1 
                FROM Asistencia A2
                WHERE A2.ID_Empleado = E.ID_Empleado
                  AND A2.ID_Clase = C.ID_Clase
                  AND A2.ID_Sitio = S.ID_Sitio
                  AND A2.Presente = 1
            ) THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS AsistenciaHoy
	FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE (LEFT(LTRIM(RTRIM(S.Seccion)), 2) = @AHora
           OR ((@DiaSemana BETWEEN C.InicioDia AND C.FinDia)
               OR (C.DiasPermitidos IS NOT NULL AND (C.DiasPermitidos & @BitDiaSemana) > 0)))
      AND ((Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Apellido2, '''')) LIKE ''%'' + @Docente + ''%'' OR @Docente = '''')
      AND (Asignatura LIKE ''%'' + @Clase + ''%'' OR @Clase = '''')
      AND (@Aula = '''' OR Aula = @Aula)
	  AND (@Edificio = '''' OR Edificio = @Edificio)
	  AND (@Seccion = '''' OR Seccion = @Seccion);
END;
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	set @sql = '
create proc PA_Supervisor_Excel
with encryption
as                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
begin  
	select distinct (Nombre1 + '' '' + Nombre2 + '' '' + Apellido1 + '' '' + isnull(Apellido2,'''')) [Docente], 
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
	where rol != ''decano''
end
'
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
	CREATE proc dbo.PA_Periodo
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT top 1 FechaInicio, FechaFin
		FROM Periodo;
	END;
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Admin
with encryption
as
begin
	select distinct
	NC.ID_Empleado ''ID del empleado'', Nombre1 ''Nombre 1'', isnull(Nombre2,'''') ''Nombre 2'', 
	Apellido1 ''Apellido 1'', isnull(Apellido2,'''') ''Apellido 2'', Rol, codigo_empleado [Código de empleado], Contraseña 
	--isnull: comando de condición para insertar valor nulo como vacío o '' (este solo es de un valor y su reemplazo)
	from Empleados E
	join Nombres_Completos NC on E.ID_Empleado = NC.ID_Empleado
END;
'; 

    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
	CREATE PROC dbo.PA_Admin_Busca
    @Dato VARCHAR(100)
	WITH ENCRYPTION
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT
        NC.ID_Empleado   AS [ID del empleado],
        NC.Nombre1       AS [Nombre 1],
        ISNULL(NC.Nombre2, '''')  AS [Nombre 2],
        NC.Apellido1     AS [Apellido 1],
        ISNULL(NC.Apellido2, '''') AS [Apellido 2],
		Rol,
		codigo_empleado [Codigo de Empleado],
        Contraseña
	    FROM dbo.Nombres_Completos NC
	    INNER JOIN dbo.Empleados E
        ON NC.ID_Empleado = E.ID_Empleado
	    WHERE

        @Dato IS NULL
        OR CAST(NC.ID_Empleado AS VARCHAR(10)) = @Dato
        OR NC.Nombre1    LIKE ''%'' + @Dato + ''%''
        OR NC.Nombre2    LIKE ''%'' + @Dato + ''%''
        OR NC.Apellido1  LIKE ''%'' + @Dato + ''%''
        OR NC.Apellido2  LIKE ''%'' + @Dato + ''%''
		or Rol LIKE '%' + @Dato + '%'
		or codigo_empleado LIKE '%' + @Dato + '%'

        OR E.contraseña  = @Dato;
	END;
	'
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Asistencia_Superv -- Para el Excel con las fechas
    @Docente varchar(100),
	@Asigno varchar(70),
	@Seccion varchar(7),
	@Aula varchar(25),
	@Edificio varchar(1)
with encryption
as 
begin
	/* Para fila específica:
	Obtener ID del empleado*/
	declare @ID_Empleado INT;
	select @ID_Empleado = ID_Empleado
	from Nombres_Completos
	where (Nombre1 + '' '' + Nombre2 + '' '' + Apellido1 + '' '' + Apellido2) = @Docente;

	declare @ID_Clase INT;
	-- Obtener ID de la clase
	select @ID_Clase = ID_Clase
	from Clases
	where Asignatura = @Asigno;

	declare @ID_Sitio INT;
	-- Obtener ID del sitio
	select @ID_Sitio = ID_Sitio
	from Sitio
	where Seccion = @Seccion and Aula = @Aula and Edificio = @Edificio;

    SELECT Fecha 
    FROM Asistencia 
    WHERE Presente = 1 
      and ID_Clase = @ID_Clase 
      and ID_Sitio = @ID_Sitio 
      and ID_Empleado = @ID_Empleado;
end;
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Justifica --Decano
@CodigoDecano varchar(4)
with encryption
AS
BEGIN
    SET NOCOUNT ON;
	Busca
	DECLARE @codigo_facu VARCHAR(6);

    SELECT @codigo_facu = codigo_facu
    FROM DecanoFacultad DF
    JOIN Nombres_Completos NC ON DF.ID_Empleado = NC.ID_Empleado
	join Empleados E on E.ID_Empleado = NC.ID_Empleado
    WHERE codigo_empleado = @CodigoDecano;

    SELECT 
           ID_Asistencia,
           Asignatura,
		   Fecha [Fecha de Ausencia],
           (Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Nombre2, '''')) [Docente],
		   Seccion [Sección],
	       Observacion [Justificación]           
    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
	-- Filtrar por el código de facultad del decano:
    WHERE C.Cod_Facultad = @codigo_facu  
    AND A.Presente = 0
	AND CAST(A.Fecha AS DATE) = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE);
END
'; 
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	set @sql = '
	CREATE proc dbo.PA_Justifica_Todo 
@CodigoDecano varchar(4)
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @codigo_facu VARCHAR(6);

    SELECT @codigo_facu = DF.codigo_facu
    FROM DecanoFacultad DF
    JOIN Empleados E 
      ON DF.ID_Empleado = E.ID_Empleado
    WHERE E.codigo_empleado = @CodigoDecano;

    SELECT DISTINCT
           C.Asignatura,
           A.Fecha           AS [Fecha de Ausencia],
           (NC.Nombre1 
            + '' '' + ISNULL(NC.Nombre2,'''') 
            + '' '' + NC.Apellido1 
            + '' '' + ISNULL(NC.Apellido2,''''))      AS [Docente],
           S.Seccion,
           A.Observacion    AS [Justificación]
    FROM Asistencia A
    JOIN Clases C            ON A.ID_Clase   = C.ID_Clase
    JOIN Sitio S             ON A.ID_Sitio   = S.ID_Sitio
    JOIN Empleados E         ON A.ID_Empleado= E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado= NC.ID_Empleado
    WHERE C.Cod_Facultad = @codigo_facu
      AND A.Presente = 0
	order by Seccion, Fecha
END
	'

    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
CREATE proc dbo.PA_Insertar_Justificacion
    @ID_Asistencia INT,
    @Justificacion NVARCHAR(200)
	with encryption
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Asistencia
    SET Observacion = @Justificacion
    WHERE ID_Asistencia = @ID_Asistencia;
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Buscar_Justo
    @Docente VARCHAR(50),
	@Edificio VARCHAR(9),
	@CodigoDecano varchar(4)
with encryption
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @codigo_facu VARCHAR(6);

    SELECT @codigo_facu = codigo_facu
    FROM DecanoFacultad DF
    JOIN Nombres_Completos NC ON DF.ID_Empleado = NC.ID_Empleado
	join Empleados E on E.ID_Empleado = NC.ID_Empleado
    WHERE codigo_empleado = @CodigoDecano;

    SELECT 
           ID_Asistencia,
           Asignatura,
		   Fecha [Fecha de Ausencia],
           (Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Apellido2, '''')) [Docente],
		   Seccion [Sección],
	       Observacion [Justificación]           
    FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE Presente = 0 
      and ((Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Apellido2, '''')) LIKE ''%'' + @Docente + ''%'' OR @Docente = '''')
	  AND (@Edificio = '''' OR Edificio = @Edificio);
	  and C.Cod_Facultad = @codigo_facu  
	  AND CAST(A.Fecha AS DATE) = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE);
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
create proc dbo.PA_Repone --Decano
@CodigoDecano varchar(4)
with encryption
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
           Asignatura,
		   Fecha [Fecha de Ausencia],
           (Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Nombre2, '''')) [Docente],
		   Seccion [Sección],
           Fecha_Reposicion [Fecha de Reposición]

    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    WHERE C.Cod_Facultad = @codigo_facu  
    AND A.Presente = 0
	AND CAST(A.Fecha AS DATE) = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE)
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

set @sql = '
create proc dbo.PA_Repone_Todo 
@CodigoDecano varchar(4)
with encryption
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
           Asignatura,
           Fecha AS [Fecha de Ausencia],
           (NC.Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + NC.Apellido1 + '' '' + ISNULL(Nombre2, '''')) AS [Docente],
           Seccion,
           Fecha_Reposicion ''Fecha de Reposición''
    FROM Asistencia A
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    WHERE C.Cod_Facultad = @codigo_facu  
      AND A.Presente = 0
END
' 
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);


	SET @sql = '
CREATE proc dbo.PA_Insertar_Reposicion --Decano
    @ID_Asistencia INT,
    @Fecha_Reposicion date
	with encryption
AS
BEGIN
    SET NOCOUNT ON;
 
    UPDATE Asistencia
    SET Fecha_Reposicion = @Fecha_Reposicion
    WHERE ID_Asistencia = @ID_Asistencia;
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
CREATE proc dbo.PA_Buscar_Repo
    @Repo varchar(80),	
    @Edificio VARCHAR(9),
	@CodigoDecano varchar(4)
	with encryption
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @codigo_facu VARCHAR(6);

    SELECT @codigo_facu = codigo_facu
    FROM DecanoFacultad DF
    JOIN Nombres_Completos NC ON DF.ID_Empleado = NC.ID_Empleado
	join Empleados E on E.ID_Empleado = NC.ID_Empleado
    WHERE codigo_empleado = @CodigoDecano;

    SELECT 
           ID_Asistencia,
           Asignatura,
		   Fecha [Fecha de Ausencia],
           (Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Nombre2, '''')) [Docente],
		   Seccion [Sección],
           Fecha_Reposicion [Fecha de Reposición]
    FROM Asistencia A
    JOIN Empleados E ON A.ID_Empleado = E.ID_Empleado
    JOIN Nombres_Completos NC ON E.ID_Empleado = NC.ID_Empleado
    JOIN Clases C ON A.ID_Clase = C.ID_Clase
    JOIN Sitio S ON A.ID_Sitio = S.ID_Sitio
    WHERE Presente = 0 
      AND ((@Repo = ''''
	        OR ((Nombre1 + '' '' + ISNULL(Nombre2, '''') + '' '' + Apellido1 + '' '' + ISNULL(Apellido2, '''')) LIKE ''%'' + @Repo + ''%'')
	        OR (Asignatura LIKE ''%'' + @Repo + ''%'')
	        OR (Fecha LIKE ''%'' + @Repo + ''%'')
	        OR (Seccion LIKE ''%'' + @Repo + ''%''))
	        AND (@Edificio = '''' OR Edificio = @Edificio))
			and C.Cod_Facultad = @codigo_facu  
			AND CAST(Fecha AS DATE) = CAST(DATEADD(HOUR, -6, SYSDATETIMEOFFSET()) AS DATE);

END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

SET @sql = '
CREATE proc dbo.PA_Asistencia_Doc -- Tabla del docente
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
END
';

    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

	SET @sql = '
CREATE proc dbo.PA_Fecha_Doc -- Calendario del docente
    @CodDocente varchar(4),
    @Asigna varchar (70),
    @Seccion varchar(7),
    @Aula varchar(25),
    @Edificio varchar(1)
WITH ENCRYPTION
AS
BEGIN
    /*Para fila específica:
	Obtener ID del empleado*/
    DECLARE @ID_Empleado INT;
    SELECT @ID_Empleado = ID_Empleado 
    FROM Empleados
    WHERE codigo_empleado = @CodDocente;

    /*Obtener ID de la clase*/
    DECLARE @ID_Clase INT;
    SELECT @ID_Clase = ID_Clase
    FROM Clases
    WHERE Asignatura = @Asigna;

    /*Obtener ID del sitio*/
    DECLARE @ID_Sitio INT;
    SELECT @ID_Sitio = ID_Sitio
    FROM Sitio
    WHERE Seccion = @Seccion AND Aula = @Aula AND Edificio = @Edificio;

    SELECT Fecha 
    FROM Asistencia 
    WHERE Presente = 1 
      AND ID_Clase = @ID_Clase 
      AND ID_Sitio = @ID_Sitio 
      AND ID_Empleado = @ID_Empleado;
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);

SET @sql = '
CREATE TRIGGER dbo.TGR_AdminContra
ON Empleados
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Empleados;
    -- Busca al único administrador por su rol
    IF EXISTS (SELECT 1 FROM inserted WHERE rol = ''administrador'')
    BEGIN
        -- Actualiza la contraseña con un valor predeterminado (por seguridad)
        UPDATE Empleados
		--Subconsulta para efecto de inserted en @contraseña, pues @contraseña se usa en visual, no en trigger  
        SET contraseña = (SELECT Contraseña FROM inserted WHERE Rol = ''Administrador'')
        WHERE rol = ''Administrador'';
    END
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);
	
	SET @sql = '
create TRIGGER dbo.TRG_Periodo
ON Periodo
INSTEAD OF INSERT
AS
BEGIN
    -- Elimina cualquier registro previo
    DELETE FROM Periodo;

    -- Inserta el nuevo que viene del formulario
    INSERT INTO Periodo (FechaInicio, FechaFin)
    SELECT FechaInicio, FechaFin FROM inserted;
END
';
    SET @finalSQL = 'USE Supervision_Unicah; EXEC(''' + REPLACE(@sql, '''', '''''') + ''')';
    EXEC(@finalSQL);
	end
end