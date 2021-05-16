CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductsCategories](
	[ProductId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Категория 1')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Категория 2')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Категория 3')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name]) VALUES (1, N'Помидоры')
GO
INSERT [dbo].[Products] ([Id], [Name]) VALUES (2, N'Огурцы')
GO
INSERT [dbo].[Products] ([Id], [Name]) VALUES (3, N'Картофель')
GO
INSERT [dbo].[Products] ([Id], [Name]) VALUES (4, N'Бананы')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO

INSERT [dbo].[ProductsCategories] ([ProductId], [CategoryId]) VALUES (1, 1)
GO
INSERT [dbo].[ProductsCategories] ([ProductId], [CategoryId]) VALUES (1, 2)
GO
INSERT [dbo].[ProductsCategories] ([ProductId], [CategoryId]) VALUES (2, 3)
GO
INSERT [dbo].[ProductsCategories] ([ProductId], [CategoryId]) VALUES (3, 1)
GO

ALTER TABLE [dbo].[ProductsCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductsCategories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ProductsCategories] CHECK CONSTRAINT [FK_ProductsCategories_Categories]
GO
ALTER TABLE [dbo].[ProductsCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductsCategories_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductsCategories] CHECK CONSTRAINT [FK_ProductsCategories_Products]
GO

CREATE PROCEDURE [dbo].[GetAllProductsAndCategoriesPairs]    
AS
	SELECT p.Name, c.Name FROM Products AS p
	LEFT JOIN ProductsCategories AS pc ON pc.ProductId = p.Id
	LEFT JOIN Categories AS c ON pc.CategoryId = c.Id
GO
