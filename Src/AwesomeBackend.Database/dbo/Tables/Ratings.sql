CREATE TABLE [dbo].[Ratings](
	[Id] [uniqueidentifier] NOT NULL,
	[RestaurantId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Rating] [float] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED
(
	[Id] ASC
),
CONSTRAINT [FK_Ratings_Users] FOREIGN KEY (UserId) REFERENCES [AspNetUsers]([Id]))
GO

ALTER TABLE [dbo].[Ratings] ADD CONSTRAINT [FK_OwnerRatings_Owners] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurants] ([Id])
GO

ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_OwnerRatings_Owners]
GO
