CREATE TABLE [dbo].[Restaurants](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[Address_PostalCode] [nvarchar](5) NOT NULL,
	[Address_Street] [nvarchar](100) NOT NULL,
	[Address_Location] [nvarchar](60) NOT NULL,
	[Address_Province] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[Email] [nvarchar](255) NULL,
	[WebSite] [nvarchar](255) NULL,
	[CreatedAt] [datetime2] NOT NULL,
 CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED
(
	[Id] ASC
))
GO

ALTER TABLE [dbo].[Restaurants] ADD  CONSTRAINT [DF_Restaurants_CreatedAt]  DEFAULT (GETUTCDATE()) FOR [CreatedAt]
GO