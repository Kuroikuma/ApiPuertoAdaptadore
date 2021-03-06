USE [master]
GO
/****** Object:  Database [APIPUERTOADAPTADORE]    Script Date: 25/05/2022 15:12:10 ******/
CREATE DATABASE [APIPUERTOADAPTADORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APIPUERTOADAPTADORE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\APIPUERTOADAPTADORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'APIPUERTOADAPTADORE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\APIPUERTOADAPTADORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APIPUERTOADAPTADORE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ARITHABORT OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET RECOVERY FULL 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET  MULTI_USER 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'APIPUERTOADAPTADORE', N'ON'
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET QUERY_STORE = OFF
GO
USE [APIPUERTOADAPTADORE]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[AdministradoID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Correo] [varchar](25) NOT NULL,
	[tipo] [int] NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[Imagen] [varchar](70) NOT NULL,
	[telefono] [int] NOT NULL,
	[genero] [char](1) NULL,
	[Contraseña] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdministradoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[Correo] [varchar](25) NOT NULL,
	[telefono] [int] NOT NULL,
	[Imagen] [varchar](70) NOT NULL,
	[genero] [char](1) NULL,
	[tipo] [int] NOT NULL,
	[Contraseña] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrearProducto](
	[CrearProductoID] [uniqueidentifier] NOT NULL,
	[ProductoID] [uniqueidentifier] NOT NULL,
	[IngredienteID] [uniqueidentifier] NOT NULL,
	[CantidadIngrediente] [decimal](18, 0) NOT NULL,
	[CostoDeIngredientes] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CrearProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[telefono] [int] NOT NULL,
	[genero] [char](1) NULL,
	[Imagen] [varchar](70) NOT NULL,
	[Correo] [varchar](25) NOT NULL,
	[tipo] [int] NOT NULL,
	[Contraseña] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaID] [uniqueidentifier] NOT NULL,
	[EmpleadoID] [uniqueidentifier] NOT NULL,
	[ClienteID] [uniqueidentifier] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FacturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[ProductoID] [uniqueidentifier] NOT NULL,
	[FacturaID] [uniqueidentifier] NOT NULL,
	[CatidadProductosVendido] [decimal](18, 0) NOT NULL,
	[CostoProductosVendido] [decimal](18, 0) NOT NULL,
	[PrecioProductosVendido] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC,
	[FacturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[IngredienteID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[precio] [decimal](18, 0) NOT NULL,
	[Stock] [decimal](18, 0) NOT NULL,
	[Imagen] [varchar](70) NOT NULL,
	[unidadMedida] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IngredienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [uniqueidentifier] NOT NULL,
	[CategoriaID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Costo] [decimal](18, 0) NOT NULL,
	[Tamaño] [varchar](25) NOT NULL,
	[Stock] [decimal](18, 0) NOT NULL,
	[Imagen] [varchar](70) NOT NULL,
	[isCompound] [bit] NOT NULL,
	[Descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Root]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Root](
	[RootID] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[telefono] [int] NOT NULL,
	[Imagen] [varchar](70) NOT NULL,
	[genero] [char](1) NULL,
	[Correo] [varchar](25) NOT NULL,
	[tipo] [int] NOT NULL,
	[Contraseña] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[RootID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CrearProducto]  WITH CHECK ADD FOREIGN KEY([IngredienteID])
REFERENCES [dbo].[Ingrediente] ([IngredienteID])
GO
ALTER TABLE [dbo].[CrearProducto]  WITH CHECK ADD FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleado] ([EmpleadoID])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
/****** Object:  StoredProcedure [dbo].[EditarAdministrador]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarAdministrador]
@AdministradoID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Correo VARCHAR (25), @tipo INT, @Apellido VARCHAR (25), @Imagen VARCHAR (70), @telefono INT,  @genero CHAR (1), @Contraseña VARCHAR (30)
AS
	BEGIN 
		UPDATE Administrador SET Nombre = @Nombre, Correo = @Correo, tipo = @tipo, Apellido = @Apellido, Imagen = @Imagen, telefono = @telefono, genero = @genero, Contraseña = @Contraseña WHERE AdministradoID = @AdministradoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarCategoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarCategoria]
@CategoriaID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Descripcion TEXT
AS
	BEGIN 
		UPDATE Categoria SET CategoriaID = @CategoriaID, Nombre = @Nombre WHERE CategoriaID = @CategoriaID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarCliente]
@ClienteID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @Correo VARCHAR (25), @telefono INT, @Imagen VARCHAR (70), @genero CHAR (1), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		UPDATE Cliente SET ClienteID = @ClienteID, Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, telefono = @telefono, Imagen = @Imagen, genero = @genero, tipo = @tipo, Contraseña = @Contraseña WHERE ClienteID = @ClienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarCrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarCrearProducto]
@CrearProductoID UNIQUEIDENTIFIER, @ProductoID  UNIQUEIDENTIFIER, @IngredienteID  UNIQUEIDENTIFIER, @CantidadIngrediente DECIMAL, @CostoDeIngredientes DECIMAL
AS
	BEGIN 
		UPDATE CrearProducto SET ProductoID = @ProductoID, IngredienteID = @IngredienteID, CantidadIngrediente = @CantidadIngrediente, CostoDeIngredientes = @CostoDeIngredientes WHERE CrearProductoID = @CrearProductoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarEmpleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarEmpleado]
@EmpleadoID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @telefono INT, @genero CHAR (1), @Imagen VARCHAR (70), @Correo VARCHAR (25), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		UPDATE Empleado SET Nombre = @Nombre, Apellido = @Apellido, telefono = @telefono, genero = @genero, Imagen = @Imagen, Correo = @Correo, tipo = @tipo, Contraseña = @Contraseña WHERE EmpleadoID = @EmpleadoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarIngrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarIngrediente]
@IngredienteID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @precio DECIMAL, @Stock DECIMAL, @Imagen VARCHAR (70), @unidadMedida VARCHAR (10)
AS
	BEGIN 
		UPDATE Ingrediente SET Nombre = @Nombre, precio = @precio, Stock = @Stock, Imagen = @Imagen, unidadMedida = @unidadMedida WHERE IngredienteID = @IngredienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarProducto]
@ProductoID UNIQUEIDENTIFIER, @CategoriaID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Precio DECIMAL, @Costo DECIMAL, @Tamaño VARCHAR (25), @Stock DECIMAL, @Imagen VARCHAR (70), @isCompound BIT, @Descripcion TEXT
AS
	BEGIN 
		UPDATE Producto SET Nombre = @Nombre, Precio = @Precio, Costo = @Costo, Tamaño = @Tamaño, Stock = @Stock, Imagen = @Imagen, isCompound = @isCompound, Descripcion = @Descripcion WHERE ProductoID = @ProductoID AND CategoriaID = @CategoriaID
	END
GO
/****** Object:  StoredProcedure [dbo].[EditarRoot]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarRoot]
@RootID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @telefono INT, @Imagen VARCHAR (70), @genero CHAR (1), @Correo VARCHAR (25), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		UPDATE Root SET Nombre = @Nombre, Apellido = @Apellido, telefono = @telefono, Imagen = @Imagen, genero = @genero, Correo = @Correo, tipo = @tipo, Contraseña = @Contraseña WHERE RootID = @RootID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarAdministrador]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarAdministrador]
@AdministradoID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Administrador WHERE AdministradoID = @AdministradoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarCategoria]
@CategoriaID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Categoria WHERE CategoriaID = @CategoriaID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarCliente]
@ClienteID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Cliente WHERE ClienteID = @ClienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarCrearProducto]
@CrearProductoID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE CrearProducto WHERE CrearProductoID = @CrearProductoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEmpleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarEmpleado]
@EmpleadoID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Empleado WHERE EmpleadoID = @EmpleadoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarIngrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarIngrediente]
@IngredienteID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Ingrediente WHERE IngredienteID = @IngredienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarProducto]
@ProductoID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Producto WHERE ProductoID = @ProductoID
	END
GO
/****** Object:  StoredProcedure [dbo].[EliminarRoot]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarRoot]
@RootID UNIQUEIDENTIFIER
AS
	BEGIN 
		DELETE Root WHERE RootID = @RootID
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarAdministrador]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP ADMINISTRADOR

CREATE PROCEDURE [dbo].[InsertarAdministrador]
@AdministradoID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Correo VARCHAR (25), @tipo INT, @Apellido VARCHAR (25), @Imagen VARCHAR (70), @telefono INT,  @genero CHAR (1), @Contraseña VARCHAR (30)
AS
	BEGIN 
		INSERT INTO Administrador VALUES (@AdministradoID, @Nombre, @Correo, @tipo, @Apellido, @Imagen, @telefono, @genero, @Contraseña)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCategoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP CATEGORIA

CREATE PROCEDURE [dbo].[InsertarCategoria]
@CategoriaID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Descripcion TEXT
AS
	BEGIN 
		INSERT INTO Categoria VALUES (@CategoriaID, @Nombre, @Descripcion)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP CLIENTE

CREATE PROCEDURE [dbo].[InsertarCliente]
@ClienteID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @Correo VARCHAR (25), @telefono INT, @Imagen VARCHAR (70), @genero CHAR (1), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		INSERT INTO Cliente VALUES (@ClienteID, @Nombre, @Apellido, @Correo, @telefono, @Imagen, @genero, @tipo, @Contraseña)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarEmpleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP EMPLEADO

CREATE PROCEDURE [dbo].[InsertarEmpleado]
@EmpleadoID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @telefono INT, @genero CHAR (1), @Imagen VARCHAR (70), @Correo VARCHAR (25), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		INSERT INTO Empleado VALUES (@EmpleadoID, @Nombre, @Apellido, @telefono, @genero, @Imagen, @Correo, @tipo, @Contraseña)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarFactura]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP FACTURA

CREATE PROCEDURE [dbo].[InsertarFactura]
@FacturaID UNIQUEIDENTIFIER, @EmpleadoID UNIQUEIDENTIFIER, @ClienteID UNIQUEIDENTIFIER, @Total DECIMAL, @Fecha DATETIME
AS
	BEGIN 
		INSERT INTO Factura VALUES (@FacturaID, @EmpleadoID, @ClienteID, @Total, @Fecha)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarFacturaDetalle]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP FACTURA DETALLE

CREATE PROCEDURE [dbo].[InsertarFacturaDetalle]
@ProductoID  UNIQUEIDENTIFIER, @FacturaID  UNIQUEIDENTIFIER, @CatidadProductosVendido DECIMAL, @CostoProductosVendido DECIMAL, @PrecioProductosVendido DECIMAL
AS
	BEGIN 
		INSERT INTO FacturaDetalle VALUES (@ProductoID, @FacturaID, @CatidadProductosVendido, @CostoProductosVendido, @PrecioProductosVendido)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP PRODUCTO

CREATE PROCEDURE [dbo].[InsertarProducto]
@ProductoID UNIQUEIDENTIFIER, @CategoriaID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Precio DECIMAL, @Costo DECIMAL, @Tamaño VARCHAR (25), @Stock DECIMAL, @Imagen VARCHAR (70), @isCompound BIT, @Descripcion TEXT
AS
	BEGIN 
		INSERT INTO Producto VALUES (@ProductoID, @CategoriaID, @Nombre, @Precio, @Costo, @Tamaño, @Stock, @Imagen, @isCompound, @Descripcion)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertarRoot]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP ROOT

CREATE PROCEDURE [dbo].[InsertarRoot]
@RootID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @Apellido VARCHAR (25), @telefono INT, @Imagen VARCHAR (70), @genero CHAR (1), @Correo VARCHAR (25), @tipo INT, @Contraseña VARCHAR (30)
AS
	BEGIN 
		INSERT INTO Root VALUES (@RootID, @Nombre, @Apellido, @telefono, @Imagen, @genero, @Correo, @tipo, @Contraseña)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertCrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP CREAR PRODUCTO

CREATE PROCEDURE [dbo].[InsertCrearProducto]
@CrearProductoID UNIQUEIDENTIFIER, @ProductoID  UNIQUEIDENTIFIER, @IngredienteID  UNIQUEIDENTIFIER, @CantidadIngrediente DECIMAL, @CostoDeIngredientes DECIMAL
AS
	BEGIN 
		INSERT INTO CrearProducto VALUES (@CrearProductoID, @ProductoID, @IngredienteID, @CantidadIngrediente, @CostoDeIngredientes)
	END
GO
/****** Object:  StoredProcedure [dbo].[InsertIngrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP INGREDIENTE

CREATE PROCEDURE [dbo].[InsertIngrediente]
@IngredienteID UNIQUEIDENTIFIER, @Nombre VARCHAR (25), @precio DECIMAL, @Stock DECIMAL, @Imagen VARCHAR (70), @unidadMedida VARCHAR (10)
AS
	BEGIN 
		INSERT INTO Ingrediente VALUES (@IngredienteID, @Nombre, @precio, @Stock, @Imagen, @unidadMedida)
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarAdministrador]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarAdministrador]
AS
	BEGIN 
		SELECT * FROM Administrador
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarCategoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCategoria]
AS
	BEGIN 
		SELECT * FROM Categoria
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarCliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCliente]
AS
	BEGIN 
		SELECT * FROM Cliente
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarCrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCrearProducto]
AS
	BEGIN 
		SELECT * FROM CrearProducto
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarEmpleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarEmpleado]
AS
	BEGIN 
		SELECT * FROM Empleado
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarFactura]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarFactura]
AS
	BEGIN 
		SELECT * FROM Factura
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarIngrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarIngrediente]
AS
	BEGIN 
		SELECT * FROM Ingrediente
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarProducto]
AS
	BEGIN 
		SELECT * FROM Producto
	END
GO
/****** Object:  StoredProcedure [dbo].[ListarRoot]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarRoot]
AS
	BEGIN 
		SELECT * FROM Root
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarAdmin]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarAdmin]
@AdministradorID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Administrador WHERE AdministradoID = @AdministradorID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarAdminporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarAdminporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Administrador WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarCategoria]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarCategoria]
@CategoriaID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Categoria WHERE CategoriaID = @CategoriaID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarCategoriaporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarCategoriaporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Categoria WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarCliente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarCliente]
@ClienteID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Cliente WHERE ClienteID = @ClienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarClienteporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarClienteporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Cliente WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarCrearProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarCrearProducto]
@CrearProductoID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM CrearProducto WHERE CrearProductoID = @CrearProductoID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarEmpleado]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarEmpleado]
@EmpleadoID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Empleado WHERE EmpleadoID = @EmpleadoID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarEmpleadoporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarEmpleadoporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Empleado WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarFactura]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarFactura]
@FacturaID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Factura WHERE FacturaID = @FacturaID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarIngrediente]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarIngrediente]
@IngredienteID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Ingrediente WHERE IngredienteID = @IngredienteID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarIngredienteporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarIngredienteporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Producto WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarProducto]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarProducto]
@ProductoID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Producto WHERE ProductoID = @ProductoID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarProductoporNombre]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarProductoporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Producto WHERE Nombre = @Nombre
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarRoot]    Script Date: 25/05/2022 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarRoot]
@RootID UNIQUEIDENTIFIER
AS
	BEGIN 
		SELECT * FROM Root WHERE RootID = @RootID
	END
GO
/****** Object:  StoredProcedure [dbo].[seleccionarRootporNombre]    Script Date: 25/05/2022 15:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[seleccionarRootporNombre]
@Nombre VARCHAR (25)
AS
	BEGIN 
		SELECT * FROM Root WHERE Nombre = @Nombre
	END
GO
USE [master]
GO
ALTER DATABASE [APIPUERTOADAPTADORE] SET  READ_WRITE 
GO
