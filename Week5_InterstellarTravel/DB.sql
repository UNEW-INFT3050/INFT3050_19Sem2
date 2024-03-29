USE [Interstellar]
GO
/****** Object:  Table [dbo].[Destination]    Script Date: 3/05/2019 5:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destination](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DistanceFromEarth] [bigint] NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Destination] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 3/05/2019 5:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Phone] [nchar](10) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassengerTrip]    Script Date: 3/05/2019 5:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassengerTrip](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PassengerId] [bigint] NOT NULL,
	[DestinationId] [int] NOT NULL,
 CONSTRAINT [PK_PassengerTrip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Destination] ON 

INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (1, N'Mars', 40000000, N'Lorem Ipsum', N'Lorem Ipsum', 2000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/mars-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (2, N'Titan', 190000000, N'Lorem Ipsum', N'Lorem Ipsum', 30000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/titan-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (3, N'Earth', 0, N'Lorem Ipsum', N'Lorem Ipsum', 10.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/earth-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (4, N'Trappist', 130003039393, N'Lorem Ipsum', N'Lorem Ipsum', 400000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/trappist-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (5, N'Europa', 19293832, N'Lorem Ipsum', N'Lorem Ipsum', 30000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/europa-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (6, N'Ceres', 292929202, N'Lorem Ipsum', N'Lorem Ipsum', 400000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/ceres-small.jpg')
INSERT [dbo].[Destination] ([Id], [Name], [DistanceFromEarth], [ShortDescription], [LongDescription], [Price], [Image]) VALUES (8, N'SuperEarth', 24342432322, N'Lorem Ipsum', N'Lorem Ipsum', 400000000.0000, N'https://www.jpl.nasa.gov/visions-of-the-future/images/superearth-small.jpg')
SET IDENTITY_INSERT [dbo].[Destination] OFF
ALTER TABLE [dbo].[PassengerTrip]  WITH CHECK ADD  CONSTRAINT [FK_PassengerTrip_Destination] FOREIGN KEY([DestinationId])
REFERENCES [dbo].[Destination] ([Id])
GO
ALTER TABLE [dbo].[PassengerTrip] CHECK CONSTRAINT [FK_PassengerTrip_Destination]
GO
ALTER TABLE [dbo].[PassengerTrip]  WITH CHECK ADD  CONSTRAINT [FK_PassengerTrip_Passenger] FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passenger] ([Id])
GO
ALTER TABLE [dbo].[PassengerTrip] CHECK CONSTRAINT [FK_PassengerTrip_Passenger]
GO
