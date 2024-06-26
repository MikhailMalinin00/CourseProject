USE [courseproject]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 19.11.2023 18:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 19.11.2023 18:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Director] [nvarchar](max) NULL,
	[GenreID] [int] NOT NULL,
	[Duration] [int] NULL,
	[Rating] [real] NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 19.11.2023 18:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[NumberOfSeat] [int] NULL,
	[OrderStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 19.11.2023 18:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[AvailableSeat] [int] NULL,
	[DateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19.11.2023 18:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [int] NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (4, N'Комедия')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (5, N'Мультфильм')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (6, N'Ужасы')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (7, N'Фантастика')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (8, N'Триллер')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (9, N'Боевик')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (10, N'Мелодрама')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (11, N'Приключения')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (12, N'Фэнтези')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (13, N'Военные')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (14, N'Семейные')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (15, N'Аниме')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (16, N'Исторические')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (17, N'Драмы')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (18, N'Документальные')
INSERT [dbo].[Genres] ([ID], [Genre]) VALUES (19, N'Детские')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (1, N'Дьявол носит Prada', N'Дэвид Френкель', 4, 109, 9, N'https://storage14.eljur.ru/storage/79ec7e8bd279d37e6ec7025affb0695c?filename=%D0%94%D1%8C%D1%8F%D0%B2%D0%BE%D0%BB+%D0%BD%D0%BE%D1%81%D0%B8%D1%82+Prada.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (2, N'Губка Боб в 3D', N'Пол Тиббит', 5, 92, 8, N'https://storage14.eljur.ru/storage/268f568130670d2fae4803d087a03407?filename=%D0%93%D1%83%D0%B1%D0%BA%D0%B0+%D0%91%D0%BE%D0%B1+%D0%B2+3D.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (3, N'Дом восковых фигур', N'Жоме Коллет Серра', 6, 113, 7, NULL)
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (7, N'Звездные войны', N'Джорж Лукас', 7, 136, 8, N'https://storage14.eljur.ru/storage/cd958d6bc4bba554256dfe820813a9c4?filename=%D0%97%D0%B2%D0%B5%D0%B7%D0%B4%D0%BD%D1%8B%D0%B5+%D0%B2%D0%BE%D0%B9%D0%BD%D1%8B.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (8, N'Вне себя', N'Тарсем Сингх', 8, 116, 8, N'https://storage14.eljur.ru/storage/f5a9060027491a17e10d46e48aab5f23?filename=%D0%92%D0%BD%D0%B5+%D1%81%D0%B5%D0%B1%D1%8F.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (9, N'Сбежавшая невеста', N'Гарри Маршалл', 10, 116, 7, NULL)
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (10, N'Жена астронавта', N'Рэнд Рэвич', 12, 110, 8, N'https://storage14.eljur.ru/storage/b2c95ebfc795d7087b2f3d1f892912cf?filename=%D0%96%D0%B5%D0%BD%D0%B0+%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%BD%D0%B0%D0%B2%D1%82%D0%B0.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (11, N'Марли и я', N'Дэвид Френкель', 14, 115, 9, N'https://storage14.eljur.ru/storage/60911ab472c6a5676b0df83a25297c09?filename=%D0%9C%D0%B0%D1%80%D0%BB%D0%B8+%D0%B8+%D1%8F.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (12, N'Солдатик', N'Виктория Фанасютина', 13, 86, 8, NULL)
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (13, N'Путешественница во времени', N'Оливер Трэнер', 17, 120, 7, N'https://storage14.eljur.ru/storage/e6345a3cd9a4925ec936bce08646cfd5?filename=%D0%9F%D1%83%D1%82%D0%B5%D1%88%D0%B5%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%BD%D0%B8%D1%86%D0%B0+%D0%B2%D0%BE+%D0%B2%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%B8.jpg&domain=kip')
INSERT [dbo].[Movies] ([ID], [Title], [Director], [GenreID], [Duration], [Rating], [Photo]) VALUES (16, N'Тестовое', N'тестовое', 4, 90, 9, N'тестовое')
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (2, 2, 1, 2, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (3, 4, 2, 5, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (4, 7, 6, 4, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (5, 5, 4, 3, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (6, 9, 3, 1, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (7, 6, 5, 3, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (8, 8, 9, 6, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (10, 11, 10, 4, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (11, 10, 7, 2, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (12, 2, 8, 3, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (21, 1, 11, 2, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (28, 1, 1, 5, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (29, 1, 1, 5, NULL)
INSERT [dbo].[Orders] ([ID], [UserID], [ScheduleID], [NumberOfSeat], [OrderStatus]) VALUES (30, 2, 13, 9, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (1, 1, 35, CAST(N'2023-10-26T10:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (2, 2, 40, CAST(N'2023-10-26T12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (3, 3, 40, CAST(N'2023-10-26T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (4, 7, 40, CAST(N'2023-10-26T16:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (5, 8, 40, CAST(N'2023-10-26T18:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (6, 9, 40, CAST(N'2023-10-26T20:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (7, 10, 40, CAST(N'2023-10-26T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (8, 11, 40, CAST(N'2023-10-27T10:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (9, 12, 40, CAST(N'2023-10-27T12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (10, 13, 40, CAST(N'2023-10-27T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (11, 16, 25, CAST(N'2023-11-25T13:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (12, 16, 25, CAST(N'2023-11-25T13:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedule] ([ID], [MovieID], [AvailableSeat], [DateTime]) VALUES (13, 1, 16, CAST(N'2023-11-27T13:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (1, N'Малинин', N'Михаил', N'test', N'9BC34549D565D9505B287DE0CD20AC77BE1D3F2C', 0, N'207693@edu.fa.ru', N'+79999999999')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (2, N'Аксенова', N'Татьяна', N'test2', N'9BC34549D565D9505B287DE0CD20AC77BE1D3F2C', 1, N'sdfkgh@dfg.ru', N'+79999999999')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (4, N'Сиянгулов', N'Венедикт', N'venedikt23091962', N'9B3D9D7E875E8922865474829650FE67C81D4F5F', 1, N'venedikt23091962@mail.ru', N'+79564738921')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (5, N'Якушева', N'Вероника', N'veronika.yakusheva', N'6E4E0664F76110C9F8E1007962D5603F3247FC7A', 1, N'veronika.yakusheva@yandex.ru', N'+79993546328')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (6, N'Хесманова', N'Василиса', N'vasilisa1962', N'F575B65DCD70C804CB96CBCC463E51DBF8BC8384', 1, N'vasilisa1962@outlook.com', N'+79831253462')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (7, N'Золотухина', N'Инна', N'inna.zolotuhina', N'5A42BFA8CE3D545416522101BEFBEB6BD0574676', 1, N'inna.zolotuhina@outlook.com', N'+79853879035')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (8, N'Ягубский', N'Иван', N'ivan20', N'9358F96E86F885ADD8F854092BE9CDF88CBBA4AD', 1, N'ivan20@mail.ru', N'+79893438720')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (9, N'Золотарёва', N'Арина', N'arina42', N'129E5327A0EC1BEA504EE53369BE34B704A50B08', 1, N'arina42@yandex.ru', N'+79055354298')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (10, N'Шалаганов', N'Прохор', N'prohor6723', N'3E7049A5D8EBC1A2C60949BF19C09E87DACC4496', 1, N'prohor6723@hotmail.com', N'+79859795034')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [Login], [Password], [Role], [Email], [Phone]) VALUES (11, N'Яковкин', N'Иннокентий', N'innokentiy9316', N'9A5C00AC7A49468693775B69296438B2F54BA8AE', 1, N'innokentiy9316@hotmail.com', N'+79993649036')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([ID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Schedule]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Movies]
GO
