USE [master]
GO
/****** Object:  Database [TiendaVinilos]    Script Date: 08/11/2023 22:54:18 ******/
CREATE DATABASE [TiendaVinilos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TiendaVinilos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TiendaVinilos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TiendaVinilos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TiendaVinilos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TiendaVinilos] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TiendaVinilos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TiendaVinilos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TiendaVinilos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TiendaVinilos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TiendaVinilos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TiendaVinilos] SET ARITHABORT OFF 
GO
ALTER DATABASE [TiendaVinilos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TiendaVinilos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TiendaVinilos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TiendaVinilos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TiendaVinilos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TiendaVinilos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TiendaVinilos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TiendaVinilos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TiendaVinilos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TiendaVinilos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TiendaVinilos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TiendaVinilos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TiendaVinilos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TiendaVinilos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TiendaVinilos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TiendaVinilos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TiendaVinilos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TiendaVinilos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TiendaVinilos] SET  MULTI_USER 
GO
ALTER DATABASE [TiendaVinilos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TiendaVinilos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TiendaVinilos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TiendaVinilos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TiendaVinilos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TiendaVinilos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TiendaVinilos] SET QUERY_STORE = ON
GO
ALTER DATABASE [TiendaVinilos] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TiendaVinilos]
GO
/****** Object:  Table [dbo].[Artista]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artista](
	[idArtista] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[inicio] [date] NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[idGenero] [int] NULL,
	[favoritos] [int] NULL,
 CONSTRAINT [PK_Artista] PRIMARY KEY CLUSTERED 
(
	[idArtista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancion]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancion](
	[idCancion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idDisco] [int] NOT NULL,
 CONSTRAINT [PK_Cancion] PRIMARY KEY CLUSTERED 
(
	[idCancion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComentarioDisco]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioDisco](
	[idComentario] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[contenido] [varchar](max) NOT NULL,
	[publicacion] [datetime] NOT NULL,
	[idDisco] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[idComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deseo]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deseo](
	[idDeseo] [int] IDENTITY(1,1) NOT NULL,
	[idDisco] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Deseo] PRIMARY KEY CLUSTERED 
(
	[idDeseo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disco]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disco](
	[idDisco] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[portada] [varchar](200) NOT NULL,
	[discografica] [varchar](50) NOT NULL,
	[formato] [varchar](50) NOT NULL,
	[pais] [varchar](50) NOT NULL,
	[publicacion] [date] NOT NULL,
	[idGenero] [int] NULL,
	[favoritos] [int] NULL,
	[criticos] [int] NULL,
	[unidades] [int] NULL,
	[idArtista] [int] NULL,
 CONSTRAINT [PK_Disco] PRIMARY KEY CLUSTERED 
(
	[idDisco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duda]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duda](
	[idDuda] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idAdmin] [int] NULL,
	[titutlo] [varchar](50) NOT NULL,
	[contenido] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NULL,
	[publicacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Duda] PRIMARY KEY CLUSTERED 
(
	[idDuda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElementoCesta]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementoCesta](
	[idUsuario] [int] NOT NULL,
	[idDisco] [int] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElementoPedido]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementoPedido](
	[idElemento] [int] IDENTITY(1,1) NOT NULL,
	[idDisco] [int] NULL,
	[precio] [float] NOT NULL,
	[cantidad] [int] NOT NULL,
	[idPedido] [int] NOT NULL,
 CONSTRAINT [PK_Elemento] PRIMARY KEY CLUSTERED 
(
	[idElemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[idGenero] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[idGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagenArtista]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagenArtista](
	[idImagen] [int] IDENTITY(1,1) NOT NULL,
	[idArtista] [int] NOT NULL,
	[enlace] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ImagenArtista] PRIMARY KEY CLUSTERED 
(
	[idImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagenDisco]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagenDisco](
	[idImagen] [int] IDENTITY(1,1) NOT NULL,
	[idDisco] [int] NOT NULL,
	[enlace] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ImagenDisco] PRIMARY KEY CLUSTERED 
(
	[idImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Integrante]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Integrante](
	[idIntegrante] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idArtista] [int] NOT NULL,
 CONSTRAINT [PK_Integrante] PRIMARY KEY CLUSTERED 
(
	[idIntegrante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[sugerencia] [varchar](300) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[idTienda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[ubicacion] [varchar](50) NOT NULL,
	[calle] [varchar](50) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[pais] [varchar](50) NOT NULL,
	[apertura] [time](7) NOT NULL,
	[cierre] [time](7) NOT NULL,
 CONSTRAINT [PK_Tienda] PRIMARY KEY CLUSTERED 
(
	[idTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/11/2023 22:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contraseña] [varchar](200) NOT NULL,
	[imagen] [varchar](200) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[conexion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artista] ADD  CONSTRAINT [DF_Artista_favoritos]  DEFAULT ((0)) FOR [favoritos]
GO
ALTER TABLE [dbo].[Disco] ADD  CONSTRAINT [DF_Disco_favoritos]  DEFAULT ((0)) FOR [favoritos]
GO
ALTER TABLE [dbo].[Disco] ADD  CONSTRAINT [DF_Disco_criticos]  DEFAULT ((0)) FOR [criticos]
GO
ALTER TABLE [dbo].[Disco] ADD  CONSTRAINT [DF_Disco_unidades]  DEFAULT ((0)) FOR [unidades]
GO
ALTER TABLE [dbo].[Artista]  WITH CHECK ADD  CONSTRAINT [FK_Artista_Genero] FOREIGN KEY([idGenero])
REFERENCES [dbo].[Genero] ([idGenero])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Artista] CHECK CONSTRAINT [FK_Artista_Genero]
GO
ALTER TABLE [dbo].[Cancion]  WITH CHECK ADD  CONSTRAINT [FK_Cancion_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cancion] CHECK CONSTRAINT [FK_Cancion_Disco]
GO
ALTER TABLE [dbo].[ComentarioDisco]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComentarioDisco] CHECK CONSTRAINT [FK_Table_1_Disco]
GO
ALTER TABLE [dbo].[ComentarioDisco]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComentarioDisco] CHECK CONSTRAINT [FK_Table_1_Usuario]
GO
ALTER TABLE [dbo].[Deseo]  WITH CHECK ADD  CONSTRAINT [FK_Deseo_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deseo] CHECK CONSTRAINT [FK_Deseo_Disco]
GO
ALTER TABLE [dbo].[Deseo]  WITH CHECK ADD  CONSTRAINT [FK_Deseo_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deseo] CHECK CONSTRAINT [FK_Deseo_Usuario]
GO
ALTER TABLE [dbo].[Disco]  WITH CHECK ADD  CONSTRAINT [FK_Disco_Artista] FOREIGN KEY([idArtista])
REFERENCES [dbo].[Artista] ([idArtista])
GO
ALTER TABLE [dbo].[Disco] CHECK CONSTRAINT [FK_Disco_Artista]
GO
ALTER TABLE [dbo].[Disco]  WITH CHECK ADD  CONSTRAINT [FK_Disco_Genero] FOREIGN KEY([idGenero])
REFERENCES [dbo].[Genero] ([idGenero])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Disco] CHECK CONSTRAINT [FK_Disco_Genero]
GO
ALTER TABLE [dbo].[Duda]  WITH CHECK ADD  CONSTRAINT [FK_Duda_Admin] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Duda] CHECK CONSTRAINT [FK_Duda_Admin]
GO
ALTER TABLE [dbo].[Duda]  WITH CHECK ADD  CONSTRAINT [FK_Duda_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Duda] CHECK CONSTRAINT [FK_Duda_Usuario]
GO
ALTER TABLE [dbo].[ElementoCesta]  WITH CHECK ADD  CONSTRAINT [FK_ElementoCesta_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ElementoCesta] CHECK CONSTRAINT [FK_ElementoCesta_Disco]
GO
ALTER TABLE [dbo].[ElementoCesta]  WITH CHECK ADD  CONSTRAINT [FK_ElementoCesta_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ElementoCesta] CHECK CONSTRAINT [FK_ElementoCesta_Usuario]
GO
ALTER TABLE [dbo].[ElementoPedido]  WITH CHECK ADD  CONSTRAINT [FK_Elemento_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ElementoPedido] CHECK CONSTRAINT [FK_Elemento_Disco]
GO
ALTER TABLE [dbo].[ElementoPedido]  WITH CHECK ADD  CONSTRAINT [FK_ElementoPedido_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ElementoPedido] CHECK CONSTRAINT [FK_ElementoPedido_Pedido]
GO
ALTER TABLE [dbo].[ImagenArtista]  WITH CHECK ADD  CONSTRAINT [FK_ImagenArtista_Artista] FOREIGN KEY([idArtista])
REFERENCES [dbo].[Artista] ([idArtista])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImagenArtista] CHECK CONSTRAINT [FK_ImagenArtista_Artista]
GO
ALTER TABLE [dbo].[ImagenDisco]  WITH CHECK ADD  CONSTRAINT [FK_ImagenDisco_Disco] FOREIGN KEY([idDisco])
REFERENCES [dbo].[Disco] ([idDisco])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImagenDisco] CHECK CONSTRAINT [FK_ImagenDisco_Disco]
GO
ALTER TABLE [dbo].[Integrante]  WITH CHECK ADD  CONSTRAINT [FK_Integrante_Artista] FOREIGN KEY([idArtista])
REFERENCES [dbo].[Artista] ([idArtista])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Integrante] CHECK CONSTRAINT [FK_Integrante_Artista]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
USE [master]
GO
ALTER DATABASE [TiendaVinilos] SET  READ_WRITE 
GO
